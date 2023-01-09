using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomListMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private RoomListing _roomListing;
    [SerializeField]
    private Transform _content;

    private List<RoomListing> _listings = new List<RoomListing>();

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo info in roomList)
        {
            //removido de rooms list
            if (info.RemovedFromList)
            {
                //https://www.youtube.com/watch?v=AbGwORylKqo&list=PLkx8oFug638oMagBH2qj1fXOkvBr6nhzt&index=18
                //12min
                int index = _listings.FindIndex(x => x.roomInfo.Name == info.Name);
                if (index != -1)
                {
                    Destroy(_listings[index].gameObject);
                    _listings.RemoveAt(index);
                }
            }
            //adicionado a rooms list
            else
            {
                RoomListing listing = Instantiate(_roomListing, _content);

                if (listing != null)
                {
                    listing.SetRoomInfo(info);
                    _listings.Add(listing);

                }
            }

            
            
        }
    }

}
