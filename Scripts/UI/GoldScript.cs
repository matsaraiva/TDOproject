using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class GoldScript : MonoBehaviour
{
    public float gold;
    public float income;

    [SerializeField]
    private Text goldText;

    private void Start()
    {
        StartCoroutine(GoldPerTime());
    }


    private void Update()
    {
        goldText.text = "Gold: " + (int)gold;

        if (Input.GetKeyDown("i"))
        {
            if (gold >= 50)
            {
                gold -= 50;
                income += 5;
            }
        }
    }

    private IEnumerator GoldPerTime()
    {
        while(true)
        {
            yield return new WaitForSeconds(12);
            gold += (10 + income);
        }
    }


}
