using System;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class ConnectionManager : MonoBehaviourPunCallbacks
{
    public static ConnectionManager Instance { get; private set; }
    public Action OnConnectedToServer;
    public Action OnJoinedRoomEvent;
    public Action<List<RoomInfo>> OnNewRoomCreated;
    public Action<Player> OnPlayerEnteredRoomEvent;
    public Action<Player> OnPlayerLeftRoomEvent;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        PhotonNetwork.AutomaticallySyncScene = true; // para que le cargue a todos los jugadores a la vez
    }

    public void SetNickName(string NickName)
    {
        PhotonNetwork.NickName = NickName;
    }

    public void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToServer");
        OnConnectedToServer?.Invoke();
    }

    public void JoinLobby()
    {
        PhotonNetwork.JoinLobby();
    }

    public void CreateRoom(string roomName)
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;

        PhotonNetwork.CreateRoom(roomName, roomOptions);
    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public override void OnJoinedRoom()
    {
        OnJoinedRoomEvent?.Invoke();
        Debug.Log("OnJoinedRoom");
    }

    public Room GetCurrentRoom() { return PhotonNetwork.CurrentRoom; }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        OnNewRoomCreated?.Invoke(roomList);
    }

    public void LeaveRoom() { PhotonNetwork.LeaveRoom(); }

    public Dictionary<int, Player> GetPlayersInRoom()
    {
        return PhotonNetwork.CurrentRoom.Players;
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        OnPlayerEnteredRoomEvent?.Invoke(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        OnPlayerLeftRoomEvent?.Invoke(otherPlayer);
    }

}