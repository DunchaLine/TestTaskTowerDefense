using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class gunInstantiate : MonoBehaviour
{   
    //public List<UpLevel> levels;
    private GameObject _gun;
    public GameObject _gunPrefab;
    private bool canInstantiate = true;
    private UpLevel _currLvl;
    void OnMouseUp()
    {
        Debug.Log("in OnMouseUp");
        if (canInstantiate)
        {
            Debug.Log("In if");
            _gun = Instantiate(_gunPrefab, transform.position, Quaternion.identity);
            canInstantiate = false;
        }
    }

    // public UpLevel CurrLvl
    // {
    //     get
        
    //         return _currLvl;
        
    // }

}

[System.Serializable]
public class UpLevel
{
    public int price;
    public GameObject _obj;
}