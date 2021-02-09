using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float speedRotation;
    [SerializeField] private int jumpForce;

    [Header ("Pushable Object")]
    [SerializeField] private GameObject objectCenter;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask whatIsPushable;

    [Header("Push")]
    [SerializeField] private float pushForceMax;
    [SerializeField] private float pushForce;
    [SerializeField] private float forceHeight;

    private bool isGoingUp = true;
    private Rigidbody rb;


    void Start()
    {


    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce);
        }


        if (Input.GetMouseButtonUp(0))
        {
            Collider[] colliders = Physics.OverlapSphere(objectCenter.transform.position, radius, whatIsPushable);
            foreach (Collider item in colliders)
            {
                Rigidbody colRb = item.attachedRigidbody;
                Vector3 forceDirection = transform.forward;
                forceDirection.y = forceHeight;
                colRb.AddForce(forceDirection * pushForce, ForceMode.Impulse);
            }
            pushForce = 0f;
        }

        if (Input.GetMouseButtonDown(0))
        {
            isGoingUp = true;
        }


        if (Input.GetMouseButton(0))
        {
            if (isGoingUp)
            {
                pushForce += pushForceMax * Time.deltaTime;
                if (pushForce >= pushForceMax)
                {
                    isGoingUp = false;
                }
            }

            else
            {
                pushForce -= pushForceMax * Time.deltaTime;
                if (pushForce <= 0)
                {
                    isGoingUp = true;
                }
            }
            print(pushForce);
        }

    }

    void FixedUpdate()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");
        transform.RotateAround(transform.position, Vector3.up, inputHorizontal * speedRotation);
        rb.velocity = transform.forward * inputVertical * speed;
    }

    public float GetForceInPercentage()
    {
        return pushForce / pushForceMax;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(objectCenter.transform.position, radius);
    }

}
