using System;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] Transform ballSpawnPoint;
    private int greenPoits;
    private int redPoints;
    public event Action<int> OnGreenPointsChanged;
    public event Action<int> OnRedPointsChanged;

    private void Start()
    {
      //  StartGame();
    }

    private void StartGame()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Instantiate(playerPrefab.name, spawnPoints[0].position, Quaternion.identity);
            PhotonNetwork.Instantiate(ballPrefab.name, ballSpawnPoint.position, Quaternion.identity);
        } 
    }

    public void AddPointsGreen(int newPoints)
    {
        greenPoits += newPoints;
        OnGreenPointsChanged?.Invoke(greenPoits);

        if (greenPoits >= 5)
        {
            Victory();
        }
    }
    
    public void AddPointsRed(int newPoints)
    {
        redPoints  += newPoints;
        OnRedPointsChanged?.Invoke(redPoints);
        
        if (redPoints >= 5)
        {
            Victory();
        }
    }

    public void Victory()
    {
        SceneLoader.LoadScene(GameStates.Victory);
    }
}
