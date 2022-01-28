using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class LevelEnd : MonoBehaviour
{
    public string NextLevel;

    private Scenery scenery;

    public UnityEvent LevelEndTriggered;

    private void Start()
    {
        scenery = FindObjectOfType<Scenery>();
        scenery.FinishedClosing.AddListener(SwitchLevel);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        scenery.EndLevel();
        LevelEndTriggered.Invoke();
    }

    public void SwitchLevel()
    {
        SceneManager.LoadScene(NextLevel);
    }


}
