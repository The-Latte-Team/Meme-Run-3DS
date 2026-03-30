using System;
using System.Collections;
using System.Collections.Generic;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class platform : MonoBehaviour
{
	[Serializable]
	internal sealed class _0024hi_002449 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal platform _0024self__002450;

			public _0024(platform self_)
			{
				_0024self__002450 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(0.3f)) ? 1 : 0);
					break;
				case 2:
					UnityEngine.Object.Destroy(_0024self__002450.gameObject);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal platform _0024self__002451;

		public _0024hi_002449(platform self_)
		{
			_0024self__002451 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__002451);
		}
	}

	public GameObject pickup;

	public bool canSpawnPickup;

	private GameObject cam;

	public platform()
	{
		canSpawnPickup = true;
	}

	public virtual void Start()
	{
		cam = GameObject.Find("Main Camera");
		if (pickup != null && canSpawnPickup)
		{
			int num = UnityEngine.Random.Range(1, 11);
			if (num == 4)
			{
				pickup.SetActive(true);
			}
			else
			{
				pickup.SetActive(false);
			}
		}
		if (!canSpawnPickup)
		{
			pickup.SetActive(false);
		}
	}

	public virtual IEnumerator hi()
	{
		return new _0024hi_002449(this).GetEnumerator();
	}

	public virtual void Update()
	{
		if (!(transform.position.x >= cam.transform.position.x - 32f))
		{
			if (gameObject.tag == "Untagged")
			{
				UnityEngine.Object.Destroy(gameObject);
			}
			if (gameObject.tag == "pickup")
			{
				StartCoroutine(hi());
			}
		}
	}

	public virtual void Main()
	{
	}
}
