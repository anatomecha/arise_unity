using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Leap;

/* ideas

fractals change iteration depth

numberpad controls

add boids

*/

public class Axiom : MonoBehaviour {
	public GameObject axiomObject;
	public Material material;

	public Axiom( GameObject axiomObject ) {
		this.axiomObject = axiomObject;
		this.material = null;

		Material material;
		List<GameObject> children = new List<GameObject>();
		for( int c = 0; c < axiomObject.transform.childCount; c++ ){
			Transform child = axiomObject.transform.GetChild(c);
			//children.Add( child.gameObject );
			if( child.GetComponent<Renderer>() != null ){
				material = child.GetComponent<Renderer>().sharedMaterial;
				print ("material=" + material);
				this.material = material;
			}
		}
	}
};

public class SpaceMagic : MonoBehaviour {
	public List<GameObject> axioms = new List<GameObject>();
	public Axiom activeAxiom;
	public Camera camera;
	public List<Axiom> axiomObjects = new List<Axiom>();
	private Transform cameraTarget;
	private Transform cameraTransform;
	private int axiom_index = 0;
	private float speed = 2.0f;
	private float pos_scale = 0.007f;
	private GameObject globals = null;
	private float speedMultiplier = 100f;
	public GameObject axiomRoot;
	private Vector3 axiomCurrentOrientation;
	private Vector3 axiomOrientationOffset;
	private float axiomScale = 2.0f;
	private float axiomScaleStep = 0.1f;
	public SpaceMagicScene spaceMagicScene;

	// leap hand controller
	private bool handExists = false;
	private Vector3 palmForwardDefault;
	Hand leap_hand;
	HandModel handModel;

	// pinch gesture detection
	public const float TRIGGER_DISTANCE_RATIO = 0.7f;
	public float magnetDistance = 2.0f;
	public bool pinching_;
	bool trigger_pinch = false;


	void Start() {
		print ("initializing axiom...");

		for( int i=0; i<axioms.Count; i++ ){
			axioms[i].SetActive(false);
			axiomObjects.Add( new Axiom(axioms[i]));
		}

		activeAxiom = axiomObjects[axiom_index];
		activeAxiom.axiomObject.SetActive (true);

		cameraTransform = camera.transform;

		GetGlobals ();

		pinching_ = false;

		var previousAxiom = globals.transform.localPosition.x;
		globals.transform.localEulerAngles = new Vector3(axiomScale,0.0f,0.0f);
		print ("previousAxiom=" + previousAxiom);
		SwitchAxiom ( System.Convert.ToInt32(previousAxiom));

		axiomScale = globals.transform.localEulerAngles.x;
		activeAxiom.axiomObject.transform.localScale = new Vector3 ( axiomScale, axiomScale, axiomScale );

	}

	// the spaceMagicGlobals object is a transform that remains in the scene even when the hands aren't there
	// to preserve persistent information
	// globals.position.x = active axiom index
	// globals.localEulerAngles.x = axiom scale
	void GetGlobals() {
		globals = GameObject.Find ("spaceMagicGlobals");
		if( globals == null){
			globals = new GameObject("spaceMagicGlobals");
		}
	}

	void OnPinch() {
		pinching_ = true;
		print ("space magic pinching = true");
		SetAxiomCurrentOrientation ();

	}
	
	void OnRelease() {
		pinching_ = false;
		print ("space magic pinching = false");
	}

