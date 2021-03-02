using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		PlayerMovement.Instance.SetStartPosition();
	}
}
