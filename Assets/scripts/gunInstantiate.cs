using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class gunInstantiate : MonoBehaviour
{   
    public GameObject gunPrefab;
    public int cost1lvl;
    public GameObject managerObj;
    private GameObject _gun;
    private int _gold;
    private gManager _manager;
    private bool _canInstantiate;
    private UpLevel _currLvl;
    
    void Start()
    {
        _manager = managerObj.GetComponent<gManager>();
        _canInstantiate = true;
    }
    void OnMouseUp()
    {
        _gold = _manager.Gold;
        if (_canInstantiate && _manager.Gold - cost1lvl >= 0) //исправить для возможности улучшения
        {
            _gun = Instantiate(gunPrefab, transform.position, Quaternion.identity);
            _canInstantiate = false;
            _manager.Gold -= cost1lvl;
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