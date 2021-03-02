using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
	Animator animator;
	public GameObject button;
	PlayerMovement playerMovement;
	[SerializeField] private float timeClosing = 5f;
	private bool isOpening;

	private void Awake()
	{
		animator = GetComponent<Animator>();
	}

	private void Start()
	{
		playerMovement = FindObjectOfType<PlayerMovement>();
		playerMovement.OnButtonPressed += OpenDoor;
	}

	public void OpenDoor()
	{
		if (!isOpening)
		{
			isOpening = true;
			animator.SetTrigger("OpenDoor");
			Invoke(nameof(CloseDoor), timeClosing);
		}
	}

	public void CloseDoor()
	{
		animator.SetTrigger("CloseDoor");
		isOpening = false;
	}

}
