using UnityEngine.Audio;
using UnityEngine;
using System;

[Serializable]
public class SoundClass
{
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(0.3f, 1f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
