using System;
using UnityEngine;
#if UNITY_WIIU
using WiiU = UnityEngine.WiiU;
#endif

[Serializable]
public class playercontrols : MonoBehaviour
{
	public float speed;

	public float jumpHeight;

	public float fallLimit;

	public float recoverySpeed;

	public AudioClip jumpSound;

	public AudioClip backgroundMusic;

	public GameObject quickscope;

	public GameObject standing;

	public GameObject sliding;

	public AudioSource GamePadAudioSource;

	private RaycastHit hit;

	private RaycastHit hitUp;

	private float jumpCounter;

	private bool canJump;

	private GameObject cam;

	private GameObject flash;

	private float origSpeed;

	private bool isStanding;

#if UNITY_WIIU
	public WiiU.GamePad myGP;
	WiiU.GamePadState gamePad;
#endif

	public playercontrols()
	{
		speed = 14f;
		jumpHeight = 8f;
		fallLimit = -10f;
		recoverySpeed = 1.5f;
		isStanding = true;
	}

	public virtual void Start()
	{
		GetComponent<AudioSource>().Play();
		sliding.SetActive(false);
		flash = GameObject.Find("flash");
		cam = GameObject.Find("Main Camera");
		cam.SendMessage("receiveSpeed", speed);
		origSpeed = speed;
	}

	public virtual void Update()
	{
		#if UNITY_WIIU
		myGP = WiiU.GamePad.access;
		gamePad = myGP.state;
		#endif
		if (!(cam.transform.position.x <= transform.position.x + 1f) && speed == origSpeed)
		{
			speed = origSpeed + recoverySpeed;
		}
		if (!(cam.transform.position.x >= transform.position.x - 1f) && speed == origSpeed)
		{
			speed = origSpeed - recoverySpeed;
		}
		if (!(cam.transform.position.x <= transform.position.x - 1f) && !(cam.transform.position.x >= transform.position.x + 1f) && speed != origSpeed)
		{
			speed = origSpeed;
		}
		jumpCounter += Time.deltaTime;
		float x = speed;
		Vector3 velocity = GetComponent<Rigidbody>().velocity;
		float num = (velocity.x = x);
		Vector3 vector = (GetComponent<Rigidbody>().velocity = velocity);
		if (Physics.Raycast(transform.position - new Vector3(0f, 0.25f * 2, 0f), new Vector3(0f, -1f * 2, 0f), out hit))
		{
			if (!(hit.distance >= 0.75f))
			{
				canJump = true;
			}
			else
			{
				canJump = false;
			}
		}
		#if UNITY_EDITOR || !UNITY_WIIU
		if (Input.GetKey(KeyCode.A))
		#else
		if (gamePad.IsPressed(WiiU.GamePadButton.A))
		#endif
		{
			if (canJump && isStanding && !hit.collider.isTrigger)
			{
				float y = jumpHeight;
				Vector3 velocity2 = GetComponent<Rigidbody>().velocity;
				float num2 = (velocity2.y = y);
				Vector3 vector3 = (GetComponent<Rigidbody>().velocity = velocity2);
				if (!(jumpCounter <= 0.25f))
				{
					GetComponent<AudioSource>().PlayOneShot(jumpSound);
					jumpCounter = 0f;
				}
			}
		}
		else
		{
			float y2 = GetComponent<Rigidbody>().velocity.y - 32f * Time.deltaTime;
			Vector3 velocity3 = GetComponent<Rigidbody>().velocity;
			float num3 = (velocity3.y = y2);
			Vector3 vector5 = (GetComponent<Rigidbody>().velocity = velocity3);
		}
		if (Physics.Raycast(transform.position - new Vector3(0f, 0.25f * 2, 0f), new Vector3(0f, 1f * 2, 0f), out hitUp))
		{
			if (!(hitUp.distance <= 1f))
			{
				#if UNITY_EDITOR || !UNITY_WIIU
				if (Input.GetKeyDown(KeyCode.B))
				#else
				if (gamePad.IsTriggered(WiiU.GamePadButton.B))
				#endif
				{
					isStanding = false;
					sliding.SetActive(true);
					standing.SetActive(false);
				}
				#if UNITY_EDITOR || !UNITY_WIIU
				if (Input.GetKeyUp(KeyCode.B))
				#else
				if (gamePad.IsReleased(WiiU.GamePadButton.B))
				#endif
				{
					isStanding = true;
					standing.SetActive(true);
					sliding.SetActive(false);
				}
			}
			else if (isStanding && !hitUp.collider.isTrigger)
			{
				isStanding = false;
				sliding.SetActive(true);
				standing.SetActive(false);
			}
			#if UNITY_EDITOR || !UNITY_WIIU
			if (!Input.GetKey(KeyCode.B) && !(hitUp.distance <= 1f) && !isStanding)
			#else
			if (!gamePad.IsPressed(WiiU.GamePadButton.B) && !(hitUp.distance <= 1f) && !isStanding)
			#endif
			{
				isStanding = true;
				standing.SetActive(true);
				sliding.SetActive(false);
			}
		}
		if (transform.position.y < fallLimit || !(transform.position.x >= cam.transform.position.x - 13f))
		{
			if (flash != null)
			{
				flash.SendMessage("gameOverFlash", SendMessageOptions.DontRequireReceiver);
			}
			UnityEngine.Object.Instantiate(quickscope, transform.position, Quaternion.identity);
			UnityEngine.Object.Destroy(gameObject);
		}
	}

	public virtual void Main()
	{
	}

	void OnCollisionStay(Collision collisionInfo) {
        if(!isStanding)
		{
			if(transform.position.y < -2.3f)
				transform.position = new Vector3(transform.position.x, -2.3f, transform.position.z);
		}
    }
}
