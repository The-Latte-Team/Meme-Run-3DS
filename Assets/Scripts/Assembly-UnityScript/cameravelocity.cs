using System;
using UnityEngine;

[Serializable]
public class cameravelocity : MonoBehaviour
{
	private float speed;

	Rigidbody rb;

	public cameravelocity()
	{
		speed = 12f;
	}

	public virtual void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	public virtual void Update()
	{
		Vector3 velocity = rb.velocity;
		velocity.x = speed;
		rb.velocity = velocity;
	}

	public virtual void receiveSpeed(float theSpeed)
	{
		speed = theSpeed;
	}

	public virtual void Main()
	{
	}
}
