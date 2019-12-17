using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetGun : MonoBehaviour
{
    private float _angle;
    [HideInInspector] public Vector3 _direction;
    public float _interval;
    private float _tmpTime = 0.0f;
    public GameObject _bullet;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            _direction = other.transform.position - transform.position;
            _angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, _angle);
            if (Time.time > _tmpTime)
            {
                _tmpTime = Time.time + _interval;
                GameObject _tmp = GameObject.Instantiate(_bullet, other.transform.position, Quaternion.identity);
                Destroy(_tmp, 1f);
            }
        }
    }
}
