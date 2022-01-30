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
    public AudioClip JumpSound;

    public Texture main;
    public Texture amus;
    public GameObject RenderingChild;

    public float WalkAngle;
    public float WalkTime;
    private float LastSwitchTime;
    public GameObject RotationChild;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //Find the rigidbody attched to the player

        FindObjectOfType<Scenery>().FinishedOpening.AddListener(UnlockPlayer); //unlock the player whenever the scenery finishes opening
        Source = GetComponent<AudioSource>();


        if (Random.Range(0, 10) < 1)
        {
            RenderingChild.GetComponent<MeshRenderer>().sharedMaterial.SetTexture("_MainTex", amus);
        }
        else
        {
            RenderingChild.GetComponent<MeshRenderer>().sharedMaterial.SetTexture("_MainTex", main);
        }
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
                Source.clip = JumpSound;
                Source.Play();
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

        if (Physics.Raycast(transform.position, Vector3.down, out hit, MaximumJumpSearch))
        {


            if (Input.GetAxisRaw("Horizontal") != 0)
            {//player is holding a key
                if (Time.time - LastSwitchTime > WalkTime)
                {
                    if (RotationChild.transform.rotation.z > 0)
                    {
                        RotationChild.transform.rotation = Quaternion.Euler(0, 0, -WalkAngle);
                        LastSwitchTime = Time.time;

                    }
                    else
                    {
                        RotationChild.transform.rotation = Quaternion.Euler(0, 0, WalkAngle);
                        LastSwitchTime = Time.time;
                    }
                }
            }
            else
            {//no keys are being held
                RotationChild.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else
        {//no keys are being held
            RenderingChild.transform.rotation = Quaternion.Euler(0, 0, 0);
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
