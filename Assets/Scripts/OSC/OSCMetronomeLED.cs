using UnityEngine;
using System.Collections;

public class OSCMetronomeLED : MonoBehaviour 
{
	public int channel = 1;
	public Color restColor = Color.black;
	public Color activeColor = Color.red;
	public MetronomeLED[] metronomeLEDs;
	
	[System.Serializable]
	public class MetronomeLED {
		public GameObject obj;
		
		[System.NonSerialized] 
		public Material mat;
	}
	
	void Start () {
		
		// initialize all LEDs
		foreach(MetronomeLED metronomeLED in metronomeLEDs) {
			metronomeLED.mat = metronomeLED.obj.gameObject.GetComponent<Renderer>().material;
			SetMetronomeLEDColor(metronomeLED, restColor);
		}
	}
	
	void SetMetronomeLEDColor(MetronomeLED metronomeLED, Color inputColor) {
		metronomeLED.mat.SetColor("_Color", inputColor);
		metronomeLED.mat.SetColor("_TintColor", inputColor);
		metronomeLED.mat.SetColor("_Emission", inputColor);
		//metronomeLED.mat.SetColor("_TintColor", inputColor);
	}
	
	void OSCMetronome (float tempo) {
		StopCoroutine( "StrobeLED");	
		StartCoroutine( "StrobeLED", 0.5);
	}
	
	IEnumerator StrobeLED(float fadeTime) {
		float startTime = Time.time;
		float normalizedEelapsedTime = 0.0f;
		
		while(normalizedEelapsedTime <=1.0){
			float elapsedTime = (Time.time - startTime);
			normalizedEelapsedTime = elapsedTime/fadeTime;
			Color lerpedColor = Color.Lerp(activeColor, restColor, normalizedEelapsedTime);
			foreach(MetronomeLED metronomeLED in metronomeLEDs) {
				SetMetronomeLEDColor(metronomeLED, lerpedColor);
			}
			yield return null;
		}
		
		foreach(MetronomeLED metronomeLED in metronomeLEDs) {
			SetMetronomeLEDColor(metronomeLED, restColor);
		}
	}
}

