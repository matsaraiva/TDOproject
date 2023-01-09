using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    private float _moveSpeed;

    private Vector2 _lastClickedPos;

    private PhotonView _photonView;

    private bool _isMoving;

    [SerializeField]
    private GameObject _playerName;

    void Start()
    {
        _photonView = GetComponent<PhotonView>();
        if (_photonView.IsMine) 
        {
            _playerName.GetComponent<TextMesh>().text = PhotonNetwork.NickName;
        }
        
    }

    void Update()
    {
        //return if is not the player controll
        if (!_photonView.IsMine) { return; }

        //pega a posição do click do mouse
        if (Input.GetMouseButton(1))
        {
            _lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _isMoving = true;
        }

        //se a posição do click for diferente do lugar atual e esta se movendo
        if (_isMoving && (Vector2)transform.position != _lastClickedPos)
        {
            //cada passo por segundo
            float step = _moveSpeed * Time.deltaTime;

            //mover
            transform.position = Vector2.MoveTowards(transform.position, _lastClickedPos, step);
            //olhar para onde clicou
            //transform.up = _lastClickedPos - (Vector2)transform.position;
        }
        else { _isMoving = false; }
    }
}
