using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class camerashake : MonoBehaviour
{
    public Vector3 originPosition;
    public Quaternion originRotation;

    public float shake_decay;
    public float shake_intensity;

    public GUITexture airhornstatic;
    public GameObject hitmarkers;
    public GameObject quickscope;

	GUITexture airHorn;
    void Start()
    {
        airHorn = GameObject.Find("airhornstatic").GetComponent<GUITexture>();
		airHorn.enabled = false;

        StartCoroutine(Derp());

        StartCoroutine(StartRoutine());
    }

    IEnumerator StartRoutine()
    {
        yield return new WaitForSeconds(37f);

        ShakeCustom();
        yield return new WaitForSeconds(7f);

        ShakeCustom();
    }

    public void restart()
    {
        StartCoroutine(Derp());
    }

    IEnumerator Derp()
    {
        yield return new WaitForSeconds(3f);

        StartCoroutine(Shake());
        yield return new WaitForSeconds(2.75f);

        Instantiate(quickscope, new Vector3(64f, -4f, -3f), Quaternion.identity);
        Instantiate(hitmarkers, new Vector3(69f, 0f, -3f), Quaternion.identity);
        yield return new WaitForSeconds(1.75f);

        Instantiate(quickscope, new Vector3(88f, -4f, -3f), Quaternion.identity);
        Instantiate(hitmarkers, new Vector3(92f, 0f, -3f), Quaternion.identity);
        yield return new WaitForSeconds(1.25f);

        StartCoroutine(Shake());
        yield return new WaitForSeconds(6.25f);

        StartCoroutine(Shake());
        yield return new WaitForSeconds(5.75f);

        StartCoroutine(Shake());
        yield return new WaitForSeconds(8.5f);

        StartCoroutine(Shake());
        yield return new WaitForSeconds(4.75f);

        Instantiate(quickscope, new Vector3(420f, -4f, -3f), Quaternion.identity);
        Instantiate(hitmarkers, new Vector3(430f, 0f, -3f), Quaternion.identity);
        yield return new WaitForSeconds(12.75f);

        StartCoroutine(Shake());
        yield return new WaitForSeconds(14.25f);

        StartCoroutine(Shake());
        yield return new WaitForSeconds(8.75f);

        StartCoroutine(Shake());
        yield return new WaitForSeconds(25.25f);

        StartCoroutine(Shake());
        yield return new WaitForSeconds(9.75f);

        StartCoroutine(Shake());
        yield return new WaitForSeconds(4.75f);

        Instantiate(quickscope, new Vector3(1330f, -4f, -3f), Quaternion.identity);
        Instantiate(hitmarkers, new Vector3(1340f, 0f, -3f), Quaternion.identity);
        yield return new WaitForSeconds(4.25f);

        StartCoroutine(Shake());
        yield return new WaitForSeconds(9f);

        StartCoroutine(Shake());
        yield return new WaitForSeconds(11.5f);

        StartCoroutine(Shake());
        yield return new WaitForSeconds(7.5f);

        StartCoroutine(Shake());
        yield return new WaitForSeconds(6.25f);

        restart();
    }

    IEnumerator Shake()
    {
        originRotation = transform.rotation;
        shake_intensity = 0.3f;
        shake_decay = 0.002f;

        airHorn.enabled = true;

        yield return new WaitForSeconds(1f);

        airHorn.enabled = false;
    }

    private Vector3 shakeOffset;

	void Update()
	{
		if (shake_intensity > 0f)
		{
			shakeOffset = UnityEngine.Random.insideUnitSphere * shake_intensity * 32f;

			transform.rotation = originRotation * Quaternion.Euler(shakeOffset);

			shake_intensity -= shake_decay;
		}
	}

    public void ShakeCustom()
    {
        originRotation = transform.rotation;
        shake_intensity = 0.3f;
        shake_decay = 0.002f;
    }
}