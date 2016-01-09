using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoidsJoystickController : MonoBehaviour {
	public float x = 0.0f;
	public float y = 0.0f;
	public float z = 0.0f;
	public List<Boid> flock = new List<Boid>();

	// Use this for initialization
	void Start () {
		GetFlock ();
	}

	void Awake () {
		//SetSpeed ();
		SetSeparation ();
		SetAlignment ();
		SetCohesion ();
	}
	
	// Update is called once per frame
	void Update () {
		//print (Input.GetAxis("Throttle"));
		if(Input.GetButton("Fire1")){
			SetSpeed ();
			SetSeparation ();
			SetAlignment ();
			SetCohesion ();
		}

		if(Input.GetButtonDown("Fire2")){
			print ("Reset Scene");
			Application.LoadLevel (Application.loadedLevelName);
		}
	}

	void GetFlock () {
		Boid[] boids = FindObjectsOfType(typeof(Boid)) as Boid[];
		for ( int i = 0; i < boids.Length; i++ ) {
			flock.Add(boids[i]);
		}
	}

	// speed slider
	public void SetSpeed(){
		float inputValue = Input.GetAxis ("Throttle");
		inputValue = (inputValue - 1.0f) / 2.0f *-50;
		for (int i = 0; i < flock.Count; i++) {
			flock[i].speed = inputValue;
			//print ( "speed = " + inputValue );
		}
	}
	
	// separation slider
	public void SetSeparation(){
		float inputValue = Input.GetAxis ("Horizontal");
		inputValue = (inputValue + 1.0f) / 2.0f;
		for (int i = 0; i < flock.Count; i++) {
			flock[i].separationWeight = new Vector3(inputValue, inputValue, inputValue);
			//print ( "separationWeight = " + inputValue );
		}
	}
	
	// alignment slider
	public void SetAlignment(){
		float inputValue = Input.GetAxis ("Twist");
		inputValue = (inputValue + 1.0f) / 2.0f;
		for (int i = 0; i < flock.Count; i++) {
			flock[i].alignmentWeight = new Vector3(inputValue, inputValue, inputValue);
			//print ( "alignmentWeight = " + inputValue );
		}
	}
	
	// cohesion slider
	public void SetCohesion(){
		float inputValue = Input.GetAxis ("Vertical");
		inputValue = (inputValue - 1.0f) / 2.0f *-1;
		for (int i = 0; i < flock.Count; i++) {
			flock[i].cohesionWeight = new Vector3(inputValue, inputValue, inputValue);
			//print ( "cohesionWeight = " + inputValue );
		}
	}
}
