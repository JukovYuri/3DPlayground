using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float speedRotation;
    [SerializeField] private float jumpForce;
    [SerializeField] private GameObject objectCenter;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask whatIsBall;
    [SerializeField] private float maxPushForce;
    [SerializeField] private float pushForce;
    private bool isGoingUp;
    private Rigidbody rb;

    float time;


    // Start is called before the first frame update
    void Start()
    {


    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButton("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce);
        }

        if (Input.GetMouseButtonDown(0))
        {
            pushForce = 0;
            isGoingUp = true;
        }

        if (Input.GetMouseButton(0))
        {
            if (isGoingUp)
            {
                pushForce += maxPushForce * Time.deltaTime;

                if (pushForce >= maxPushForce)
                {
                    isGoingUp = false;
                }
            }
            else
            {
                pushForce -= maxPushForce * Time.deltaTime;
                if (pushForce < 0)
                {
                    isGoingUp = true;
                }
            }
            time += Time.deltaTime;
            float value = Mathf.Sin(time);

            print(pushForce);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Collider [] colliders = Physics.OverlapSphere(objectCenter.transform.position, radius, whatIsBall);

            foreach (Collider item in colliders)
            {
                Rigidbody colRb = item.GetComponent<Rigidbody>();
                Vector3 forceDirection = transform.forward;
                colRb.AddForce(forceDirection.normalized * pushForce, ForceMode.Impulse);
            }
        }



    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");
        transform.RotateAround(transform.position, Vector3.up, inputHorizontal * speedRotation);
        rb.AddForce(transform.forward * inputVertical * speed);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(objectCenter.transform.position, radius);
    }

    void private GetForcePercentage()
    { 
    
    }


}
