using UnityEngine;
using System.Collections;

public class ExplosionManager : MonoBehaviour {


	private ParticleSystem ps;

	void Start ()
	{
		ps = GetComponent<ParticleSystem>();
	}
	
	public void Update() 
	{
		if(ps)
		{
			if(!ps.IsAlive())
			{
				Destroy(gameObject);
			}
		}
	}
}
