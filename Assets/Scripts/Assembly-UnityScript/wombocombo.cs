using System;
using UnityEngine;

[Serializable]
public class wombocombo : MonoBehaviour
{
	public Texture txtr1;

	public Texture txtr2;

	public Texture txtr3;

	public Texture txtr4;

	public Texture txtr5;

	public AudioClip pickupSound;

	public AudioClip lostSound;

	public GameObject illumpart;

	private float counter;

	private GameObject player;

	private GameObject scoreGUI;

	private bool lostMultiplyer;

	private bool grabbedPickup;

	AudioSource source;
	public virtual void Start()
	{
		player = GameObject.Find("Player");
		scoreGUI = GameObject.Find("LowerLCD/Canvas/score");
	}

	public virtual void Update()
	{
		counter += Time.deltaTime * 8f;
		if (!(counter <= 0f) && !(counter >= 1f) && GetComponent<Renderer>().material.mainTexture != txtr1)
		{
			GetComponent<Renderer>().material.mainTexture = txtr1;
		}
		if (!(counter <= 1f) && !(counter >= 2f) && GetComponent<Renderer>().material.mainTexture != txtr2)
		{
			GetComponent<Renderer>().material.mainTexture = txtr2;
		}
		if (!(counter <= 2f) && !(counter >= 3f) && GetComponent<Renderer>().material.mainTexture != txtr3)
		{
			GetComponent<Renderer>().material.mainTexture = txtr3;
		}
		if (!(counter <= 3f) && !(counter >= 4f) && GetComponent<Renderer>().material.mainTexture != txtr4)
		{
			GetComponent<Renderer>().material.mainTexture = txtr4;
		}
		if (!(counter <= 4f) && !(counter >= 5f) && GetComponent<Renderer>().material.mainTexture != txtr5)
		{
			GetComponent<Renderer>().material.mainTexture = txtr5;
		}
		if (!(counter <= 5f))
		{
			counter = 0f;
		}
		if (player != null && !(player.transform.position.x <= transform.position.x + 3f) && !lostMultiplyer && !grabbedPickup)
		{
			scoreGUI.SendMessage("lostMultiplyer", SendMessageOptions.DontRequireReceiver);
			lostMultiplyer = true;
		}
	}

	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" && !grabbedPickup)
		{
			UnityEngine.Object.Instantiate(illumpart, transform.position, Quaternion.identity);
			grabbedPickup = true;
			getMultiplyer();
		}
	}

	public virtual void getMultiplyer()
	{
		scoreGUI.SendMessage("addMultiplyer", SendMessageOptions.DontRequireReceiver);
		source.clip = pickupSound;
		source.Play();
		GetComponent<Renderer>().enabled = false;
	}

	public virtual void Main()
	{
	}
}
