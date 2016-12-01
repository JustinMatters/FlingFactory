using UnityEngine;
using System.Collections;

public class JM_PathFollower : MonoBehaviour
{

    public float moveSpeed;
    public Transform[] waypoints;
    public float sphereSize = 1.0f;
    private int currentPoint = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called fifty times per second
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentPoint].position, moveSpeed/50);
        if (transform.position == waypoints[currentPoint].position)
        {
            currentPoint++;
            if (currentPoint >= waypoints.Length)
            {
                currentPoint = 0;
            }
        }
    }


    /*draw handy hints in the engine
    void OnDrawGizmos()
    {
        for (int i = 0; i < waypoints.Length ; i++)
        {
            if (waypoints[i] != null)
            {
                Gizmos.DrawSphere(waypoints[i].position, sphereSize);
            }
        }
    }*/
}