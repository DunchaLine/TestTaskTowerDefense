using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunInstantiate : MonoBehaviour
{
    private GameObject _gun;
    public GameObject _gunPrefab;
    private bool canInstantiate = true;
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
}
