using UnityEngine;
using System.Collections;

public class DebrisMaker : MonoBehaviour {
	

	
	[SerializeField]
	private GameObject debriObject1 = null;
	[SerializeField]
	private GameObject debriObject2 = null;
	[SerializeField]
	private GameObject debriObject3 = null;




	private static DebrisMaker _instance = null;
	public static DebrisMaker GetInstance()
	{
		return _instance;
	}

	void Start ()
	{
		if (_instance == null)
		{
			_instance = this;
		}		
		else
		{
			Destroy (gameObject);
		}
	}



	public void DebrisMake()
	{
		int debriMax = GameParameters.GetInstance().GetDebriMax();
		for (int i = 0; i < debriMax; ++i)
		{
			int ranNum = Random.Range (0, 3);
			GameObject debri = null;
			
			switch (ranNum)
			{
			case 0:
				debri = debriObject1;
				break;
			case 1:
				debri = debriObject2;
				break;
			case 2:
				debri = debriObject3;
				break;
			}
			
			GameObject debriClone = Instantiate(debri, new Vector3(Random.Range(-11.0f,11.0f), Random.Range(-11.0f,11.0f), Random.Range(-11.0f,11.0f)), Quaternion.identity ) as GameObject;
		}
	}


}
