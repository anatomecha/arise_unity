using UnityEngine;
using System.Collections;


public class OSCMetronomeStrobe : MonoBehaviour 
{
	
	[System.NonSerialized]
	public Light lightComponent;
	
	[System.NonSerialized]
	public Color lerpedColor;
	
	public Color restColor = Color.black;
	
	void Start () {
		lightComponent = gameObject.GetComponent<Light>();
	}
	
	void OSCMetronome (float tempo) {
		StopCoroutine( "StrobeLight");	
		StartCoroutine( "StrobeLight", 0.5);
	}
	
	IEnumerator StrobeLight(float fadeTime) {
		Color startColor = Color.red;
		float startTime = Time.time;
		float normalizedEelapsedTime = 0.0f;
		lightComponent.intensity = 100.0f;
		
		while(normalizedEelapsedTime <=1.0){
			float elapsedTime = (Time.time - startTime);
			normalizedEelapsedTime = elapsedTime/fadeTime;
			lerpedColor = Color.Lerp(startColor, restColor, normalizedEelapsedTime);
			lightComponent.color = lerpedColor;
			yield return null;
		}
		lightComponent.color = restColor;
	}
}
