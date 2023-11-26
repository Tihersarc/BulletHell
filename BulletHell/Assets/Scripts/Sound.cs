using UnityEngine;

[System.Serializable]
public class Sound
{
    public enum AudioTypes { soundEffect, music }
    public AudioTypes audioType;

    public AudioSource source;
    public string clipName;
    public AudioClip audioClip;
    public bool isLoop;
    public bool isPlayOnAwake;

    [Range(0f, 1f)]
    public float volume = 0.5f;
}
