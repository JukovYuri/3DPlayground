using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
	[SerializeField] private bool isActive;
	[SerializeField] private Teleport otherTeleport;

	private void OnTriggerEnter(Collider other)
	{
		if (!isActive)
		{
			return;
		}

		if (other.gameObject.CompareTag("Player"))
		{
			PlayerMovement.Instance.ControllerActive(false);
			PlayerMovement.Instance.transform.position = otherTeleport.transform.position + new Vector3(0, 20f, 0);
			TeleportActive(false);
			PlayerMovement.Instance.ControllerActive(true);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		TeleportActive(true);
	}

	public void TeleportActive(bool enabled)
	{
		isActive = enabled;
	}





}
