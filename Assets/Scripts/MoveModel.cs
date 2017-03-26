using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoveModel : MonoBehaviour {
	Vector3 mousePosition;
	Vector3 worldPoint;
	void Update()
	{
		mousePosition = Input.mousePosition;
		mousePosition.z = 10;
		//Debug.Log(mousePosition);

		worldPoint = Camera.main.ScreenToWorldPoint(mousePosition);
		//Debug.Log(worldPoint);
		worldPoint.z = 0;
		transform.position = worldPoint;
	}
}
