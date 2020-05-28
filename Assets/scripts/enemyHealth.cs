using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public int gold;
    public int damage;
    private int _health;
    private gManager _manager;

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
                _manager.Gold += gold;
            }
        }
    }
}
