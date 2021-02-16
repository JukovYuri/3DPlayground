using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public static PlayerMovement Instance { get; private set; }

	public Action OnButtonPressed = delegate { };
	public Action OnPlatformMoving = delegate { };

	[Header("References")]
	[SerializeField] private CharacterController controller;

	[Header("Movement config")]
	[SerializeField] private float speedMove = 10f;
	[SerializeField] private float speedRotate = 10f;

	[Header("Gravity config")]
	[SerializeField] private float jumpHeight = 10f;
	[SerializeField] private float gravityScale = 10f;

	[SerializeField] private int lives = 3;

	private float gravity;

	private Vector3 startPosition;


	private void Awake()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
			return;
		}

		Instance = this;

	}

	private void Start()
	{
		startPosition = transform.position;
	}
	void Update()
	{
		Rotate();
		Move();

	}

	private void Rotate()
	{
		float mouseHorizontal = Input.GetAxis("Mouse X");
		transform.Rotate(transform.up, mouseHorizontal * speedRotate * Time.deltaTime);
	}

	private void Move()
	{
		float inputHorizontal = Input.GetAxis("Horizontal");
		float inputVertical = Input.GetAxis("Vertical");

		Vector3 moveDirection = transform.forward * inputVertical + transform.right * inputHorizontal;
		if (moveDirection.magnitude > 1)
		{
			moveDirection.Normalize();
		}



		if (controller.isGrounded)
		{
			gravity = -0.1f;
			if (Input.GetButtonDown("Jump"))
			{
				gravity = jumpHeight;
			}
		}
		else
		{
			gravity += Physics.gravity.y * Time.deltaTime;
		}


		moveDirection.y = gravity;
		controller.Move(moveDirection * speedMove * Time.deltaTime);
	}

	public void ApplyDamage()
	{ 
		--lives;
		controller.enabled = false;
		ResetPosition();
		controller.enabled = true;
	}

	private void ResetPosition()
	{
		transform.position = startPosition;
	}

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (hit.collider.gameObject.CompareTag("Button"))
		{
			OnButtonPressed();
		}

		if (hit.collider.gameObject.CompareTag("Floor"))
		{
			ApplyDamage();
		}

		if (hit.collider.gameObject.CompareTag("PlatformFalling"))
		{
			hit.collider.GetComponent<PlatformFalling>().FallingWithDelay();
		}


	}
}

