using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Name your classes better. If this is only for difficulty, call it DifficultyTimer. If it's a generic timer, remove the difficulty field
public class AddTimer : MonoBehaviour
{
	private float t;
	public Text textAddtimer;
	public static float difficulty = 0.3f;
	public static float SpawnTime = 1.5f;
	// Update is called once per frame
	void Update()
	{
		t += Time.deltaTime;
		string minutes = ((int)t / 60).ToString();
		string seconds = (t % 60).ToString("F1");
		textAddtimer.text = minutes + ":" + seconds;
		Debug.Log(t);
		float minutesPassed = t / 60;
		if (minutesPassed > 4)
		{
			SpawnTime = 0.4f;
			difficulty = 1.2f;
			StartCoroutine(SpawnTimeLess());
		}
		else if (minutesPassed > 3)
		{
			SpawnTime = 0.6f;
			difficulty = 0.9f;
		}
		else if (minutesPassed > 2)
		{
			SpawnTime = 1f;
			difficulty = 0.6f;
		}
	}

	IEnumerator SpawnTimeLess()
    {
		while (SpawnTime >= 0.4 && SpawnTime <= 0)
		{
			int r = Random.Range(1, 6);
			yield return new WaitForSeconds(r);
			SpawnTime -= 0.02f;
		}
        if (SpawnTime <= 0)
        {
			StopCoroutine(SpawnTimeLess());				
        }
	}
}