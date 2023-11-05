using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private List<GameObject> background;

    void Update()
    {
        ScrollBackground();
    }

    private void ScrollBackground()
    {
        foreach (GameObject b in background)
        {
            b.GetComponent<MovementBehaviour>().SetSpeed(speed);
            b.GetComponent<MovementBehaviour>().SetDirection(Vector3.down);
            b.GetComponent<MovementBehaviour>().MoveTransform();
        }
    }

    public Vector3 GetSpawnPoint()
    {
        return spawnPoint.position;
    }
}
