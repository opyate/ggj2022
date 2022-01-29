using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLives : MonoBehaviour
{
    // Start is called before the first frame update
    public Text onscreen;
    public Lives l;  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        onscreen.text = " " + l.getLives() + " ";
    }
}
