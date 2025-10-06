using System;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviourPunCallbacks
{
    private int greenPoits;
    private int redPoints;
    public event Action<int> OnGreenPointsChanged;
    public event Action<int> OnRedPointsChanged;
    
    public void AddPointsGreen(int newPoints)
    {
        greenPoits  += newPoints;
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
