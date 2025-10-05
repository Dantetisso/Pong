using System;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviourPunCallbacks
{
    private int bluepoints;
    private int redPoints;
    public event Action<int> OnBluePointsChanged;
    public event Action<int> OnRedPointsChanged;
    
    void Start()
    {
        
    }

    void Update()
    {
    }

    public void AddPointsBlue(int newPoints)
    {
        bluepoints  += newPoints;
        OnBluePointsChanged?.Invoke(bluepoints);
        
       /* if (bluepoints >=20)
        {
            Victory();
        }*/
    }
    
    public void AddPointsRed(int newPoints)
    {
        redPoints  += newPoints;
        OnRedPointsChanged?.Invoke(redPoints);
        
       /* if (redPoints >=20)
        {
            Victory();
        }*/
    }

    public void Victory()
    {
        SceneLoader.LoadScene(GameStates.Victory);
    }
}
