using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;
    SnowmanMovement playerMovement;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerMovement = FindObjectOfType<SnowmanMovement>();
    }

    private void ResetPosition()
    {
        transform.position = playerMovement.transform.position + Random.insideUnitSphere * 5f + new Vector3(0,5f,0);
        rb.velocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Target"))
        {
           collision.gameObject.GetComponent<Animator>().SetTrigger("Goal");
            ResetPosition();            
            //todo add points
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            ResetPosition();
            //todo subtract points
        }
    }
}
