using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
	bool isPlatformMoving;
	float speed = 5f;

	private void FixedUpdate()
	{
		if (isPlatformMoving)
		{
			Moving();
		}
	}



	public void Move()
	{
		isPlatformMoving = true;
	}
	
	public void Moving()
	{
		transform.Translate(-transform.forward * Time.deltaTime * speed);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			PlayerMovement.Instance.transform.parent = transform;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		PlayerMovement.Instance.transform.parent = null;
	}

}
