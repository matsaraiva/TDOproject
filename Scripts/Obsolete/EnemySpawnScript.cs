using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    //public GameObject[] enemyList;
    public int waveIndex = 0;
    public int lastWave;

    public List<GameObject> enemyList = new List<GameObject>();

    public GameObject infinityWaveEnemy;

    public void Spawn()
    {
        int i = 0;
        foreach (GameObject enemy in enemyList)
        {
            //random spawn posisiton in a range
            float x = transform.position.x + Random.Range(-5, 5);
            float y = transform.position.y + Random.Range(-1, 1);
            Vector2 pos = new Vector2(x, y);


            Instantiate(enemyList[i], pos, Quaternion.identity);
            i++;
        }
        NextWave();
    }


    public void NextWave()
    {
        waveIndex++;
        if (waveIndex >= lastWave)
        {
            enemyList.Add(infinityWaveEnemy);
        }
    }

}
