using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class RoomListing : MonoBehaviour
{
    [SerializeField]
    private Text _text;

    public RoomInfo roomInfo { get; private set; }

    public void SetRoomInfo(RoomInfo info)
    {
        roomInfo = info;
        _text.text = info.Name;
    }
}
