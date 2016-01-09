using UnityEngine;
using System.Collections;
using Leap;


public class VelotronLeapController : MonoBehaviour {	
	public GameObject velotron;
	private float speed = 2.0f;
	private float pos_scale = 0.01f;
	VelotronControllerScript vc;


	void Start() {
		vc = velotron.GetComponent<VelotronControllerScript>();

	}

	void Update() {
		HandModel handModel = GetComponent<HandModel>();
		Hand leap_hand = GetComponent<HandModel>().GetLeapHand();
		
		
		if (leap_hand != null) {
			Vector palm_pos = leap_hand.PalmPosition;
			Quaternion palm_rot = handModel.GetPalmRotation();

			float impulse = palm_rot.x *2;

			vc.v = 0.11f;
			vc.velocity = impulse;

			float y = palm_rot.y * 600.0f;
			vc.yaw	 = y;
			print (y);
			//print(palm_rot.x);
			
			//target.transform.eulerAngles = palm_rot;
			//target.transform.localPosition = new Vector3(palm_pos.x*pos_scale, palm_pos.y*pos_scale, palm_pos.z*-pos_scale);

		}
	}
	
	protected void SetRendererAlpha(Renderer render, float alpha) {
		Color new_color = render.material.color;
		new_color.a = alpha;
		render.material.color = new_color;
	}
}
