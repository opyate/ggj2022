using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class LevelEnd : MonoBehaviour
{
    public string NextLevel;

    private void OnTriggerEnter(Collider other)
    {
        SceneTransitionManager.Instance.LoadScene(NextLevel);
    }
}
