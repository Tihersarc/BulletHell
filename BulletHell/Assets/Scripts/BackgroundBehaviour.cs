using UnityEngine;

public class BackgroundBehaviour : MonoBehaviour
{
    private Vector3 spawnPosition;

    void Start()
    {
        spawnPosition = GetComponentInParent<BackgroundController>().GetSpawnPoint();
    }

    private void OnBecameInvisible()
    {
        transform.position = spawnPosition;
    }
}
