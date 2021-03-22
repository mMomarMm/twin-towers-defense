using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Name your classes better. If this is only for difficulty, call it DifficultyTimer. If it's a generic timer, remove the difficulty field
public class AddTimer : MonoBehaviour
{
	// No reason for this to be public
	private float t;

	public Text textAddtimer;

	// This does not need to be here
	// bool gameover;

	// Why is this static?
	public static float difficulty;

	// Start is called before the first frame update
	void Start()
	{
		// This is set by value. It does not change when GameManager updates
		// gameover = GameManager.gameover;
		// Not needed
		// timeStart = Time.time;
		difficulty = 0.3f;
	}

	// Update is called once per frame
	void Update()
	{
		// Superfluous
		//if (gameover != true)

		// Better to early escape than to nest, usually
		// Here we also add paused, since we don't want to update in that state
		if (GameManager.gameover || GameManager.paused)
			return;

		// Instead of subtracting the difference every time, we can just add the time difference since the last call
		t += Time.deltaTime;

		// This generates garbage every frame, I don't suggest doing this
		// Instead, the text update should be moved into its own script that updates at regular intervals, but not every frame.
		// This is left as an exercise to the reader
		string minutes = ((int)t / 60).ToString();
		string seconds = (t % 60).ToString("F1");
		textAddtimer.text = minutes + ":" + seconds;

		// Set it once instead of doing the math every time
		float minutesPassed = t / 60;

		// This was previously a "Pyramid of Doom"
		// Avoid nesting this much, especially when it's redundant like this.

		// It would be better to store these in a variable rather than hard-coding, but I can only do so much. A Piecewise function would do well here so that there's a direct correlation between time passed and difficulty
		// This too, is left as an exercise for the reader
		// Inversion for easier chaining
		if (minutesPassed > 4)
		{
			difficulty = 1.2f;
		}
		else if (minutesPassed > 3)
		{
			difficulty = 0.9f;
		}
		else if (minutesPassed > 2)
		{
			difficulty = 0.6f;
		}
	}
}