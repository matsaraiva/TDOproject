using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructScript : MonoBehaviour
{
    private GameObject gameManager;
    private GoldScript gold;

    public GameObject[] towerSpawners;

    private bool _unlocked = true;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gold = gameManager.GetComponent<GoldScript>();
    }

    private void OnMouseDown()
    {
        if (_unlocked)
        {
            if (gold.gold >= 10)
            {
                gold.gold -= 10;
                Instantiate(towerSpawners[0], transform);
                _unlocked = false;
            }
        }
        
    }
}
