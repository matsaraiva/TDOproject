using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class GameController : MonoBehaviour
{
    public bool isGameEnd = false;

    [SerializeField]
    private GameObject _endGameScreenGO;

    [SerializeField]
    private Text endGameText;

    private void Start()
    {
        _endGameScreenGO.SetActive(false);
    }

    public void GameEnd(string winer)
    {
        isGameEnd = true;
        endGameText.text = winer + " WON!";
        _endGameScreenGO.SetActive(true);
    }
}
