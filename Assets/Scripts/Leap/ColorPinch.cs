using UnityEngine;
using System.Collections;
using Leap;


public class ColorPinch : MonoBehaviour {

	public const float TRIGGER_DISTANCE_RATIO = 0.7f;

	public Camera camera;
	Color backgroundColor = new Color( 0, 0, 0 );
	private float colorScale = 50.0f;
	public float clipPlaneSliceDistance = 24.0f;

	// The maximum range at which an object can be picked up.
	public float magnetDistance = 2.0f;

	public bool pinching_;
	private bool handExists = false;

	private Vector3 palmForwardDefault;
	Hand leap_hand;
	HandModel handModel;

	private float nearClipPlane = 1.0f;
	private float farClipPlane = 100.0f;
	private float clipPlaneWidth = 0.1f;

	void Start() {
		pinching_ = false;
		//nearClipPlane = camera.nearClipPlane;
		//farClipPlane = camera.farClipPlane;
	}

	void OnPinch() {
		pinching_ = true;
		//print ("color pinching = true");
		RenderSettings.fog = true;

		//camera.nearClipPlane = clipPlaneSliceDistance - clipPlaneWidth/2.0f;
		//camera.farClipPlane = clipPlaneSliceDistance + clipPlaneWidth/2.0f;

		camera.nearClipPlane = clipPlaneSliceDistance;
		camera.farClipPlane = clipPlaneSliceDistance + 0.1f;
		camera.clearFlags = CameraClearFlags.Depth;
	}

	void OnRelease() {
		pinching_ = false;
		//print ("color pinching = false");
		RenderSettings.fog = false;
		camera.nearClipPlane = nearClipPlane;
		camera.farClipPlane = farClipPlane;
		camera.clearFlags = CameraClearFlags.Skybox;
	}


	void Update() {
		bool trigger_pinch = false;

		// set background solid color on button press
		/*if (Input.GetKeyDown("space")) {
			camera.clearFlags = CameraClearFlags.SolidColor;
			camera.backgroundColor = backgroundColor;
			nearClipPlane = camera.nearClipPlane;
			farClipPlane = camera.farClipPlane;
		} 
		else {
			//camera.clearFlags = CameraClearFlags.Depth;
		}*/

		handModel = GetComponent<HandModel>();
		if (handModel != null) {
			
			if (handExists == false) {
				InitNewHand ();
				handExists = true;
				RenderSettings.fog = true;
			}

			leap_hand = handModel.GetLeapHand ();

			Vector palm_pos = leap_hand.PalmPosition;
			//Quaternion palm_rot = handModel.GetPalmRotation(); //old working version
			//Color pinchColor = new Color (palm_rot.x*colorScale, palm_rot.y*colorScale, palm_rot.z*colorScale);

			Vector3 palm_forward = handModel.palm.forward;
			Vector3 palmForwardDiff = (palmForwardDefault - palm_forward) *2.0f;
			Color pinchColor = new Color( Mathf.Abs(palmForwardDiff.x), Mathf.Abs(palmForwardDiff.y), Mathf.Abs(palmForwardDiff.z) );
			RenderSettings.fogColor = pinchColor;

			// Scale trigger distance by thumb proximal bone length.
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

			if (pinching_) {
				//RenderSettings.fogColor = pinchColor;
				//print ("pinchColor=" + pinchColor + " palmForwardDiff=" + palmForwardDiff);
				//print ("r=" + pinchColor.r + " g=" + pinchColor.g + " b=" + pinchColor.b);

				/* // set clip plane width - this works, but I'm not srue I want to keep it.
				clipPlaneWidth = Mathf.Abs((200.0f - palm_pos.y)/-200.0f);
				print("clipPlaneWidth=" + clipPlaneWidth);
				camera.nearClipPlane = clipPlaneSliceDistance - clipPlaneWidth/2.0f;
				camera.farClipPlane = clipPlaneSliceDistance + clipPlaneWidth/2.0f;
				*/
			}
		} 
		else {
			handExists = false;
			RenderSettings.fog = false;
		}
	}

	void InitNewHand(){
		print ("init hand color pinch...");
		palmForwardDefault = handModel.palm.forward;
		Vector3 temp = palmForwardDefault - handModel.palm.forward;
		print ("palmDefaultForward=" + palmForwardDefault + " rest = " + temp);
	}
}