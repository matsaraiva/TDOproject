using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class NetworkController : MonoBehaviourPunCallbacks
{
    [Header("GO")]

    [SerializeField] 
    private GameObject _loginGO;
    [SerializeField] 
    private GameObject _roomsGO;
    [SerializeField]
    private GameObject _roomGO;
    [SerializeField]
    private GameObject _registerGO;

    private GameObject _gameManager;

    [Header("Player")]

    [SerializeField] 
    private GameObject _playerPrefab;
    [SerializeField] 
    private InputField _guestPlayerInput;
    string _playerNameTemp;

    [Header("Room")]

    [SerializeField] 
    private InputField _roomInputName;
    private void Start()
    {
        //PhotonNetwork.ConnectUsingSettings();
        _playerNameTemp = "Player" + Random.Range(0, 9) + Random.Range(0, 9) + Random.Range(0, 9);

        _loginGO.gameObject.SetActive(true);
        _roomsGO.gameObject.SetActive(false);
        _roomGO.gameObject.SetActive(false);
        _registerGO.gameObject.SetActive(false);

        _gameManager = GameObject.Find("GameManager");

        
    }

    public void GuestLogin()
    {
        if (_guestPlayerInput.text!="")
        {
            PhotonNetwork.NickName = "Guest " + _guestPlayerInput.text;
        }
        else { PhotonNetwork.NickName = "Guest " + _playerNameTemp; }

        PhotonNetwork.ConnectUsingSettings();

        _loginGO.gameObject.SetActive(false);
        _roomsGO.gameObject.SetActive(true);
    }

    public void Login(string username)
    {
        PhotonNetwork.NickName = username;

        PhotonNetwork.ConnectUsingSettings();

        _loginGO.gameObject.SetActive(false);
        _roomsGO.gameObject.SetActive(true);
    }

    public void FastSearch()
    {
        if (!PhotonNetwork.IsConnected) { return; }
        PhotonNetwork.JoinRandomRoom();
    }

    public void CreateOrJoinRoom()
    {
        if (!PhotonNetwork.IsConnected) { return; }

        //nome temporario da sala
        string roomNameTemp = "Room "
            + Random.Range(0, 9) + Random.Range(0, 9) + Random.Range(0, 9);
        if (_roomInputName.text != "")
        {
            roomNameTemp = _roomInputName.text;
        }
        RoomOptions roomOptions = new RoomOptions() { MaxPlayers = 4 };

        PhotonNetwork.JoinOrCreateRoom(roomNameTemp, roomOptions, TypedLobby.Default);
    }


    // ############ PunCallbacks ############


    public override void OnConnected()
    {
        Debug.Log("OnConnected");
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster");
        Debug.Log("Server: " + PhotonNetwork.CloudRegion + " Ping: " + PhotonNetwork.GetPing());

        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("OnJoinedLobby");
    }



    public override void OnJoinedRoom()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        Debug.Log("OnJoinedRoom");
        Debug.Log("Room Name: " + PhotonNetwork.CurrentRoom.Name);
        Debug.Log("PlayerCount: " + PhotonNetwork.CurrentRoom.PlayerCount);

        _loginGO.gameObject.SetActive(false);
        _roomsGO.gameObject.SetActive(false);
        _roomGO.gameObject.SetActive(true);

        PhotonNetwork.Instantiate(_playerPrefab.name, new Vector3(0, 0, 0), Quaternion.identity);

    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        RoomOptions roomOptions = new RoomOptions() { MaxPlayers = 4 };
        string roomNameTemp = "Room "
            + Random.Range(0, 9) + Random.Range(0, 9) + Random.Range(0, 9);
        PhotonNetwork.CreateRoom(roomNameTemp, roomOptions, TypedLobby.Default);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected. Cause: " + cause);
    }

    public void StartGame()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
            //Debug.LogError("PhotonNetwork : Trying to Load a level but we are not the master Client");
        }
        Debug.LogFormat("PhotonNetwork : Loading Level whith : {0}", PhotonNetwork.CurrentRoom.PlayerCount);
        PhotonNetwork.LoadLevel(1);
    }

    public void RegisterScreenButton()
    {

        if (_loginGO.activeInHierarchy)
        {
            _loginGO.gameObject.SetActive(false);
            _registerGO.gameObject.SetActive(true);
        }
        else
        {
            _loginGO.gameObject.SetActive(true);
            _registerGO.gameObject.SetActive(false);
        }
        
    }
}
