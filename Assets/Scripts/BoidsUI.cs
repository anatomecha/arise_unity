using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class BoidsUI : MonoBehaviour {
	public List<Boid> flock = new List<Boid>();
	public Slider momentumSlider;
	public Slider speedSlider;
	public Slider separationSlider;
	public Slider alignmentSlider;
	public Slider cohesionSlider;
	public Camera camera;

	// Use this for initialization
	void Start () {
		GetFlock ();
		print ( "Number of boids = " + flock.Count );

		momentumSlider.onValueChanged.AddListener (delegate {SetMomentum ();});
		speedSlider.onValueChanged.AddListener (delegate {SetSpeed ();});
		separationSlider.onValueChanged.AddListener (delegate {SetSeparation ();});
		alignmentSlider.onValueChanged.AddListener (delegate {SetAlignment ();});
		cohesionSlider.onValueChanged.AddListener (delegate {SetCohesion ();});

	}

	void Awake () {
		SetSpeed ();
		SetSeparation ();
		SetAlignment ();
		SetCohesion ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// momentum slider
	public void SetMomentum(){
		float inputValue = momentumSlider.value;
		for (int i = 0; i < flock.Count; i++) {
			flock[i].currentHeadingWeight = inputValue;
			//print ( "speed = " + inputValue );
		}
	}

	// speed slider
	public void SetSpeed(){
		float inputValue = speedSlider.value;
		for (int i = 0; i < flock.Count; i++) {
			flock[i].speed = inputValue;
			//print ( "speed = " + inputValue );
		}
	}

	// separation slider
	public void SetSeparation(){
		float inputValue = separationSlider.value;
		for (int i = 0; i < flock.Count; i++) {
			flock[i].separationWeight = new Vector3(inputValue, inputValue, inputValue);
			//print ( "separationWeight = " + inputValue );
		}
	}

	// alignment slider
	public void SetAlignment(){
		float inputValue = alignmentSlider.value;
		for (int i = 0; i < flock.Count; i++) {
			flock[i].alignmentWeight = new Vector3(inputValue, inputValue, inputValue);
			//print ( "alignmentWeight = " + inputValue );
		}
	}

	// cohesion slider
	public void SetCohesion(){
		float inputValue = cohesionSlider.value;
		for (int i = 0; i < flock.Count; i++) {
			flock[i].cohesionWeight = new Vector3(inputValue, inputValue, inputValue);
			//print ( "cohesionWeight = " + inputValue );
		}
	}

	// glitch camera button
	public void GlitchCamera(){
		camera.clearFlags = CameraClearFlags.Depth;

		FogAnimator fog = camera.GetComponent<FogAnimator>();
		fog.enabled = true;
		RenderSettings.fog = true;

		ScreenshotManager screenshotManager = camera.GetComponent<ScreenshotManager> ();
		screenshotManager.Paint ();
	}

	// regular camera button
	public void RegularCamera(){
		camera.clearFlags = CameraClearFlags.Skybox;

		FogAnimator fog = camera.GetComponent<FogAnimator>();
		fog.enabled = false;
		RenderSettings.fog = false;
	}

	void GetFlock () {
		Boid[] boids = FindObjectsOfType(typeof(Boid)) as Boid[];
		for ( int i = 0; i < boids.Length; i++ ) {
			flock.Add(boids[i]);
		}
	}
}


