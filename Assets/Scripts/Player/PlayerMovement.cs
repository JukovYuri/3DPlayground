using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private bool isLive;

	public static PlayerMovement Instance { get; private set; }

	public Action OnButtonPressed = delegate { };
	public Action OnPlatformMoving = delegate { };

	[Header("References")]
	[SerializeField] private CharacterController controller;
	[SerializeField] private Animator animator;

	[Header("Movement config")]
	[SerializeField] private float speedMove = 10f;
	[SerializeField] private float speedRotate = 10f;

	[Header("Gravity config")]
	[SerializeField] private float jumpHeight = 10f;
	[SerializeField] private float gravityScale = 10f;

	[SerializeField] private int lives = 3;

	private float gravity;

	private Vector3 startPosition;

	Camera mainCamera;


	private void Awake()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
			return;
		}

		Instance = this;

	}

	public void SetStartPosition()
	{
		startPosition = transform.position;
	}

	public void SetPlayerLive(bool isLive)
	{
		this.isLive = isLive;
	}

	private void Start()
	{
		SetPlayerLive(true);
		SetStartPosition();
		mainCamera = Camera.main;
	}
	void Update()
	{

		Move();


	}

	private void Move()
	{
		if (!isLive)
		{
			return;
		}

		float inputHorizontal = Input.GetAxis("Horizontal");
		float inputVertical = Input.GetAxis("Vertical");

		Vector3 forward = mainCamera.transform.forward;
		Vector3 right = mainCamera.transform.right;
		forward.y = right.y = 0;
		forward.Normalize();
		right.Normalize();

		Vector3 moveDirection = forward * inputVertical + right * inputHorizontal;
		if (moveDirection.sqrMagnitude > 1)
		{
			moveDirection.Normalize();
		}

		if (Mathf.Abs(inputHorizontal) > 0 || Mathf.Abs(inputVertical) > 0)
		{
			animator.SetBool("Running", true);
			//transform.rotation = Quaternion.LookRotation(moveDirection);
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), Time.deltaTime * speedRotate);
		}
		else
		{
			animator.SetBool("Running", false);
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
		JumpAnimation();
		controller.Move(moveDirection * speedMove * Time.deltaTime);
	}

	private void JumpAnimation()
	{
		if (gravity > 0 )
		{
			animator.SetInteger("Gravity", 1);
		}
		else if (gravity < -0.1f)
		{
			animator.SetInteger("Gravity", -1);
		}
		else
		{
			animator.SetInteger("Gravity", 0);
		}
	
	}

	public void ApplyDamage()
	{
		if (!isLive)
		{
			return;
		}

		//--lives; todo
		ApplyDeath();

	}

	public void ApplyDeath()
	{
		SetPlayerLive(false);
		animator.SetTrigger("Death");
	}

	public void ResetAfterDeath() // вызываем из animator event 
	{
		ResetPosition();
		SetPlayerLive(true);
	}

	public void ResetPosition() 
	{
		ControllerActive(false);
		transform.position = startPosition;
		ControllerActive(true);
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

	public void ControllerActive(bool enabled)
	{
		controller.enabled = enabled;
	}

}

