using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawnScript : MonoBehaviour
{
    public GameObject[] towerList;
    private TimeControl tc;

    public void Spawn()
    {
        Instantiate(towerList[0], transform);
    }

  


}
