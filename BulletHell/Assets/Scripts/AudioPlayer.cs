using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private int deathIndex;

    // Add reference and call to AudioManager
    public void DeathSound()
    {
        AudioManager.PlaySound(deathIndex);
    }
}
