using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyRespawn : MonoBehaviour
{
    //сделать 6 типов волн (с 1 типом противника (x2), с 1-2типом противника, с 2 типом противника, с 2-3 и с 3)
    //сделать добавление волн через список (Add(Item)) и бесконечные волны, после 6 волны - сделать больше противников для невозможности дальнейшей игры
    //public GameObject _tmpPrefab;
    public Wave[] waves;
    public GameObject winText;
    public int timeBetween = 10;
    public GameObject managerObj;
    public static int currWave;
    private gManager _manager;
    private float _lastSpawn;
    private int _enemiesSpawned;
    private GameObject _enemyNew;
    void Start()
    {
        currWave = 0;
        _enemiesSpawned = 0;
        _manager = managerObj.GetComponent<gManager>();
        _lastSpawn = Time.time;
    }

    void Update()
    {
        // currWave = _manager.Wave;
        // float _intervalBetween = Time.time - _lastSpawn;
        // float spawnInterval = waves[currWave].spawnInterval;
        // if ((_enemiesSpawned == 0 && _intervalBetween > timeBetween) || _intervalBetween > spawnInterval)
        // {
        //     if (_enemiesSpawned < waves[currWave].maxEnemies)
        //     {
        //         GameObject _enemyNew = Instantiate(waves[currWave]._enemy, transform.position, transform.rotation);
        //         _lastSpawn = Time.time;
        //         _enemiesSpawned++;
        //     }
        // }
        // if (_enemiesSpawned == waves[currWave].maxEnemies && GameObject.FindGameObjectsWithTag("Enemy") == null)
        // {
        //     _manager.Wave++;
        //     _manager.Gold += 300;
        //     _enemiesSpawned = 0;
        //     _lastSpawn = Time.time;
        //     waves.Add();
        // }
        currWave = _manager.Wave;
        if (currWave < waves.Length)
        {
            float _intervalBetween = Time.time - _lastSpawn;
            float spawnInterval = waves[currWave].spawnInterval;
            if ((_enemiesSpawned == 0 && _intervalBetween > timeBetween) || _intervalBetween > spawnInterval)
            {
                if (waves[currWave]._enemy[1] != null)
                {
                    if (_enemiesSpawned  < waves[currWave].maxEnemies)
                    {
                        _enemyNew = Instantiate(waves[currWave]._enemy[Random.Range(0, 2)], transform.position, transform.rotation);
                        _lastSpawn = Time.time;
                        _enemiesSpawned++;
                    }
                } //waves[currWave]._enemy
                else
                {
                    if (_enemiesSpawned < waves[currWave].maxEnemies)
                    {
                        _enemyNew = Instantiate(waves[currWave]._enemy[0], transform.position, transform.rotation);
                        _lastSpawn = Time.time;
                        _enemiesSpawned++;
                    }
                }
            }
            if (_enemiesSpawned == waves[currWave].maxEnemies && GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                _manager.Wave++;
                _manager.Gold += 200;
                _enemiesSpawned = 0;
                _lastSpawn = Time.time;
            }
        }
        else
        {
            winText.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
[System.Serializable]
public class Wave
{
    public GameObject[] _enemy;
    public float spawnInterval = 2;
    public int maxEnemies = 20;
}
