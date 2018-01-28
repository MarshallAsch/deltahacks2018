using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using TMPro;

public class ButtonTest : MonoBehaviour, ITrackableEventHandler {

	private TrackableBehaviour mTrackableBehaviour;
	private bool mShowGUIButton = false;
	private TextMesh text;
	private Rect mButtonRect = new Rect (0, 0, 120, 60);

	private TextMeshPro tText;

	void Start () {
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}

		//tText = gameObject.AddComponent<TextMeshPro> ();
		///tText.transform.position = new Vector3 (9, -2, 2);
		//tText.fontSize = 5;


		if (GameObject.Find ("coffeeText") != null)
		{
			tText = GameObject.Find ("coffeeText").GetComponent<TextMeshPro> ();
		}

		//text = GetComponentInChildren <TextMesh>();
	
	}

	public void OnTrackableStateChanged(
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
			newStatus == TrackableBehaviour.Status.TRACKED)
		{
			mShowGUIButton = true;
		}
		else
		{
			mShowGUIButton = false;
		}
	}

	void Update()
	{

		//Vector3 v = Camera.main.transform.position - transform.position;

		//v.x = v.z = 0.0f;
		//transform.LookAt (Camera.main.transform - v);
		//transform.Rotate (0,180,0);
		//transform.rotation = Quaternion.LookRotation(-Camera.main.transform.forward, Camera.main.transform.up);
	}

	void OnGUI() {
		//if (mShowGUIButton)
		//{
		//	text.text = mTrackableBehaviour.TrackableName;
		//} else
		//{
		//	text.text = "";
		//}
//		GUIStyle guiStyle;
//		guiStyle = new GUIStyle();
//		guiStyle.font = font;
//		guiStyle.fontSize = 20;
//		//guiStyle.alignment = TextAnchor.MiddleCenter;
//
//		//GUI.Button (mButtonRect, "Object" + mTrackableBehaviour.TrackableName, guiStyle);
//
//
//



		if (mShowGUIButton) {
			// draw the GUI button
			GUI.Button (mButtonRect, mTrackableBehaviour.TrackableName);
			tText.text = "test";
			//if (GUI.Button(mButtonRect, "Hello")) {
			//	 do something on button click 
			//}
		}

	}
}