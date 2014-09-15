using UnityEngine;
using System.Collections;

public class DebriMovements : MonoBehaviour {

	private float speed = 0.0f;
	
	void Start ()
	{
		speed = Random.Range (10.0f, 30.0f);
	}
	
	
	void Update ()
	{
		transform.RotateAround(Vector3.zero, new Vector3(1.0f, 1.0f, 1.0f), speed * Time.deltaTime);
	}
}
