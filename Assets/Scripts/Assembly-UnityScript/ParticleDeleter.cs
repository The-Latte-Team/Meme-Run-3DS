using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDeleter : MonoBehaviour {

	private GameObject cam;
	
	void Start () {
		cam = GameObject.Find("Main Camera");
	}
	
	void Update () {
		if (!(transform.position.x >= cam.transform.position.x - 32f))
		{
			UnityEngine.Object.Destroy(gameObject);
		}
	}
}
