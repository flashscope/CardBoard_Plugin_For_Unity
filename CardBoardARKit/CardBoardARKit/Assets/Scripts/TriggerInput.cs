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
		// nothing in here now...
	}

}
