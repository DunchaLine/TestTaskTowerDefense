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
    private enemyHealth _health;
    public GameObject _bulletObj;
    public int _damage;
    void Start()
    {
        _health = GetComponent<enemyHealth>();
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
            _manager.Health -= _health._damage;
            Destroy(gameObject);
            return;
        }
        curr_waypoint = waypoints.GetChild(_indexWaypoint);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            _health.Health -= _damage;
            gManager _manager = GameObject.Find("GameManager").GetComponent<gManager>();
        }
    }
}
