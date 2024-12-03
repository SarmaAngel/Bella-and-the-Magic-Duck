using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{

    [SerializeField] private GameObject[] waypoints; //aray of objects for waypoints to follow
    private int currentWaypointIndex = 0;   //variable to track current waypoint

    [SerializeField] private float speed = 2f;  //speed at which gameobject moves between waypoints

    
    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;      //move to the next waypoint
            if (currentWaypointIndex >= waypoints.Length)  //if you hav reached to the end of array
            {
                currentWaypointIndex = 0;  //then circle back to the first one
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed); //moves the gameobject to the current waypoint using linear interpolation 
    }
}
