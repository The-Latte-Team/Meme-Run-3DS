using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class flasher : MonoBehaviour
{
	public GameObject gameOverText;
	public GameObject gameOverTextLowerLCD;

	private bool gameOver;

	private bool isMenu;

	private GameObject player;

	public Image doubleFlash;

	GUITexture texture;

	public virtual void Start()
	{
		player = GameObject.Find("Player");
		if (player == null)
		{
			isMenu = true;
		}
		texture = GetComponent<GUITexture>();
		float a = 0.5f;
		Color color = texture.color;
		float num = (color.a = a);
		Color color2 = (texture.color = color);
		doubleFlash.color = color2;
	}

	public virtual void Update()
	{
		if (!isMenu)
		{
			if (!(texture.color.a <= 0f) && !gameOver)
			{
				float a = texture.color.a - Time.deltaTime / 2f;
				Color color = texture.color;
				float num = (color.a = a);
				Color color2 = (texture.color = color);
				doubleFlash.color = color2;
			}
			if (!(texture.color.a <= 0.35f) && gameOver)
			{
				float a2 = texture.color.a - Time.deltaTime / 2f;
				Color color4 = texture.color;
				float num2 = (color4.a = a2);
				Color color5 = (texture.color = color4);
				doubleFlash.color = color5;
			}
			if (!(texture.color.a > 0f) && texture.enabled && !gameOver)
			{
				texture.enabled = false;
				doubleFlash.enabled = false;
			}
			if (!(texture.color.a <= 0f) && !texture.enabled && !gameOver)
			{
				texture.enabled = true;
				doubleFlash.enabled = false;
			}
		}
		else if (!(texture.color.a <= 0.25f))
		{
			float a3 = texture.color.a - Time.deltaTime / 2f;
			Color color7 = texture.color;
			float num3 = (color7.a = a3);
			Color color8 = (texture.color = color7);
			doubleFlash.color = color8;
		}
	}

	public virtual void gameOverFlash()
	{
		float a = 0.5f;
		Color color = texture.color;
		float num = (color.a = a);
		Color color2 = (texture.color = color);
		doubleFlash.color = color2;
		doubleFlash.enabled = true;
		texture.enabled = true;
		gameOver = true;
		int num2 = 0;
		Vector3 position = transform.position;
		float num3 = (position.z = num2);
		Vector3 vector = (transform.position = position);
		gameOverText.SetActive(true);
		if(gameOverTextLowerLCD != null)
			gameOverTextLowerLCD.SetActive(true);
	}

	public virtual void Main()
	{
	}
}
