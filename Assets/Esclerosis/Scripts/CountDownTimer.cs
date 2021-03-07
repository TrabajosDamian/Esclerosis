using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
	public Text timerText;
	private void Start()
	{
		timerText = this.gameObject.GetComponent<Text>();

	}

	void Update()
	{

		string minutes = Mathf.Floor(GlobalManager.instance.time / 60).ToString("00");
		string seconds = (GlobalManager.instance.time % 60).ToString("00");
		string fraction = ((GlobalManager.instance.time * 100) % 100).ToString("000");


		timerText.text = "Tiempo: " + minutes + ":" + seconds + ":" + fraction;


		if (Mathf.Floor(GlobalManager.instance.time / 60) < 5)
			timerText.color = Color.red;
	}
}
