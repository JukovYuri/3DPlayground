using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;
    Vector3 startPosition;


    // Start is called before the first frame update
    void Start()
    {
       startPosition = transform.position;
        Rigidbody rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ResetPosition()
    {
        transform.position = startPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {

        }
        else 
        {
            ResetPosition();
        }
    }
}
