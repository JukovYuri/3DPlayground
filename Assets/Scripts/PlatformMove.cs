using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
	bool isPlatformMoving;
	float speed = 5f;

	public void Move()
	{
		transform.DOMoveZ(-19f, 6f).SetLoops(-1, LoopType.Yoyo).SetUpdate(UpdateType.Fixed);
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
