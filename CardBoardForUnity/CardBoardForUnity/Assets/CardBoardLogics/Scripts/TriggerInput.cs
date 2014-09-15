using UnityEngine;
using System.Collections;

public class TriggerInput : MonoBehaviour {

	[SerializeField]
	private GameObject dummyGunObject = null;
	
	[SerializeField]
	private GameObject bulletObject = null;
	
	void Update()
	{	
		if ( Input.GetButtonDown("Fire1") )
		{
			Shot();
		}
	}

	void GetTriggerEvent()
	{
		Shot();
	}

	private void Shot()
	{
		GameObject bullet = Instantiate(bulletObject, dummyGunObject.transform.position, dummyGunObject.transform.rotation) as GameObject;
		GameParameters.GetInstance().AddShootNum();
	}

}
