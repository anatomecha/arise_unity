using UnityEngine;
using System.Collections;

[AddComponentMenu("Rendering/SpaceBox ST")]
public class SpaceBoxST : MonoBehaviour {

	private MeshFilter _meshFilter;
	private Mesh _mesh;	
	private Transform _spaceBoxST;
	public Material material;

	void Start () {
		_spaceBoxST = new GameObject("SpaceBoxST").transform;
		_spaceBoxST.gameObject.hideFlags = HideFlags.HideAndDontSave;
		_spaceBoxST.parent = transform;
		_spaceBoxST.localPosition = Vector3.zero;
		_meshFilter = _spaceBoxST.gameObject.GetComponent<MeshFilter>();
		if (_meshFilter == null) {
			_meshFilter = _spaceBoxST.gameObject.AddComponent<MeshFilter>();
		}
		if (_spaceBoxST.gameObject.GetComponent<MeshRenderer>() == null) _spaceBoxST.gameObject.AddComponent<MeshRenderer>();
		
		_meshFilter.mesh = Create ();
		_spaceBoxST.gameObject.GetComponent<Renderer>().material = material;		
	}
	
	void LateUpdate() {
		_spaceBoxST.transform.rotation = Quaternion.identity;
	}
	
	void Update () {
		
	}
	
	
	private Mesh Create(float length = 1f) {
		Mesh mesh = new Mesh();

		#region Vertices
		Vector3 p0 = new Vector3( -length * .5f,	-length * .5f, length * .5f );
		Vector3 p1 = new Vector3( length * .5f, 	-length * .5f, length * .5f );
		Vector3 p2 = new Vector3( length * .5f, 	-length * .5f, -length * .5f );
		Vector3 p3 = new Vector3( -length * .5f,	-length * .5f, -length * .5f );	
		
		Vector3 p4 = new Vector3( -length * .5f,	length * .5f,  length * .5f );
		Vector3 p5 = new Vector3( length * .5f, 	length * .5f,  length * .5f );
		Vector3 p6 = new Vector3( length * .5f, 	length * .5f,  -length * .5f );
		Vector3 p7 = new Vector3( -length * .5f,	length * .5f,  -length * .5f );
		
		Vector3[] vertices = new Vector3[] {
			p0, p1, p2, p3,
			p7, p4, p0, p3,
			p4, p5, p1, p0,
			p6, p7, p3, p2,
			p5, p6, p2, p1,
			p7, p6, p5, p4
		};
		#endregion
		
		#region Normales
		Vector3 up 	= Vector3.up;
		Vector3 down 	= Vector3.down;
		Vector3 front 	= Vector3.forward;
		Vector3 back 	= Vector3.back;
		Vector3 left 	= Vector3.left;
		Vector3 right 	= Vector3.right;
		
		Vector3[] normales = new Vector3[] {
			down, down, down, down,
			left, left, left, left,
			front, front, front, front,
			back, back, back, back,
			right, right, right, right,
			up, up, up, up
		};
		#endregion	
		
		#region UVs
		Vector2[] uvs = new Vector2[vertices.Length];
		float _uvPaddingPixels = 8.0f;
		float _uvPadding = _uvPaddingPixels / 4096.0f;
		float cols = 3.0f;
		float rows = 2.0f;
		float _uvTextureWidth = ((4096.0f - (_uvPaddingPixels * 2.0f)) / cols) / 4096.0f;
		float _uvTextureHeight = ((4096.0f - (_uvPaddingPixels * 4.0f)) / rows) / 4096.0f;

		uvs = new Vector2[] {
			// Down
			new Vector2(_uvPadding + _uvTextureWidth * 2, _uvPadding*3 + _uvTextureHeight), 
			new Vector2(_uvPadding + _uvTextureWidth * 2, _uvPadding*3 + _uvTextureHeight*2),
			new Vector2(_uvPadding + _uvTextureWidth * 3, _uvPadding*3 + _uvTextureHeight*2), 
			new Vector2(_uvPadding + _uvTextureWidth * 3, _uvPadding*3 + _uvTextureHeight),
			
			// Left
			new Vector2(_uvPadding + _uvTextureWidth * 2, _uvPadding + _uvTextureHeight),
			new Vector2(_uvPadding + _uvTextureWidth*3, _uvPadding + _uvTextureHeight), 
			new Vector2(_uvPadding + _uvTextureWidth*3, _uvPadding),
			new Vector2(_uvPadding + _uvTextureWidth * 2, _uvPadding), 
			
			// Front
			new Vector2(_uvPadding + _uvTextureWidth, _uvPadding*3 + _uvTextureHeight), 
			new Vector2(_uvPadding + _uvTextureWidth, _uvPadding*3 + _uvTextureHeight*2),
			new Vector2(_uvPadding + _uvTextureWidth + _uvTextureWidth, _uvPadding*3 + _uvTextureHeight*2), 
			new Vector2(_uvPadding + _uvTextureWidth + _uvTextureWidth, _uvPadding*3 + _uvTextureHeight),
			
			// Back
			
			new Vector2(_uvPadding + _uvTextureWidth, _uvPadding + _uvTextureHeight),
			new Vector2(_uvPadding + _uvTextureWidth + _uvTextureWidth, _uvPadding + _uvTextureHeight), 
			new Vector2(_uvPadding + _uvTextureWidth + _uvTextureWidth, _uvPadding),
			new Vector2(_uvPadding + _uvTextureWidth, _uvPadding), 				
			// Right
			new Vector2(_uvPadding, _uvPadding + _uvTextureHeight),
			new Vector2(_uvPadding + _uvTextureWidth, _uvPadding + _uvTextureHeight), 
			new Vector2(_uvPadding + _uvTextureWidth, _uvPadding),
			new Vector2(_uvPadding, _uvPadding), 
			
			// Up
			new Vector2(_uvPadding, _uvPadding*3 + _uvTextureHeight), 
			new Vector2(_uvPadding, _uvPadding*3 + _uvTextureHeight*2),
			new Vector2(_uvPadding + _uvTextureWidth, _uvPadding*3 + _uvTextureHeight*2), 
			new Vector2(_uvPadding + _uvTextureWidth, _uvPadding*3 + _uvTextureHeight),
			
		};
		#endregion

		
		#region Triangles
		int[] triangles = new int[]
		{
			// Bottom
			0, 1, 3,
			1, 2, 3,			
			
			// Left
			0 + 4 * 1, 1 + 4 * 1, 3 + 4 * 1,
			1 + 4 * 1, 2 + 4 * 1, 3 + 4 * 1,
			
			// Front
			0 + 4 * 2, 1 + 4 * 2, 3 + 4 * 2,
			1 + 4 * 2, 2 + 4 * 2, 3 + 4 * 2,
			
			// Back
			0 + 4 * 3, 1 + 4 * 3, 3 + 4 * 3,
			1 + 4 * 3, 2 + 4 * 3, 3 + 4 * 3,
			
			// Right
			0 + 4 * 4, 1 + 4 * 4, 3 + 4 * 4,
			1 + 4 * 4, 2 + 4 * 4, 3 + 4 * 4,
			
			// Top
			0 + 4 * 5, 1 + 4 * 5, 3 + 4 * 5,
			1 + 4 * 5, 2 + 4 * 5, 3 + 4 * 5,

		};
		#endregion
		
		mesh.vertices = vertices;
		mesh.normals = normales;
		mesh.uv = uvs;
		mesh.triangles = triangles;
		
		mesh.RecalculateBounds();
		mesh.Optimize();

		return mesh;
	}
	
}
