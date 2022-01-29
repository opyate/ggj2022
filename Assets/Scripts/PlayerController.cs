using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    public float HorizontalSpeed;
    public float JumpForce;
    public float MaximumJumpSearch;

    public bool CanMove;

    private Rigidbody rb;

    [Header("Audio")]
    public AudioGroupSO ClipGroup;
    private AudioSource Source;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //Find the rigidbody attched to the player

        FindObjectOfType<Scenery>().FinishedOpening.AddListener(UnlockPlayer); //unlock the player whenever the scenery finishes opening
        Source = GetComponent<AudioSource>();
    }

    void Update()
    {
        RaycastHit hit;
        if (CanMove)
        {
            float Horizontal = Input.GetAxis("Horizontal");

            rb.velocity = new Vector3(Horizontal * -HorizontalSpeed, rb.velocity.y, 0);
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

        if (Physics.Raycast(transform.position, Vector3.down, out hit, MaximumJumpSearch))
        {
            if (Mathf.Abs(rb.velocity.x) > 0.5)
            {
                if (!Source.isPlaying)
                {
                    Source.clip = ClipGroup.GetClip();
                    Source.pitch = Random.Range(ClipGroup.MinPitch, ClipGroup.MaxPitch);
                    Source.Play();
                }
            }
        }
        else
        {
            Source.Stop();
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
