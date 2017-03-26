using UnityEngine;
using System.Collections;

public class Example : MonoBehaviour
{
	[SerializeField]
	MeshFilter _mesh;

	// Use this for initialization
	void Start ()
	{
		foreach(var a in _mesh.mesh.vertices)
		{
			Debug.Log("Vertices : " + a);
		}

		foreach(var a in _mesh.mesh.triangles)
		{
			Debug.Log("Triangles" + a);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
