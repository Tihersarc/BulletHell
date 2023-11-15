using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject deathAnimation;
    [SerializeField] private bool soundOnDestroy;

    public void DestroyObject()
    {
        if (deathAnimation != null)
        {
            Instantiate(deathAnimation, transform.position, Quaternion.identity);
        }
        if (soundOnDestroy)
        {
            AudioManager.PlaySound(1);
        }
        Destroy(this);
    }

    public void DisableObject()
    {
        if (deathAnimation != null)
        {
            Instantiate(deathAnimation, transform.position, Quaternion.identity);
        }
        if (soundOnDestroy)
        {
            AudioManager.PlaySound(1);
        }
        gameObject.SetActive(false);
    }
}
