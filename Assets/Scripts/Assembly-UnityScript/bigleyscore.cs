using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class bigleyscore : MonoBehaviour
{
	public AudioClip gameOverSound;

	public AudioClip gameOverSound2;

	private int score;

	private float scoreCounter;

	private GameObject player;

	private bool checkPlayer;

	private int multiplyer;

	Text text;

	public AudioSource source;
	public AudioSource source2;

	public bigleyscore()
	{
		checkPlayer = true;
		multiplyer = 1;
	}

	public virtual void Start()
	{
		player = GameObject.Find("Bigley");
		text = GetComponent<Text>();
	}

	public virtual void Update()
	{
		if (player != null)
		{
			scoreCounter += 10f * Time.deltaTime * (float)multiplyer;
			score = (int)Mathf.Round(scoreCounter);
			if (multiplyer > 1)
			{
				text.text = "SWAG Points: " + score.ToString() + " X" + multiplyer.ToString();
			}
			else
			{
				text.text = "SWAG Points: " + score.ToString();
			}
		}
		else if (checkPlayer)
		{
			checkPlayer = false;
			source.clip = gameOverSound;
			source2.clip = gameOverSound2;

			source.Play();
			source2.Play();
			
			text.text = "SWAG Points: " + score.ToString();
			if (!((float)score <= PlayerPrefs.GetFloat("highscore")))
			{
				PlayerPrefs.SetFloat("highscore", score);
			}
		}
	}

	public virtual void addMultiplyer()
	{
		multiplyer++;
	}

	public virtual void lostMultiplyer()
	{
		multiplyer = 1;
	}

	public virtual void Main()
	{
	}
}
