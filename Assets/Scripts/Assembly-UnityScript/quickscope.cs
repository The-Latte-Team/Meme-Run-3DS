using System;
using UnityEngine;

[Serializable]
public class quickscope : MonoBehaviour
{
	public Texture quk1;

	public Texture quk2;

	public Texture quk3;

	public Texture quk4;

	public Texture quk5;

	public Texture quk6;

	public Texture quk7;

	public Texture quk8;

	public Texture quk9;

	public Texture quk10;

	public Texture quk11;

	public Texture quk12;

	public Texture quk13;

	public Texture quk14;

	private float counter;

	GameObject cam;

	public virtual void Start()
	{
		cam = GameObject.Find("Main Camera");
		transform.Rotate(new Vector3(0f, 0f, 0f));
		transform.Translate(new Vector3(-5f, 5f, 0f));
	}

	public virtual void Update()
	{
		counter += Time.deltaTime * 30f;
		if (!(counter <= 0f) && !(counter >= 1f) && GetComponent<Renderer>().material.mainTexture != quk1)
		{
			GetComponent<Renderer>().material.mainTexture = quk1;
		}
		if (!(counter <= 1f) && !(counter >= 2f) && GetComponent<Renderer>().material.mainTexture != quk2)
		{
			GetComponent<Renderer>().material.mainTexture = quk2;
		}
		if (!(counter <= 2f) && !(counter >= 3f) && GetComponent<Renderer>().material.mainTexture != quk3)
		{
			GetComponent<Renderer>().material.mainTexture = quk3;
		}
		if (!(counter <= 3f) && !(counter >= 4f) && GetComponent<Renderer>().material.mainTexture != quk4)
		{
			GetComponent<Renderer>().material.mainTexture = quk4;
		}
		if (!(counter <= 4f) && !(counter >= 5f) && GetComponent<Renderer>().material.mainTexture != quk5)
		{
			GetComponent<Renderer>().material.mainTexture = quk5;
		}
		if (!(counter <= 5f) && !(counter >= 6f) && GetComponent<Renderer>().material.mainTexture != quk6)
		{
			GetComponent<Renderer>().material.mainTexture = quk6;
		}
		if (!(counter <= 6f) && !(counter >= 7f) && GetComponent<Renderer>().material.mainTexture != quk7)
		{
			GetComponent<Renderer>().material.mainTexture = quk7;
		}
		if (!(counter <= 8f) && !(counter >= 9f) && GetComponent<Renderer>().material.mainTexture != quk8)
		{
			GetComponent<Renderer>().material.mainTexture = quk8;
		}
		if (!(counter <= 9f) && !(counter >= 10f) && GetComponent<Renderer>().material.mainTexture != quk9)
		{
			GetComponent<Renderer>().material.mainTexture = quk9;
		}
		if (!(counter <= 10f) && !(counter >= 11f) && GetComponent<Renderer>().material.mainTexture != quk10)
		{
			GetComponent<Renderer>().material.mainTexture = quk10;
		}
		if (!(counter <= 11f) && !(counter >= 12f) && GetComponent<Renderer>().material.mainTexture != quk11)
		{
			GetComponent<Renderer>().material.mainTexture = quk11;
		}
		if (!(counter <= 12f) && !(counter >= 13f) && GetComponent<Renderer>().material.mainTexture != quk12)
		{
			GetComponent<Renderer>().material.mainTexture = quk12;
		}
		if (!(counter <= 13f) && !(counter >= 14f) && GetComponent<Renderer>().material.mainTexture != quk13)
		{
			GetComponent<Renderer>().material.mainTexture = quk13;
		}
		if (!(counter <= 14f) && !(counter >= 15f) && GetComponent<Renderer>().material.mainTexture != quk14)
		{
			GetComponent<Renderer>().material.mainTexture = quk14;
		}

		if (!(transform.position.x >= cam.transform.position.x - 32f))
		{
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	public virtual void Main()
	{
	}
}
