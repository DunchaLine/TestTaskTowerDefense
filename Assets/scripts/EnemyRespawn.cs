using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyRespawn : MonoBehaviour
{
    //сделать 6 типов волн (с 1 типом противника (x2), с 1-2типом противника, с 2 типом противника, с 2-3 и с 3)
    //сделать добавление волн через список (Add(Item)) и бесконечные волны, после 6 волны - сделать больше противником для невозможности дальнейшей игры
    public GameObject _tmpPrefab;
    public List<Wave> _waves;
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
        float _intervalBetween = Time.time - _lastSpawn;
        float spawnInterval = _waves[_currWave].spawnInterval;
        if ((_enemiesSpawned == 0 && _intervalBetween > _timeBetween) || _intervalBetween > spawnInterval)
        {
            if (_enemiesSpawned < _waves[_currWave].maxEnemies)
            {
                GameObject _enemyNew = Instantiate(_waves[_currWave]._enemy, transform.position, transform.rotation);
                _lastSpawn = Time.time;
                _enemiesSpawned++;
            }
        }
        if (_enemiesSpawned == _waves[_currWave].maxEnemies && GameObject.FindGameObjectsWithTag("Enemy") == null)
        {
            _manager.Wave++;
            _manager.Gold += 300;
            _enemiesSpawned = 0;
            _lastSpawn = Time.time;
            _waves.Add();
        }
        // if (_currWave < _waves.Length)
        // {
        //     float _intervalBetween = Time.time - _lastSpawn;
        //     float spawnInterval = _waves[_currWave].spawnInterval;
        //     if ((_enemiesSpawned == 0 && _intervalBetween > _timeBetween) || _intervalBetween > spawnInterval)
        //     {
        //         if (_enemiesSpawned  < _waves[_currWave].maxEnemies)
        //         {
        //             GameObject _enemyNew = Instantiate(_waves[_currWave]._enemy, transform.position, transform.rotation);
        //             _lastSpawn = Time.time;
        //             _enemiesSpawned++;
        //         }
        //     }
        //     if (_enemiesSpawned == _waves[_currWave].maxEnemies && GameObject.FindGameObjectWithTag("Enemy") == null)
        //     {
        //         _manager.Wave++;
        //         _manager.Gold += 300;
        //         _enemiesSpawned = 0;
        //         _lastSpawn = Time.time;
        //     }
        // }
        // else
        // {
        //     _winText.SetActive(true);
        //     Time.timeScale = 0;
        // }
    }
}
[System.Serializable]
public class Wave
{
    public GameObject _enemy;
    public float spawnInterval = 2;
    public int maxEnemies = 20;
}
