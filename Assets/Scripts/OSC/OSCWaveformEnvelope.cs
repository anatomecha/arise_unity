using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OSCWaveformEnvelope : MonoBehaviour 
{
	public GameObject scaleObject;
	public int channel = 1;
	public int iterations = 23;
	public float gain = 40.0f;
	public Vector3 moveVector = new Vector3(1, 0, 0);
	public Vector3 spinVector = new Vector3(0, 0, 0);
	
	private float minScaleImpulse = 0.01f;
	private float newLastScale = 0.0f;
	private float lastScale = 0.0f;
	private float scaleImpulse = 0.0f;
	private List<GameObject> scaleObjects = new List<GameObject>();
	private Vector3 orientation = new Vector3(0,0,0);
	
	void Start () {
		Transform initialParent = scaleObject.transform.parent;
		scaleObjects.Add(scaleObject);
		for(int i=1; i<iterations; i++) {
			GameObject newObject = Instantiate(scaleObject) as GameObject;
			scaleObjects.Add(newObject);
			scaleObjects[i].transform.parent = initialParent;
			scaleObjects[i].transform.localPosition = new Vector3(moveVector.x*i, moveVector.y*i, moveVector.z*i);
		}
	}
	
	void FixedUpdate () {
		
		// store the old scale value of the first element
		float lastScale = scaleObjects[0].transform.localScale.y;
		
		// assign new value
		scaleObjects[0].transform.localScale = new Vector3(1, scaleImpulse * gain, 1);
		
		// send the scale values down the list in order
		for(int i=1; i<scaleObjects.Count; i++) {
			
			// store last scale value
			newLastScale = scaleObjects[i].transform.localScale.y;
			
			// assign new scale value from previous element
			scaleObjects[i].transform.localScale = new Vector3(1, lastScale, 1);
			
			// save the old scale value for tne next element
			lastScale = newLastScale;
			
			// apply rotation 
			orientation = scaleObjects[i].transform.localEulerAngles;
			scaleObjects[i].transform.localEulerAngles = new Vector3( (orientation.x+ spinVector.x *i/2.0f), (orientation.y+ spinVector.y *i/2.0f), (orientation.z+spinVector.z *i/2.0f));
		}
		
		// smoothly fade out the peak impulse to prevent strobing
		if(scaleImpulse > minScaleImpulse) {
			scaleImpulse += -0.02f; 
		}	
		else {
			scaleImpulse = minScaleImpulse;
		}
	}
	
	void OSCAudioEnvelope (OSCHandler.AudioEnvelopeData input) {
		if(input.channel == channel){
			scaleImpulse = input.envelope;
		}
	}
}
