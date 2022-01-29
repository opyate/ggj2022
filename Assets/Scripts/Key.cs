using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public LockedDoor Door;
    private void OnTriggerEnter(Collider other)
    {
        Destroy(Door.gameObject);
        Destroy(this.gameObject);
    }
}
