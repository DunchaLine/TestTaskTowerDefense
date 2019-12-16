using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetGun : MonoBehaviour
{
    private float _angle;
    private Vector3 _direction;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            _direction = other.transform.position - transform.position;
            _angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, _angle);
        }
    }
}
