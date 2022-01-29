using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    public int NumLives;
    int l;
    // Start is called before the first frame update

    void Start()
    {
        l = PlayerPrefs.GetInt("Lives", NumLives);
    }

    public void takeLives()
    {
        l--;
        PlayerPrefs.SetInt("Lives", l);
    }

    public int getLives()
    {
        return l;
    }
}
