using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gManager : MonoBehaviour
{
    public Text _goldText;
    public Text _waveText;
    public Text _healthText;
    public GameObject _loseText;
    private int _gold;
    private int _wave;
    private int _health;
    public bool isLose = false;
    void Start()
    {
        Gold = 1000;
        Wave = 0;
        Health = 2;
    }
    void Update()
    {
        if (isLose)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene(0);
                Time.timeScale = 1;
            }
        }
    }
    public int Gold
    {
        get
        {
            return _gold;
        }
        set
        {
            _gold = value;
            _goldText.GetComponent<Text>().text = "Gold: " + _gold;
        }
    }
    public int Wave
    {
        get
        {
            return _wave;
        }
        set
        {
            _wave = value;
            _waveText.GetComponent<Text>().text = "Wave: " + (_wave + 1);
        }
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
            _healthText.GetComponent<Text>().text = "Health: " + _health;
            Debug.Log(isLose);
            if (_health <= 0 && !isLose)
            {
                isLose = true;
                _loseText.SetActive(true);
                Time.timeScale = 0;
                Debug.Log("fucking true" + isLose);
            }
        }
    }
}
