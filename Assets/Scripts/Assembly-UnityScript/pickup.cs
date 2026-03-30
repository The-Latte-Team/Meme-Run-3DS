using System;
using UnityEngine;

[Serializable]
public class pickup : MonoBehaviour
{
	public Texture txtr1;

	public Texture txtr2;

	public Texture wombo1;

	public Texture wombo2;

	public Texture wombo3;

	public Texture wombo4;

	public Texture wombo5;

	public AudioClip pickupSound;

	public AudioClip lostSound;

	public GameObject illumpart;

	private float counter;

	private GameObject player;

	public GameObject scoreGUI;

	private bool lostMultiplyer;

	private bool grabbedPickup;

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
		if (!(counter <= 2f))
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
		GetComponent<AudioSource>().PlayOneShot(pickupSound);
		GetComponent<Renderer>().enabled = false;
	}

	public virtual void Main()
	{
	}
}
