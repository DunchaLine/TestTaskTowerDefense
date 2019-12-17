using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    private int _health;
    public int _damage;
    private gManager _manager;
    public int _gold;

    void Start()
    {
        _health = 0;
        _manager = GameObject.Find("GameManager").GetComponent<gManager>();
    }

    public int Health
    {
        get
        {
            return _health;
        } 
        set
        {
            _health = value;
            if (_health <= 0)
            {
                Destroy(gameObject);
                _manager.Gold += _gold;
            }
        }
    }
    void Update()
    {
        Debug.Log("hp - " + _health);
    }
}
