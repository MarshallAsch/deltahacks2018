using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotation : MonoBehaviour {

	private Transform initialTransform;
	private Quaternion initialRotation;
	// Use this for initialization
	void Start () {
		initialTransform = gameObject.transform;
		initialRotation = gameObject.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		// update 

		//transform.LookAt (Camera.main.transform);
		//Vector3 v = Camera.main.transform.position - transform.position;

		//v.x = v.z = 0.0f;
		//transform.LookAt (Camera.main.transform.position - v);
		//transform.Rotate (0,180,0);
	}
}
