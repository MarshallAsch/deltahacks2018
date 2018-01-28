using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Linq;
using System.Linq.Expressions;

public class Countries : MonoBehaviour {


	// Use this for initialization
	void Start () {

		StartCoroutine(GetCountries());
	}


	IEnumerator GetCountries()
	{
		string getCountriesUrl = "https://api.hermes.marshallasch.ca/v1/objects/abc";
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
					RootObject entities = JsonHelper.getJsonArray<RootObject>(jsonResult);
		
					//set text here
					//entities.response.description



				}
			}
		}
	}

	// Update is called once per frame
	void Update () {

	}
}