using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float HorizontalSpeed;
    public float JumpForce;
    public float MaximumJumpSearch;

    public bool CanMove;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //Find the rigidbody attched to the player

        FindObjectOfType<Scenery>().FinishedOpening.AddListener(UnlockPlayer); //unlock the player whenever the scenery finishes opening
    }

    void Update()
    {
        if (CanMove)
        {
            float Horizontal = Input.GetAxis("Horizontal");

            rb.velocity = new Vector3(Horizontal * -HorizontalSpeed, rb.velocity.y, 0);

            RaycastHit hit;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Physics.Raycast(transform.position, Vector3.down, out hit, MaximumJumpSearch))
                {
                    rb.AddForce(Vector3.up * JumpForce);
                }
            }
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
    }

    public void LockPlayer()
    {
        CanMove = false;
    }

    public void UnlockPlayer()
    {
        CanMove = true;
    }
}
