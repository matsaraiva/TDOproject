using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerSpawnerScript : MonoBehaviourPunCallbacks
{
    private GameObject gameManager;
    private GoldScript gold;

    public GameObject[] creeps;

    [SerializeField]
    private int actorOwner;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gold = gameManager.GetComponent<GoldScript>();
    }

 
    private void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            Debug.Log(PhotonNetwork.LocalPlayer.ActorNumber);
        }

        //se for o dono do objeto
        if (PhotonNetwork.LocalPlayer.ActorNumber  == actorOwner)
        {
            if (Input.GetKeyDown("1"))
            {
                if (gold.gold >= 10)
                {
                    gold.gold -= 10;
                    //Instantiate(creeps[0], transform);
                    Spawn(creeps[0].name);
                    //PhotonNetwork.InstantiateRoomObject(creeps[0].name, this.transform.position, Quaternion.identity);
                }
            }
            if (Input.GetKeyDown("2"))
            {
                if (gold.gold >= 20)
                {
                    gold.gold -= 20;
                    //Instantiate(creeps[0], transform);
                    Spawn(creeps[1].name);
                    //PhotonNetwork.InstantiateRoomObject(creeps[0].name, this.transform.position, Quaternion.identity);
                }
            }
            if (Input.GetKeyDown("2"))
            {
                if (gold.gold >= 40)
                {
                    gold.gold -= 40;
                    Spawn(creeps[2].name);
                }
            }
        }
    }

    private void Spawn(string creepname)
    {
        PhotonNetwork.Instantiate(creepname, this.transform.position, Quaternion.identity);
    }
}
