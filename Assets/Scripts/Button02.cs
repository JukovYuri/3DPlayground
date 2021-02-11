using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button02 : MonoBehaviour
{
	public UnityEvent OnPressed;
	public UnityEvent OnUnPressed;

	private void OnTriggerEnter(Collider other)
	{
		OnPressed.Invoke();
		print("qwert");
	}

	private void OnTriggerExit(Collider other)
	{
		OnUnPressed.Invoke();
	}
}


