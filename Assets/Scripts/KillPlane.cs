using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlane : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        SceneTransitionManager.Instance.Lives -= 1;
        if (SceneTransitionManager.Instance.Lives == 0)
        {
            SceneTransitionManager.Instance.Lives = SceneTransitionManager.Instance.MaxLives;
            SceneTransitionManager.Instance.LoadScene("Level1");
        }
        else
        {
            SceneTransitionManager.Instance.ReloadScene();
        }
    }
}
