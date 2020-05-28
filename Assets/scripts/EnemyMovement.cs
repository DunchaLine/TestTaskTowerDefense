using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject managerObject;
    public float speed;
    public int damage;
    private Transform _waypoints;
    private Transform _curr_waypoint;
    private int _indexWaypoint = 0;
    private Vector3 _direction;
    private float _rotation = 0;
    private enemyHealth _health;
    private gManager _manager;
    void Start()
    {
        _health = GetComponent<enemyHealth>();
        _manager = managerObject.GetComponent<gManager>();
        _waypoints = GameObject.FindGameObjectWithTag("Waypoints").transform;
        NextWaypoint();
    }
    
    void Update()
    {
        Debug.Log(gameObject + " health: " + _health.Health);
        _direction = _curr_waypoint.transform.position - transform.position;
        transform.Translate(_direction.normalized * speed * Time.deltaTime, Space.World);
        if (_direction.magnitude <= .1f)
        {
            NextWaypoint();
            _direction = _curr_waypoint.transform.position - transform.position;
            _rotation += Vector3.SignedAngle(_direction, transform.right, Vector3.up);
            transform.rotation = Quaternion.AngleAxis(_rotation, transform.forward);
        }
    }

    void NextWaypoint()
    {
        _indexWaypoint++;
        if (_indexWaypoint >= _waypoints.childCount)
        {
            _manager.Health -= _health.damage;
            Destroy(gameObject);
            return;
        }
        _curr_waypoint = _waypoints.GetChild(_indexWaypoint);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            _health.Health -= damage;
        }
    }
}
