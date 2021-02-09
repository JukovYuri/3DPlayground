using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFalling : MonoBehaviour
{
	[SerializeField] private float timer;
	PlayerMovement playerMovement;
	Rigidbody rb;
	Vector3 startPosition;
	Quaternion startRotation;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}
	private void Start()
	{
		startPosition = transform.position;
		startRotation = transform.rotation;
		GravityOff();
	}

	public void FallingWithDelay()
	{
		Invoke(nameof(GravityOn), timer);
	}
	private void GravityOn()
	{
		rb.useGravity = true;
	}

	private void GravityOff()
	{
		rb.useGravity = false;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Floor"))
		{

			transform.position = startPosition;
			transform.rotation = startRotation;
			GravityOff();
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
		}
	}


}
