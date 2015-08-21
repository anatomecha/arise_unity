using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* Boids artificial life algorithm http://en.wikipedia.org/wiki/Boids
separation: steer to avoid crowding local flockmates
alignment: steer towards the average heading of local flockmates
cohesion: steer to move toward the average position (center of mass) of local flockmates
*/

public class Boid : MonoBehaviour {
	private Vector3 separationVector = new Vector3( 0, 0, 0 );
	private Vector3 alignmentVector = new Vector3( 0, 0, 0 );
	private Vector3 cohesionVector = new Vector3( 0, 0, 0 );
	private float separationWeight = 0.5f;
	private float alignmentWeight = 0.5f;
	private float cohesionWeight = 0.5f;
	public List<Boid> flock = new List<Boid>();


	void Start () {
		GetFlock ();
	}
	
	void Update () {

	}

	Vector3 Separate () {

	}

	Vector3 Alignment () {

	}

	Vector3 Cohesion () {

	}

	void GetFlock () {
		Boid[] boids = FindObjectsOfType(typeof(Boid)) as Boid[];
		for ( int i = 0; i < boids.Length; i++ ) {
			int id1 = boids[i].GetInstanceID();
			Boid boid = gameObject.GetComponent(typeof(Boid)) as Boid;
			int id2 = boid.GetInstanceID();
			
			if ( id1 != id2 ) { 
				flock.Add(boids[i]);
				print ( "me=" + gameObject.name + " adding=" + boids[i].name );
			}
		}
	}


}





/*
public class Boid : MonoBehaviour {
	private float speed = 1.0f;
	public List<Boid> flock = new List<Boid>();
	private float separationRadius = 5.0f;
	private Vector3 averageHeading = new Vector3( 0, 0, 0 );
	private Vector3 centerOfMass = new Vector3 (0, 0, 0);
	private Vector3 targetDir = new Vector3 ( 0, 0, 0);

	void Start () {

		GetFlock ();
	}
	
	void Update () {

		Think ();

		TakeAction ();

	}

	void Think () {

		// --- separation: steer to avoid crowding local flockmates

		// check for others within separationRadius
		for( int i=0; i<flock.Count; i++ ){
			float dist = Vector3.Distance( flock[i].transform.position, transform.position );

			if ( dist <= separationRadius ) {
				targetDir = flock[i].transform.position - transform.position;
				//float angle = Vector3.Angle( targetDir, transform.forward );

				//print( gameObject.name + " is too close to " + flock[i].name + " " + dist + " angle " + angle );


			}
		}

		// --- alignment: steer towards the average heading of local flockmates

		// --- cohesion: steer to move toward the average position (center of mass) of local flockmates

	}

	void TakeAction () {

		float step = speed * Time.deltaTime;

		// steer to avoid crowding local flockmates
		//transform.eulerAngles = Vector3.RotateTowards( transform.forward, -targetDir, step, 0.0F );
		//transform.position = Vector3.MoveTowards ( transform.position, new Vector3( 10, 10, 10), step );

		transform.Rotate ( targetDir );
		transform.Translate ( Vector3.forward * Time.deltaTime );
	}

	void GetFlock () {
		Boid[] boids = FindObjectsOfType(typeof(Boid)) as Boid[];
		for ( int i = 0; i < boids.Length; i++ ) {
			int id1 = boids[i].GetInstanceID();
			Boid boid = gameObject.GetComponent(typeof(Boid)) as Boid;
			int id2 = boid.GetInstanceID();

			if ( id1 != id2 ) { 
				flock.Add(boids[i]);
				print ( "me=" + gameObject.name + " adding=" + boids[i].name );
			}
		}
	}

}
*/

