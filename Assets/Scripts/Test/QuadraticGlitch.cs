using UnityEngine;
using System.Collections;

public class QuadraticGlitch : MonoBehaviour {

	public Color c1 = Color.yellow;
	public Color c2 = Color.red;
	public int lenghtOfLineRenderer = 20;
	
	void Start () {
		LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
		lineRenderer.material = new Material( Shader.Find("Particles/Additive") );
		lineRenderer.SetColors (c1, c2);
		lineRenderer.SetWidth ( 0.2f, 0.2f );
		lineRenderer.SetVertexCount ( lenghtOfLineRenderer );
	}
	
	void Update () {
		LineRenderer lineRenderer = GetComponent<LineRenderer>();
		int i = 0;
		while ( i < lenghtOfLineRenderer ) {
			//Vector3 pos = new Vector3( i * 0.5f, Mathf.Sin( i + Time.time), 0 );
			float y = SolveQuadraticEquation( 1, 2, 3, i );
			Vector3 pos = new Vector3( i * 5.0f, y, 0 );
			lineRenderer.SetPosition( i, pos);
			i++;
		}
	}

	float SolveQuadraticEquation( float a, float b, float c, float x ) {
		float y;

		y = (a * Mathf.Pow (x, 2)) + (b * x) + c;

		return y;
	}

}











