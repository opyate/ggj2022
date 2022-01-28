using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    // Start is called before the first frame update
    void Start()
    {
        StartLevel();
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
        //rotate down
    }

    public void EndLevel()
    {
        Closing = true;
        RotateStartTime = Time.time;
        SceneryRotator.transform.rotation = Quaternion.Euler(SceneryRotateDownAngle, 0, 0);
        //rotate back up again
    }
}
