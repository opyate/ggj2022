using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlane : MonoBehaviour
{
    public GameObject l;

        private void OnCollisionEnter(Collision collision)
    {
        l.GetComponent<Lives>().takeLives();

        if (l.GetComponent<Lives>().getLives() <= 0)
        {
            PlayerPrefs.DeleteKey("Lives");
            SceneTransitionManager.Instance.LoadScene("Level1");
        }
        else
        {
            SceneTransitionManager.Instance.ReloadScene();
        }
    }
}
