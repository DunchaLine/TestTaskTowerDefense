using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyRespawn : MonoBehaviour
{
    public Wave[] _waves;
    public GameObject _winText;
    public int _timeBetween = 10;
    public GameObject _managerObj;
    private gManager _manager;
    private float _lastSpawn;
    private int _enemiesSpawned;
    public static int _currWave;
    void Start()
    {
        _enemiesSpawned = 0;
        _manager = _managerObj.GetComponent<gManager>();
        _lastSpawn = Time.time;
    }

    void Update()
    {
        _currWave = _manager.Wave;
        if (_currWave < _waves.Length)
        {
            float _intervalBetween = Time.time - _lastSpawn;
            float spawnInterval = _waves[_currWave].spawnInterval;
            if ((_enemiesSpawned == 0 && _intervalBetween > _timeBetween) || _intervalBetween > spawnInterval)
            {
                if (_enemiesSpawned  < _waves[_currWave].maxEnemies)
                {
                    GameObject _enemyNew = Instantiate(_waves[_currWave]._enemy, transform.position, transform.rotation);
                    Debug.Log("Create enemy");
                    _lastSpawn = Time.time;
                    _enemiesSpawned++;
                }
            }
            if (_enemiesSpawned == _waves[_currWave].maxEnemies && GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                _manager.Wave++;
                _manager.Gold += 300;
                _enemiesSpawned = 0;
                _lastSpawn = Time.time;
            }
        }
        else
        {
            _winText.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
[System.Serializable]
public class Wave
{
    public GameObject _enemy;
    public float spawnInterval = 2;
    //public int maxEnemies = 20;
    public int maxEnemies = 20;
}
