using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	[SerializeField]
	private GUIText timeText = null;
	[SerializeField]
	private GUIText endText = null;


	void Start ()
	{
		GameParameters.GetInstance().InitializeGame();
	}


	void Update ()
	{
		bool isPlaying = GameParameters.GetInstance().IsPlaying();
		float playTime = GameParameters.GetInstance().GetPlayTime();

		if (isPlaying)
		{
			endText.text = "";
			timeText.text = playTime.ToString("00.00");
		}
		else
		{
			int shootNum = GameParameters.GetInstance().GetShootNum();
			timeText.text = "";
			endText.text = "Clear! \n " + playTime.ToString("00.00") + "\n" + shootNum + " Shots! \n" + "Shot to Restart";
		}
	}


}
