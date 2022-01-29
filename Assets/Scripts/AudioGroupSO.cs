using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Audio Clip Group")]
public class AudioGroupSO : ScriptableObject
{
    public AudioClip[] Clips;
    public float MaxPitch = 1;
    public float MinPitch = 1;

    public AudioClip GetClip()
    {
        return Clips[Random.Range(0, Clips.Length)];
    }
}
