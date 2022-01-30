using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Scenery : MonoBehaviour
{
    public float SceneryRotateUpAngle = -88;
    public float SceneryRotateDownAngle = 0;
    public float SceneryRotateTime = 1;
    public GameObject SceneryRotator;

    private bool Opening;
    private bool Closing;
    private float RotateStartTime;

    public UnityEvent FinishedOpening;
    public UnityEvent FinishedClosing;

    [Header("Audio")]
    private AudioSource Source;
    public AudioClip OpeningEffect;
    public AudioClip ClosingEffect;

    [Header("Hearts")]
    public GameObject[] HeartObjects;

    // Start is called before the first frame update
    void Start()
    {
        SceneryRotator.transform.rotation = Quaternion.Euler(SceneryRotateUpAngle, 0, 0);
        Source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Opening)
        {
            if (Time.time - RotateStartTime < SceneryRotateTime)
            {
                SceneryRotator.transform.rotation = Quaternion.Euler(Mathf.Lerp(SceneryRotateUpAngle, SceneryRotateDownAngle, (Time.time - RotateStartTime)/ SceneryRotateTime), 0, 0);
            }
            else
            {
                Opening = false;
                FinishedOpening.Invoke();
            }
        }
        if (Closing)
        {
            if (Time.time - RotateStartTime < SceneryRotateTime)
            {
                SceneryRotator.transform.rotation = Quaternion.Euler(Mathf.Lerp(SceneryRotateDownAngle, SceneryRotateUpAngle, (Time.time - RotateStartTime) / SceneryRotateTime), 0, 0);
            }
            else
            {
                Closing = false;
                FinishedClosing.Invoke();
            }
        }
    }

    public void StartLevel() 
    {
        Opening = true;
        RotateStartTime = Time.time;
        SceneryRotator.transform.rotation = Quaternion.Euler(SceneryRotateUpAngle, 0, 0);
        Source.clip = OpeningEffect;
        Source.Play();
    }

    public void EndLevel()
    {
        Closing = true;
        RotateStartTime = Time.time;
        SceneryRotator.transform.rotation = Quaternion.Euler(SceneryRotateDownAngle, 0, 0);
        Source.clip = ClosingEffect;
        Source.Play();
    }
    
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();

    }

    public void SetHeartAmount(int Amount)
    {
        for (int i = 0; i < HeartObjects.Length; i++)
        {
            if (i < Amount)
            {
                HeartObjects[i].SetActive(true);
            }
            else
            {
                HeartObjects[i].SetActive(false);
            }
        }
    }
}
