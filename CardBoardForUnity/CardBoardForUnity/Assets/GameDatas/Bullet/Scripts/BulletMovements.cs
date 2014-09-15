using UnityEngine;
using System.Collections;

public class BulletMovements : MonoBehaviour {

	[SerializeField]
	private float speed = 10.0f;

	[SerializeField]
	private GameObject explosionObject = null;

	void Update()
	{
		// transform.up * speed * Time.deltaTime
		gameObject.rigidbody.AddForce(transform.up * speed * Time.deltaTime);

		if (gameObject.transform.position.z > 30) 
		{
			Destroy(gameObject);
		}
	}

	
	void OnCollisionEnter(   Collision   collision  )
	{
		//Debug.Log(  "OnCollisionEnter : " + collision.gameObject.name  );

		if (collision.gameObject.name.Contains ("asteroid"))
		{

			GameObject explosionParticleClone = Instantiate(explosionObject, collision.gameObject.transform.position, collision.gameObject.transform.rotation ) as GameObject;
			GameParameters.GetInstance().SubDebriNum();

			Destroy(gameObject);
			Destroy (collision.gameObject);
		}


	}
}
