using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float _speed;
    private Transform waypoints;
    private Transform curr_waypoint;
    private int _indexWaypoint = 0;
    private Vector3 _direction;
    private float rot = 0;
    void Start()
    {
        waypoints = GameObject.FindGameObjectWithTag("Waypoints").transform;
        NextWaypoint();
    }
    
    void Update()
    {
        _direction = curr_waypoint.transform.position - transform.position;
        transform.Translate(_direction.normalized * _speed * Time.deltaTime, Space.World);
        if (_direction.magnitude <= .1f)
        {
            NextWaypoint();
            _direction = curr_waypoint.transform.position - transform.position;
            rot += Vector3.SignedAngle(_direction, transform.right, Vector3.up);
            transform.rotation = Quaternion.AngleAxis(rot, transform.forward);
        }
    }

    void NextWaypoint()
    {
        _indexWaypoint++;
        if (_indexWaypoint >= waypoints.childCount)
        {
            gManager _manager = GameObject.Find("GameManager").GetComponent<gManager>();
            _manager.Health -= 1;
            Destroy(gameObject);
            return;
        }
        curr_waypoint = waypoints.GetChild(_indexWaypoint);
    }
}