	void Update() {
		trigger_pinch = false;

		handModel = GetComponent<HandModel>();
		activeAxiom = axiomObjects[axiom_index];
		if (handModel != null) {

			if(handExists == false){
				InitNewHand();
				handExists = true;
			}

			leap_hand = GetComponent<HandModel> ().GetLeapHand ();

			if (leap_hand != null) {

				DetectPinchGesture();

				Vector palm_pos = leap_hand.PalmPosition;
				Vector3 palm_rot = handModel.GetPalmRotation ().eulerAngles;
				Vector3 palm_forward = handModel.palm.forward;
				Vector3 palmForwardDiff = palmForwardDefault - palm_forward;
				float alphaCutoff;

				activeAxiom.axiomObject.transform.localPosition = new Vector3 (palm_pos.x * pos_scale, palm_pos.y * pos_scale, palm_pos.z * -pos_scale);// *8.0f);

				if (pinching_) {
					// direct rotational control
					activeAxiom.axiomObject.transform.eulerAngles = palm_rot + axiomOrientationOffset; 

					// movement
					float horizontal = -palmForwardDiff.x;
					float vertical = palmForwardDiff.y;
					//print ("h=" + horizontal + " v=" + vertical);
					axiomRoot.transform.Translate( -horizontal * Time.deltaTime * speedMultiplier,0, vertical * Time.deltaTime * speedMultiplier, relativeTo:Space.Self);


					// set material alpha
					//alphaCutoff = Mathf.Abs((200.0f - palm_pos.y)/-200.0f);
					//activeAxiom.material.SetFloat("_Cutoff", alphaCutoff);

				}
				else {
					// continuous spin
					Vector3 axiomSpin = new Vector3( palmForwardDiff.y, palmForwardDiff.x, palmForwardDiff.z ) * 180.0f * Time.deltaTime;
					activeAxiom.axiomObject.transform.Rotate( axiomSpin, Space.World );

					// set material alpha
					alphaCutoff = Mathf.Abs((200.0f - palm_pos.y)/-200.0f);
					activeAxiom.material.SetFloat("_Cutoff", alphaCutoff);


				}

			}
		} 
		else {
			handExists = false;
		}

		camera.transform.LookAt ( cameraTarget );

		// detect input for switching axioms
		if (Input.GetKey("1") || Input.GetKey(KeyCode.Keypad8) ) { SwitchAxiom(0); }
		if (Input.GetKey("2") || Input.GetKey(KeyCode.Keypad5) ) { SwitchAxiom(1); }
		if (Input.GetKey("3") || Input.GetKey(KeyCode.Keypad4) ) { SwitchAxiom(2); }
		if (Input.GetKey("4") || Input.GetKey(KeyCode.Keypad6) ) { SwitchAxiom(3); }
		if (Input.GetKey("5") || Input.GetKey(KeyCode.Keypad2) ) { SwitchAxiom(4); }

		// set axiom scale based on numberpad plus/minus input
		if( Input.GetKey(KeyCode.KeypadMinus ) ){
			axiomScale += axiomScaleStep;
			globals.transform.localEulerAngles = new Vector3(axiomScale,0.0f,0.0f);
		}
		if( Input.GetKey(KeyCode.KeypadPlus ) ){
			axiomScale -= axiomScaleStep;
			globals.transform.localEulerAngles = new Vector3(axiomScale,0.0f,0.0f);
		}
		activeAxiom.axiomObject.transform.localScale = new Vector3 ( axiomScale, axiomScale, axiomScale );

	}

	void DetectPinchGesture(  ){
		Vector leap_thumb_tip = leap_hand.Fingers [0].TipPosition;
		float proximal_length = leap_hand.Fingers [0].Bone (Bone.BoneType.TYPE_PROXIMAL).Length;
		float trigger_distance = proximal_length * TRIGGER_DISTANCE_RATIO;
		
		// Check thumb tip distance to joints on all other fingers.
		// If it's close enough, start pinching.
		for (int i = 1; i < HandModel.NUM_FINGERS && !trigger_pinch; ++i) {
			Finger finger = leap_hand.Fingers [i];
			
			for (int j = 0; j < FingerModel.NUM_BONES && !trigger_pinch; ++j) {
				Vector leap_joint_position = finger.Bone ((Bone.BoneType)j).NextJoint;
				if (leap_joint_position.DistanceTo (leap_thumb_tip) < trigger_distance) {
					trigger_pinch = true;
				}
			}
		}
		
		Vector3 pinch_position = handModel.fingers [0].GetTipPosition ();
		
		// Only change state if it's different.
		if (trigger_pinch && !pinching_) {
			OnPinch ();
		} else if (!trigger_pinch && pinching_) {
			OnRelease ();
		}
	}

	void SetAxiomCurrentOrientation(){
		axiomCurrentOrientation = activeAxiom.axiomObject.transform.eulerAngles;
		axiomOrientationOffset = axiomCurrentOrientation - handModel.GetPalmRotation ().eulerAngles;;
	}

	void InitNewHand(){
		print ("init hand space magic...");
		palmForwardDefault = handModel.palm.forward;
		print ("palmDefaultForward=" + palmForwardDefault);
		axiomScale = globals.transform.localEulerAngles.x;
		activeAxiom.axiomObject.transform.localScale = new Vector3 ( axiomScale, axiomScale, axiomScale );
	}
	
	void SwitchAxiom( int i ) {
		axiom_index = i;
		activeAxiom.axiomObject.SetActive(false);
		activeAxiom = axiomObjects[i];
		activeAxiom.axiomObject.SetActive(true);
		print("switching axiom to " + i);
		globals.transform.localPosition = new Vector3(i,0.0f,0.0f);
		//spaceMagicScene.activeAxiom = activeAxiom.gameObject;
	}
	
	void SetCameraTarget( Transform newTarget ) {
		cameraTarget = newTarget;
	}
}

