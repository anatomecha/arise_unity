using UnityEngine;
using System.Collections;
using Leap;

public class LeapHandController : MonoBehaviour {
	private MagneticPinch magneticPinch;
	public HandModel hand_model;

	// Use this for initialization
	void Start () {
		magneticPinch = hand_model.GetComponent<MagneticPinch> ();
	}
	
	// Update is called once per frame
	void Update () {

		bool trigger_pinch = false;
		Hand leap_hand = hand_model.GetLeapHand();

		if (leap_hand == null)
			return;

		print(leap_hand.Fingers[0].TipPosition);

		if( trigger_pinch ){
			print ("pinch!");
		}

		
	}
}
