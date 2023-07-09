using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyMovement : MonoBehaviour
{
   public Transform[] waypoints;
    public float moveSpeed = 5f;
    public float returnSpeed = 2f;

    private int currentWaypoint = 0;
    private bool movingForward = true;

    void Update()
    {
        if (currentWaypoint < waypoints.Length)
        {
            // Move towards the current waypoint at the current move speed
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].position, Time.deltaTime * moveSpeed);

            if (transform.position == waypoints[currentWaypoint].position)
            {
                if (movingForward)
                {
                    currentWaypoint++;
                }
                else
                {
                    currentWaypoint--;
                }

                // Reverse direction when we reach the end or the start of the waypoint array
                if (currentWaypoint == waypoints.Length)
                {
                    movingForward = false;
                    currentWaypoint--;
                } 
                else if (currentWaypoint < 0)
                {
                    movingForward = true;
                    currentWaypoint = 0;
                }
            }
        }
        else
        {
            // If we've reached the end of the waypoints, return to the start at the return speed
            transform.position = Vector3.MoveTowards(transform.position, waypoints[0].position, Time.deltaTime * returnSpeed);
        }
    }
}
