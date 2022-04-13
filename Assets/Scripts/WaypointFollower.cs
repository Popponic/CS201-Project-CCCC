using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    int currrentWaypointIndex = 0;
    float waitTime = 0.1f;

    [SerializeField] float speed = 1f;

    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, waypoints[currrentWaypointIndex].transform.position) < .1f)
        {
            currrentWaypointIndex++;
            if (currrentWaypointIndex >= waypoints.Length)
            {
                currrentWaypointIndex = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[currrentWaypointIndex].transform.position, speed * Time.deltaTime);


    }



    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        other.transform.SetParent(transform);
    //        other.transform.position = transform.position;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        other.transform.SetParent(null);
    //    }
    //}
}

