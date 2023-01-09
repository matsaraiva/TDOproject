using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeControl : MonoBehaviour
{
    public bool gameStart = false;

    //spawn times
    public float countdown = 15f;
    private GameObject[] enemySpawners;
    private GameObject[] towerSpawners;

    [SerializeField]
    private Text countdownText;

    private void Start()
    {
        enemySpawners = GameObject.FindGameObjectsWithTag("EnemySpawner");
        //towerSpawners = GameObject.FindGameObjectsWithTag("TowerSpawner");
    }

    void Update()
    {
        countdownText.text = ""+ countdown;
        if (gameStart)
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0)
            {
                countdown = 15f;
                SpawnTowers();
                SpawnEnemys();
            }
        }
    }

    private void SpawnTowers()
    {
        towerSpawners = GameObject.FindGameObjectsWithTag("TowerSpawner");
        foreach (GameObject tower in towerSpawners)
        {
            tower.GetComponent<TowerSpawnScript>().Spawn();
        }
    }

    private void SpawnEnemys()
    {
        //enemySpawners = GameObject.FindGameObjectsWithTag("EnemySpawner");
        foreach (GameObject enemy in enemySpawners)
        {
            enemy.GetComponent<EnemySpawnScript>().Spawn();
        }
    }
}
