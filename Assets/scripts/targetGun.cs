using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetGun : MonoBehaviour
{
    public float interval;
    public GameObject bullet;
    [HideInInspector] public Vector3 direction;
    private float _angle;
    private float _tmpTime = 0.0f;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            direction = other.transform.position - transform.position;
            _angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, _angle);
            if (Time.time > _tmpTime)
            {
                _tmpTime = Time.time + interval;
                GameObject _tmp = GameObject.Instantiate(bullet, other.transform.position, Quaternion.identity);
                Destroy(_tmp, 1f);
            }
        }
    }
}
