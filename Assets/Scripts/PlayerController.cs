using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float HorizontalSpeed;
    public float JumpForce;
    public float MaximumJumpSearch;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal");

        rb.velocity = new Vector3(Horizontal * -HorizontalSpeed, rb.velocity.y, 0);
        
        //need to do a ground check
        //..
        //raycast? seems like a good idea
        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.Raycast(transform.position, Vector3.down, out hit, MaximumJumpSearch))
            {
                rb.AddForce(Vector3.up * JumpForce);
            }
        }
    }
}
