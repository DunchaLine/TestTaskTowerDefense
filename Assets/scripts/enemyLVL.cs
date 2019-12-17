using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLVL : MonoBehaviour
{
    private enemyHealth _health;
    void Start()
    {
        _health = GetComponent<enemyHealth>();
        _health.Health = 10;
    }
}
