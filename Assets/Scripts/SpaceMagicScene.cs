using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;

// attach this component to main camera for the win
public class SpaceMagicScene : MonoBehaviour {
	public List<GameObject> objectsToHide = new List<GameObject>();
	public GameObject sceneRoot;
	private Camera camera;
	private float glitchScale = 50000000f;
	public List<GameObject> leapHands = new List<GameObject>();
	//public GameObject activeAxiom;

	
	// Use this for initialization
	void Start () {
		foreach ( GameObject obj in objectsToHide) {
			obj.SetActive(false);
		}

		camera = gameObject.GetComponent<Camera>();

	}
	
	// Update is called once per frame
	void Update () {

		if( Input.GetKeyDown("b") || Input.GetKeyDown(KeyCode.Keypad0) ) {
			BlockLocking();
		}
		if( Input.GetKeyUp("b") || Input.GetKeyUp(KeyCode.Keypad0) ) {
			sceneRoot.transform.position = Vector3.zero;
			print ("my 7XL has been invented.");
		}

		// cheat code for 37337 h4x0rz only
		if( Input.GetKey(KeyCode.Keypad7) && Input.GetKey(KeyCode.Keypad9) ) {
			Overdraw();
		}

		// Depth Buffer Tearing
		if( Input.GetKeyDown("t") || Input.GetKeyDown(KeyCode.KeypadPeriod) ) {
			TearDepthBuffer();
		}
		if( Input.GetKeyUp("t")  || Input.GetKeyUp(KeyCode.KeypadPeriod) ) {
			camera.nearClipPlane = 1f;
			camera.farClipPlane = 100f;
		}

		/*
		// ambient motion
		GameObject[] leapHandsList;
		leapHandsList = GameObject.FindGameObjectsWithTag("leap_hand");
		leapHands.Clear();
		foreach( GameObject hand in leapHandsList ){
			leapHands.Add (hand);
		}
		print ("active axiom = " + activeAxiom);
		if( leapHands.Count == 0 ){
			//print ("no hands...");

			if( activeAxiom  ){
				print ("active axiom = " + activeAxiom);
				Vector3 r = activeAxiom.transform.localEulerAngles;
				activeAxiom.transform.Rotate( new Vector3( r.x + 10.0f * Time.deltaTime , r.y, r.z )  );
				print ("rotating...");
			}
		}*/

	}

	void Overdraw() {
		print ("ARISE");
		camera.clearFlags = CameraClearFlags.Depth;
	}

	void TearDepthBuffer() {
		camera.nearClipPlane = 0.000015f;
		camera.farClipPlane = 10000000000000000000f;
	}

	void BlockLocking() {

		sceneRoot.transform.position = new Vector3 (glitchScale, glitchScale, glitchScale);
		


	}

}
