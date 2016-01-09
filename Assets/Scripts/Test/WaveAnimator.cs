using UnityEngine;
using System.Collections;

public class WaveAnimator : MonoBehaviour {

	public Vector3 positionOffset = new Vector3 ();
	public Vector3 rotationOffset = new Vector3 ();
	public float frequency = 0.2f;

	WaveGenerator waveGenerator = new WaveGenerator();
	float waveValue = 0;
	Vector3 startPosition = new Vector3();
	Vector3 newPosition = new Vector3();
	Vector3 newRotation = new Vector3();

	public int channel = 1;
	
	void Start () {
		waveGenerator = gameObject.AddComponent<WaveGenerator>() as WaveGenerator;
		waveGenerator.frequency = frequency;

		// init new transforms with current position
		startPosition = gameObject.transform.localPosition;
		newPosition = startPosition;
		newRotation = gameObject.transform.localEulerAngles;
	}

	void Update () {
		waveValue = waveGenerator.GetCurrentValue(); // comment this out to do the osc hack below
		newPosition.x = transform.localPosition.x + (waveValue * positionOffset.x) *Time.deltaTime;
		newPosition.y = transform.localPosition.y + (waveValue * positionOffset.y) *Time.deltaTime;
		newPosition.z = transform.localPosition.z + (waveValue * positionOffset.z) *Time.deltaTime;
		transform.localPosition = newPosition;

		newRotation.x = transform.localEulerAngles.x + (waveValue * rotationOffset.x) *Time.deltaTime;
		newRotation.y = transform.localEulerAngles.y + (waveValue * rotationOffset.y) *Time.deltaTime;
		newRotation.z = transform.localEulerAngles.z + (waveValue * rotationOffset.z) *Time.deltaTime;
		transform.localEulerAngles = newRotation;
	}

	/*void OSCAudioEnvelope ( OSCHandler.AudioEnvelopeData input ) {
		if(input.channel == channel){
			waveValue = input.envelope * 5.0f;
			print ( "audio envelope 1, " +  input.envelope );
		}
	}*/

	void OSCMetronome (float tempo) {
		StopCoroutine( "PulseCamera");	
		StartCoroutine( "PulseCamera", 0.1f);
	}

	// coroutine for animating the camera
	// temp hacking the wave value for testing OSC metronome
	IEnumerator PulseCamera(float fadeTime) {
		float startTime = Time.time;
		float normalizedEelapsedTime = 0.0f;
		transform.localPosition = startPosition;
		
		while(normalizedEelapsedTime <=1.0){
			float elapsedTime = (Time.time - startTime);
			normalizedEelapsedTime = elapsedTime/fadeTime;
			//Color lerpedColor = Color.Lerp(activeColor, restColor, normalizedEelapsedTime);
			//waveValue = normalizedEelapsedTime; // this is the osc hack

			yield return null;
		}
	}
}
