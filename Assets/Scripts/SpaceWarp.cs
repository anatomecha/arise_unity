using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpaceWarp : MonoBehaviour {

	public List<GameObject> axioms = new List<GameObject>();
	public Camera camera;
	private int maxCount = 80;
	private float maxDistance = 10f;
	private List<GameObject> stars = new List<GameObject>();
	private List<GameObject> newStars = new List<GameObject>();

	void Start () {
		camera.clearFlags = CameraClearFlags.SolidColor;

		for( int i=0; i<maxCount; i++ ) {
			GameObject star = CreateStar();
		}
	}

	GameObject CreateStar() {
		int randomAxiom = Random.Range( 0, 4);
		GameObject star = Instantiate( axioms[ randomAxiom ] );
		stars.Add(star);
		star.transform.parent = gameObject.transform;

		// set random position
		Vector2 newPosition = Random.insideUnitCircle * maxDistance;
		star.transform.position = new Vector3( newPosition.x, newPosition.y, 0f );
		
		return star;
	}

	void Update () {
		// y=mx+b where m is slope and b is y intercept
		// m=(y2-y1)/(x2-x1)

		if (Input.GetKey ("space")) {
			camera.clearFlags = CameraClearFlags.Depth;

			foreach (GameObject star in stars) {
				// move continuously on x, calculate y by making a line to the origin from last position
				float x = star.transform.localPosition.x;
				float y = star.transform.localPosition.y;
				float m = y / x;

				// calculate new x position
				float xOffset = 1.0f;
				if (x < 0) {
					xOffset = -1.0f;
				}
				float newX = x + xOffset;

				// calculate new y position
				float newY = m * (x + xOffset);

				star.transform.localPosition = new Vector3 (newX, newY, 0f);
			}

			// recycle stars that are out of bounds
			foreach( GameObject star in stars ) {

				float distance = Vector3.Distance( star.transform.localPosition, star.transform.parent.localPosition );
				if( distance > maxDistance ) {
					//Destroy(star);
					newStars.Add( CreateStar() );
				}
				else{
					newStars.Add( star );
				}
			}
			//stars.Clear();
			//stars = newStars;
			//newStars.Clear();
			print ("stars count = " + stars.Count);
		}

	}
}
