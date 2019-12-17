using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class gunInstantiate : MonoBehaviour
{   
    private GameObject _gun;
    public GameObject _gunPrefab;
    private bool canInstantiate = true;
    private UpLevel _currLvl;
    public int _cost1lvl;
    public gManager _manager;
    void OnMouseUp()
    {
        if (canInstantiate && _manager.Gold - _cost1lvl >= 0) //исправить для возможности улучшения
        {
            _gun = Instantiate(_gunPrefab, transform.position, Quaternion.identity);
            canInstantiate = false;
            _manager.Gold -= _cost1lvl;
        }
    }
}

[System.Serializable]
public class UpLevel
{
    public int price;
    public GameObject _obj;
    public int _cost;
}