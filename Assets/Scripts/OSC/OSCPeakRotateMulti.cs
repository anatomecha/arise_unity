using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OSCPeakRotateMulti : MonoBehaviour 
{
	public List<OSCPeakRotateObject> oscPeakObjects;
	
	[System.Serializable]
	public class OSCPeakRotateObject {
		public GameObject peakObject;
		public int channel = 1;
		public Vector3 minVector;
		public Vector3 maxVector;
	} 
	
	
	void OSCAudioEnvelope (OSCHandler.AudioEnvelopeData input) {
		foreach(OSCPeakRotateObject oscPeakObject in oscPeakObjects) {
			if(input.channel == oscPeakObject.channel) {
				oscPeakObject.peakObject.transform.localEulerAngles =  Vector3.Lerp(oscPeakObject.minVector, oscPeakObject.maxVector, input.envelope);
			}
		}
	}
}
