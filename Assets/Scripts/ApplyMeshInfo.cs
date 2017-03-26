using UnityEngine;
using System.Collections.Generic;


public class ApplyMeshInfo : MonoBehaviour {
	[SerializeField]
	private List<MeshFilter> _cloneModels;

	[SerializeField]
	private CloneMeshInfo _cloneInfo;

	private Vector3[][] _vertices;
	private int[][] _triangles;
	private Vector2[][] _uv;
	private Mesh[] _meshes;
	private Vector3[] _pos;

	private void Update()
	{
		_vertices = _cloneInfo.GetVertices().ToArray();
		_triangles = _cloneInfo.GetTriangles().ToArray();
		_uv = _cloneInfo.GetUv().ToArray();
		_meshes = _cloneInfo.GetMesh().ToArray();
		_pos = _cloneInfo.GetPos().ToArray();

		for (int i = 0; i < _vertices.Length; i++)
		{
			_cloneModels[i].mesh.vertices = _vertices[i];
			_cloneModels[i].mesh.triangles = _triangles[i];
			_cloneModels[i].mesh.uv = _uv[i];
			_cloneModels[i].transform.position = _pos[i];
			_cloneModels[i].mesh = _meshes[i];

			for (int j = 0; j < _cloneModels[i].mesh.colors.Length; j++)
			{
				_cloneModels[i].mesh.colors[j] = new Color(_cloneModels[i].mesh.colors[j].r,
														   _cloneModels[i].mesh.colors[j].g,
														   _cloneModels[i].mesh.colors[j].b,
														   0.5f);
			}
		}
	}
}
