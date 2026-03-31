using System;
using UnityEngine;

[Serializable]
public class cloudparallax : MonoBehaviour
{
	public float speed;

	public int frameSpeed;

	public Texture run1;

	public Texture run2;

	public Texture run3;

	public Texture run4;

	public Texture run5;

	public Texture run6;

	public Texture run7;

	public Texture run8;

	public Texture run9;

	public Texture run10;

	private GameObject cam;

	private float counter;

	Rigidbody rb;
	Renderer renderer;
	public cloudparallax()
	{
		speed = 8f;
		frameSpeed = 10;
	}

	public virtual void Start()
	{
		renderer = GetComponent<Renderer>();
		rb = GetComponent<Rigidbody>();
		cam = GameObject.Find("Main Camera");
		speed += UnityEngine.Random.Range(-1, 1);
	}

	public virtual void Update()
	{
		counter += Time.deltaTime * (float)frameSpeed;
		Vector3 velocity = rb.velocity;
		velocity.x = speed;
		rb.velocity = velocity;
		if (!(transform.position.x >= cam.transform.position.x - 22f))
		{
			float x2 = transform.position.x + 44f;
			Vector3 position = transform.position;
			float num2 = (position.x = x2);
			Vector3 vector3 = (transform.position = position);
		}
		if (!(counter <= 0f) && !(counter >= 1f) && renderer.material.mainTexture != run1)
		{
			renderer.material.mainTexture = run1;
		}
		if (!(counter <= 1f) && !(counter >= 2f) && renderer.material.mainTexture != run2)
		{
			renderer.material.mainTexture = run2;
		}
		if (!(counter <= 2f) && !(counter >= 3f) && renderer.material.mainTexture != run3)
		{
			renderer.material.mainTexture = run3;
		}
		if (!(counter <= 3f) && !(counter >= 4f) && renderer.material.mainTexture != run4)
		{
			renderer.material.mainTexture = run4;
		}
		if (!(counter <= 4f) && !(counter >= 5f) && renderer.material.mainTexture != run5)
		{
			renderer.material.mainTexture = run5;
		}
		if (!(counter <= 5f) && !(counter >= 6f) && renderer.material.mainTexture != run6)
		{
			renderer.material.mainTexture = run6;
		}
		if (!(counter <= 6f) && !(counter >= 7f) && renderer.material.mainTexture != run7)
		{
			renderer.material.mainTexture = run7;
		}
		if (!(counter <= 7f) && !(counter >= 8f) && renderer.material.mainTexture != run8)
		{
			renderer.material.mainTexture = run8;
		}
		if (!(counter <= 8f) && !(counter >= 9f) && renderer.material.mainTexture != run9)
		{
			renderer.material.mainTexture = run9;
		}
		if (!(counter <= 9f) && !(counter >= 10f) && renderer.material.mainTexture != run10)
		{
			renderer.material.mainTexture = run10;
		}
		if (!(counter <= 10f))
		{
			counter = 0f;
		}
	}

	public virtual void Main()
	{
	}
}
