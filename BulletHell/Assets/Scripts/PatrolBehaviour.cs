using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : MonoBehaviour
{
    [SerializeField] private bool IsPatrol;
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
        NextWaypoint();
    }

    private void NextWaypoint()
    {
        waypointIndex = Random.Range(0, waypoints.Count - 1);
        Vector3 dir = (waypoints[waypointIndex].transform.position - transform.position);
        mvb.SetDirection(dir);
    }


    IEnumerator Patrol()
    {
        while (IsPatrol)
        {
            if (Vector3.Distance(transform.position, waypoints[waypointIndex].transform.position) < 0.1f)
            {
                //waypointIndex = (waypointIndex + 1) % waypoints.Count;
                mvb.SetDirection(Vector3.zero);
                
                yield return new WaitForSeconds(nextWaypointDelay);
                NextWaypoint();
            }

            yield return null;
        }
    }
}
