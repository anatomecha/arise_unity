using UnityEngine;
using System.Collections;

public class MobileCameraController : MonoBehaviour {
	
	public int yawDirectChannel = 1;
	public int yawDriftChannel = 2;
	private float yaw = 0.0f;
	private float yawDirect = 0.0f;
	private float yawDrift = 0.0f;
	Transform t;
	
	// Use this for initialization
	void Start () {
		t = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(yawDirect > 0.01f) { yaw = yawDirect *36.0f; }
		yaw += yawDrift *0.1f;
		transform.localEulerAngles = new Vector3(0, yaw, 0);
	}
	
	void OSCDirectDriveSlider(OSCHandler.DirectDriveData input) {
		if(input.channel == yawDirectChannel) {
			yawDirect = input.impulse;
		}
		else if(input.channel == yawDriftChannel) {
			yawDrift = input.impulse;
		}
	}
}
