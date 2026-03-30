using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class score : MonoBehaviour
{
	public AudioClip gameOverSound;

	public AudioClip gameOverSound2;

	private int m_score;

	private float scoreCounter;

	private GameObject player;

	private bool checkPlayer;

	private int multiplyer;

	public score()
	{
		checkPlayer = true;
		multiplyer = 1;
	}

	public virtual void Start()
	{
		player = GameObject.Find("Player");
	}

	public virtual void Update()
	{
		if (player != null)
		{
			scoreCounter += 10f * Time.deltaTime * (float)multiplyer;
			m_score = (int)Mathf.Round(scoreCounter);
			if (multiplyer > 1)
			{
				GetComponent<Text>().text = "SWAG Points: " + m_score.ToString() + " X" + multiplyer.ToString();
			}
			else
			{
				GetComponent<Text>().text = "SWAG Points: " + m_score.ToString();
			}
		}
		else if (checkPlayer)
		{
			checkPlayer = false;
			GetComponent<AudioSource>().PlayOneShot(gameOverSound);
			GetComponent<AudioSource>().PlayOneShot(gameOverSound2);
			GetComponent<Text>().text = "SWAG Points: " + m_score.ToString();
			if (!((float)m_score <= PlayerPrefs.GetFloat("highscore")))
			{
				PlayerPrefs.SetFloat("highscore", m_score);
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
