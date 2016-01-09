using UnityEngine;
using System.Collections;

// Require these components when using this script
[RequireComponent (typeof (Animator))]
[RequireComponent (typeof (CapsuleCollider))]
[RequireComponent (typeof (Rigidbody))]

public class VelotronControllerScript : MonoBehaviour 
{
	[System.NonSerialized]
	public float moveSpeed = 100.0f;
	
	[System.NonSerialized]
	public float moveImpulse = 0.01f;
	
	public float velocity = 0.0f;
	public float v = 0.0f;
	public float yaw = 0.0f;
	
	[System.NonSerialized]
	public float animSpeed = 1.0f;
	
	private Animator anim;
	private AnimatorStateInfo currentBaseState;
	private AnimatorStateInfo layer2CurrentState;
	
	private bool walkingEnabled = false;

	// this is for parenting the camera to his hand during the arise sequence
	public GameObject childObject;
	public GameObject parentObject;
	private bool delaySwitchParentToggle = false;

	void Start () 
	{
		// initializing reference variables
		anim = GetComponent<Animator>();
		if(anim.layerCount == 2)
				anim.SetLayerWeight(1, 1);
	}
	
	/*void OnAnimatorMove() //Tells Unity that root motion is handled by the script
	{
		if(anim)
		{
			Vector3 newPosition = transform.position;
			newPosition.z += anim.GetFloat("Speed") * moveSpeed * Time.deltaTime;
			transform.position = newPosition;
		}
	}*/

	void Update () {
		//transform.localEulerAngles.Set(0.0f, yaw, 0.0f);
	}

	void LateUpdate () 
	{
		currentBaseState = anim.GetCurrentAnimatorStateInfo(0);

		//float v = Input.GetAxis("Vertical");
		if (v > 0.1 || v < -0.1){

			if( walkingEnabled == false ){
				anim.SetFloat("Speed", 1.0f);

				// parent camera to hand for arise sequence
				if ( delaySwitchParentToggle == false ) {
					DelaySwitchParent( 2.0f, childObject, parentObject); //72.667f
					delaySwitchParentToggle = true;
				}
				return;
			}

			velocity += v * moveImpulse;
			anim.SetFloat("Speed", velocity);



			//idle
			if(velocity < 0.1 && velocity > -0.1) {
				anim.speed = 1.0f;
			}
			
			//walk
			if(velocity > 0.1 && velocity < 1) {
				anim.speed = velocity *4;
			}
			
			//run
			if(velocity > 1) {
				anim.speed = velocity;// -0.5f;
			}


		}

		transform.localEulerAngles.Set(0.0f, yaw, 0.0f);
		
		// always reset velocity to zero if negative
		if(velocity < 0) {
			velocity = 0.0f;
		}
		
		/*
		//Controls the movement
		if(v <= 0.0f){
			moveSpeed = 100;
		}
		else
		{
			moveSpeed = 140;
		}
		
		if(anim.layerCount == 2)
		{
			layer2CurrentState = anim.GetCurrentAnimatorStateInfo(1);
		}*/
	}

	IEnumerator DelaySwitchParent(float fadeTime, GameObject childObject, GameObject parentObject) {
		float startTime = Time.time;
		float elapsedTime = 0.0f;
		print ("test");
		while(elapsedTime <= fadeTime){
			elapsedTime = Time.time - startTime;
			print (elapsedTime);
			yield return null;
		}
		childObject.transform.parent = parentObject.transform;
	}
}
