using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ButtonTest : MonoBehaviour, ITrackableEventHandler {

	private TrackableBehaviour mTrackableBehaviour;
	private bool mShowGUIButton = false;




	void Start () {
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
	
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

	void OnGUI() {
		if (mShowGUIButton)
		{
			Text.text = "Object" + mTrackableBehaviour.TrackableName;
		} else
		{
			Text.text = "";
		}
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
//		if (mShowGUIButton) {
//			// draw the GUI button
//			//GUI.Button (mButtonRect, c, guiStyle);
//			//if (GUI.Button(mButtonRect, "Hello")) {
//				// do something on button click 
//			//}
//		}

	}
}