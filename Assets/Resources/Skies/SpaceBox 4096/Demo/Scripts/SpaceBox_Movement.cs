using UnityEngine;
using System.Collections;

public class SpaceBox_Movement : MonoBehaviour {
	public float speedMultiplier = 100f;

	void Start () {
	
	}
	
	void Update () {
		transform.Translate(Input.GetAxis ("Horizontal") * Time.deltaTime * speedMultiplier,0, Input.GetAxis ("Vertical")* Time.deltaTime * speedMultiplier);
	}
}
