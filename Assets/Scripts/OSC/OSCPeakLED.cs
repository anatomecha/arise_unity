using UnityEngine;
using System.Collections;

public class OSCPeakLED : MonoBehaviour 
{
	public int channel = 1;
	public Color restColor = Color.black;
	public Color activeColor = Color.red;
	public PeakLED[] peakLEDs;
	
	[System.Serializable]
	public class PeakLED {
		public GameObject obj;
		public float peakLevel;
		[System.NonSerialized]
		public Material mat;
	}
	
	void Start () {
		// initialize all peakLEDs
		foreach(PeakLED peakLED in peakLEDs) {
			peakLED.mat = peakLED.obj.gameObject.GetComponent<Renderer>().material;
			SetPeakLEDColor(peakLED, restColor);
		}
	}
	
	void SetPeakLEDColor(PeakLED peakLED, Color inputColor) {
		peakLED.mat.SetColor("_Color", inputColor);
		peakLED.mat.SetColor("_TintColor", inputColor);
		peakLED.mat.SetColor("_Emission", inputColor);
		//peakLED.mat.SetColor("_TintColor", inputColor);
	}
	
	void OSCAudioEnvelope (OSCHandler.AudioEnvelopeData input) {
		if(input.channel == channel) {
			foreach(PeakLED peakLED in peakLEDs) {
				if(input.envelope >= peakLED.peakLevel) {
					SetPeakLEDColor(peakLED, activeColor);
				}
				else {
					SetPeakLEDColor(peakLED, restColor);
				}
			}
		}
	}
}
