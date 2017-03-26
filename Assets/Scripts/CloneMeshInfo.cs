using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// モデル複製用の処理クラス。
/// </summary>
public class CloneMeshInfo : MonoBehaviour {
	[SerializeField]
	private MeshFilter _meshFilter;

	private const int _afterImageNum = 5;

	private Queue<Vector3[]> _vertices;
	private Queue<Vector3> _pos;
	private Queue<int[]> _triangles;
	private Queue<Vector2[]> _uv;

	private Queue<Mesh> _mesh;

	// Use this for initialization
	private void Start ()
	{
		_vertices = new Queue<Vector3[]>();
		_pos = new Queue<Vector3>();
		_triangles = new Queue<int[]>();
		_uv = new Queue<Vector2[]>();

		_mesh = new Queue<Mesh>();

		StartCoroutine(AddMeshInfo());
	}
	
	// Update is called once per frame
	private void Update ()
	{
		
	}

	/// <summary>
	/// メッシュデータをキューに格納。
	/// </summary>
	/// <returns></returns>
	private IEnumerator AddMeshInfo()
	{
		while (true)
		{
			EnqueueMeshInfo();
			if (_vertices.Count > _afterImageNum)
			{
				DequeueMeshInfo();
			}
			Debug.Log(_vertices.Count);
			yield return new WaitForSeconds(0.04f);
		}
	}

	/// <summary>
	/// メッシュデータをキューに格納、内部処理。
	/// </summary>
	private void EnqueueMeshInfo()
	{
		_vertices.Enqueue(_meshFilter.mesh.vertices);
		_triangles.Enqueue(_meshFilter.mesh.triangles);
		_uv.Enqueue(_meshFilter.mesh.uv);

		_pos.Enqueue(transform.position);
		_mesh.Enqueue(_meshFilter.mesh);
	}

	/// <summary>
	/// 残像数の上限を超えていたらキューを削除。
	/// </summary>
	private void DequeueMeshInfo()
	{
		_vertices.Dequeue();
		_triangles.Dequeue();
		_uv.Dequeue();
		_pos.Dequeue();

		_mesh.Dequeue();
	}

	public Queue<Vector3[]> GetVertices() { return _vertices; }
	public Queue<int[]> GetTriangles() { return _triangles; }
	public Queue<Vector2[]> GetUv() { return _uv; }
	public Queue<Vector3> GetPos() { return _pos; }

	public Queue<Mesh> GetMesh() { return _mesh; }
}
