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
        rb = GetComponent<Rigidbody>();
        FindObjectOfType<Scenery>().FinishedOpening.AddListener(UnlockPlayer);
        foreach (LevelEnd end in FindObjectsOfType<LevelEnd>())
        {
            end.LevelEndTriggered.AddListener(LockPlayer);
        }
        LockPlayer();
    }

    void Update()
    {
        if (CanMove)
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
