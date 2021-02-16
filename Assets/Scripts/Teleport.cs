using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
	public Transform teleport;

	private void OnTriggerEnter(Collider other)
	{
		PlayerMovement.Instance.GetComponent<CharacterController>().enabled = false;
		PlayerMovement.Instance.transform.position = teleport.position;
		PlayerMovement.Instance.GetComponent<CharacterController>().enabled = true;
	}


}
