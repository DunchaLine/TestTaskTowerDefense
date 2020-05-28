using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gManager : MonoBehaviour
{
    public Text goldText;
    public Text waveText;
    public Text healthText;
    public GameObject loseText;
    public bool isLose = false;
    //public int enemyLVL;
    private int _gold;
    private int _wave;
    private int _health;
    void Awake()
    {
        Gold = 500;
        Wave = 0;
        Health = 10;
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
    // public int Enemy
    // {
    //     get
    //     {
    //         return enemyLVL;
    //     }
    //     set
    //     {
    //         if (value <= 3)
    //             enemyLVL = value;
    //     }
    // }
    public int Gold
    {
        get
        {
            return _gold;
        }
        set
        {
            _gold = value;
            goldText.GetComponent<Text>().text = "Gold: " + _gold;
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
            waveText.GetComponent<Text>().text = "Wave: " + (_wave + 1);
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
            healthText.GetComponent<Text>().text = "Health: " + _health;
            if (_health <= 0 && !isLose)
            {
                isLose = true;
                loseText.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
