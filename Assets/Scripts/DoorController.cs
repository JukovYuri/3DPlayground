using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorController : MonoBehaviour
{

	[SerializeField] private float speed;
	private bool goingUp = true;
	private bool isActivate;
	Animator animator;

	void Start()
	{
		animator = GetComponent<Animator>();
	}


	public void ActivateUp()
	{
		//StopAllCoroutines();
		//StartCoroutine(DoorUp());
		//animator.SetTrigger("Up");
		transform.DOMoveY(10f, 4f).SetEase(Ease.InOutElastic);
	}

	public void ActivateDown()
	{
		//StopAllCoroutines();
		//StartCoroutine(DoorDown());
		//animator.SetTrigger("Down");
		transform.DOMoveY(0f, 4f).SetEase(Ease.InOutElastic);

	}

	IEnumerator DoorUp()
	{
		while (transform.position.y < 10)
		{
			transform.position += Vector3.up * speed * Time.deltaTime;
			yield return null;
		}
	}

	IEnumerator DoorDown()
	{
		while (transform.position.y > 2)
		{
			transform.position -= Vector3.up * speed * Time.deltaTime;
			yield return null;
		}
	}
}
