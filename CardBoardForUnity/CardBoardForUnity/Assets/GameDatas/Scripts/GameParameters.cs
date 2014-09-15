using UnityEngine;
using System.Collections;

public class GameParameters : MonoBehaviour {

	[SerializeField]
	private int debriMax = 10;



	private bool isPlaying = false;
	private int leftDebrisNum = int.MaxValue;
	private int shootNum = 0;
	private float playTime = 0.0f;



	private static GameParameters _instance = null;
	public static GameParameters GetInstance()
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



	void Update ()
	{
		if (isPlaying)
		{
			playTime += Time.deltaTime;
		}

		if (leftDebrisNum < 1)
		{
			isPlaying = false;
		}
	}


	public void InitializeGame()
	{
		isPlaying = true;
		leftDebrisNum = debriMax;
		shootNum = 0;
		playTime = 0.0f;

		DebrisMaker.GetInstance().DebrisMake();
	}

	public int GetDebriMax()
	{
		return debriMax;
	}

	public void SubDebriNum()
	{
		--leftDebrisNum;
	}

	public int GetLeftDebrisNum()
	{
		return leftDebrisNum;
	}

	public void AddShootNum()
	{
		if (isPlaying)
		{
			++shootNum;
		}
		else
		{
			InitializeGame();
		}
	}

	public bool IsPlaying()
	{
		return isPlaying;
	}

	public float GetPlayTime()
	{
		return playTime;
	}

	public int GetShootNum()
	{
		return shootNum;
	}

}
