using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField]
    private float movingSpeed = 2f;
    [SerializeField]
    private GameObject[] wayPoints;
    private int curWayPointIndex = 0;
    void Update()
    {
        if(Vector2.Distance(wayPoints[curWayPointIndex].transform.position,transform.position)<0.1f)
        {
            curWayPointIndex++;
            if(curWayPointIndex>=wayPoints.Length)
            {
                curWayPointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position,
            wayPoints[curWayPointIndex].transform.position,
            movingSpeed * Time.deltaTime);
    }
}
