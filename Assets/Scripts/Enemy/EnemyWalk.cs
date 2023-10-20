using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;
public class EnemyWalk : EnemyBase
{
    [Header("Waypoints")]
    public GameObject[] waypoints;
    public float minDistance = 1f;
    public float speed = 1f;

    private int _index = 0;

    public override void Update()
    {
        base.Update();

        if(Vector3.Distance(transform.position, waypoints[_index].transform.position) < minDistance)
        {
            _index++;
            if( _index >= waypoints.Length )
            {
                _index = 0;
            }
        }
        var nextWayPoint = waypoints[_index].transform.position;
        transform.position = Vector3.MoveTowards(transform.position, nextWayPoint, Time.deltaTime * speed);
        transform.LookAt(nextWayPoint);
    }
}
