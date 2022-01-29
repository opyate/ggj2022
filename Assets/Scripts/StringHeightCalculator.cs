using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringHeightCalculator : MonoBehaviour
{
    private LineRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<LineRenderer>();
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.up, out hit, 100))
        {
            rend.SetPosition(0, transform.position);
            rend.SetPosition(1, hit.point);
        }
    }
}
