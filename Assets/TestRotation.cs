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
}
