using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using TMPro;
using UnityEngine.Networking;

public class ButtonTest : MonoBehaviour, ITrackableEventHandler {

	private TrackableBehaviour mTrackableBehaviour;
	private bool mShowGUIButton = false;
	private Rect mButtonRect = new Rect (0, 0, 120, 60);

	private TextMeshPro tText;

	void Start () {
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}

		if (GameObject.Find ("coffeeText") != null)
		{
			tText = GameObject.Find ("coffeeText").GetComponent<TextMeshPro> ();
		}
	}

	public void OnTrackableStateChanged(
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
			newStatus == TrackableBehaviour.Status.TRACKED)
		{
			tText.text = mTrackableBehaviour.TrackableName;

			mShowGUIButton = true;
			StartCoroutine(getObject());

		}
		else
		{
			mShowGUIButton = false;
		}
	}
		

	void OnGUI() {


		if (mShowGUIButton) {
			GUI.Button (mButtonRect, mTrackableBehaviour.TrackableName);

		}

	}


	IEnumerator getObject()
	{
		string getCountriesUrl = "http://api.hermes.marshallasch.ca/v1/objects/coffeeText";
		using (UnityWebRequest www = UnityWebRequest.Get(getCountriesUrl))
		{
			//www.chunkedTransfer = false;
			yield return www.Send();
			if (www.isNetworkError || www.isHttpError)
			{
				Debug.Log(www.error);
			}
			else
			{
				if (www.isDone)
				{
					string jsonResult = 
						System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
					Debug.Log(jsonResult);

					tText.text = jsonResult;
					//set text here
					//entities.response.description
				}
			}
		}
	}
}