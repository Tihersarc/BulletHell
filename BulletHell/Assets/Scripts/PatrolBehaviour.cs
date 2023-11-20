using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : MonoBehaviour
{
    [SerializeField] public bool IsPatrol {get; private set;}
    [SerializeField] private float nextWaypointDelay = 1f;
    [SerializeField] private string waypointTag;
    [SerializeField] private List<GameObject> waypoints = new();
    private int waypointIndex;
    private MovementBehaviour mvb;

    void Start()
    {
        waypoints = new List<GameObject>(GameObject.FindGameObjectsWithTag(waypointTag));
        mvb = GetComponent<MovementBehaviour>();
        waypointIndex = 0;

        StartCoroutine(Patrol());
    }

    private void NextWaypoint()
    {
        Vector3 dir = (waypoints[waypointIndex].transform.position - transform.position);
        mvb.SetDirection(dir);
        Debug.Log("cambio de dir");
    }


    IEnumerator Patrol()
    {
        while (IsPatrol)
        {
            if (Vector3.Distance(transform.position, waypoints[waypointIndex].transform.position) < .5f)
            {
                waypointIndex = (waypointIndex + 1) % waypoints.Count;
                NextWaypoint();
                yield return new WaitForSeconds(nextWaypointDelay);
            }


        }
        yield return null;
    }
}
