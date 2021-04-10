﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Name your classes better. If this is only for difficulty, call it DifficultyTimer. If it's a generic timer, remove the difficulty field
public class AddTimer : MonoBehaviour
{
	private float t;
	public Text textAddtimer;
	public static float difficulty = 0.3f;
	public static float SpawnRate = 1;
	// Update is called once per frame
	void Update()
	{
		t += Time.deltaTime;

		string minutes = ((int)t / 60).ToString();
		string seconds = (t % 60).ToString("F1");
		textAddtimer.text = minutes + ":" + seconds;
		float minutesPassed = t / 60;
		if (minutesPassed > 4)
		{
			SpawnRate = 6f;
			difficulty = 1.2f;
		}
		else if (minutesPassed > 3)
		{
			SpawnRate = 4f;
			difficulty = 0.9f;
		}
		else if (minutesPassed > 2)
		{
			SpawnRate = 2f;
			difficulty = 0.6f;
		}
	}
}