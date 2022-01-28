using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float HorizontalSpeed;
    public float JumpForce;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal");

        rb.velocity = new Vector3(Horizontal * -HorizontalSpeed, rb.velocity.y, 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * JumpForce);
        }

    }
}
