using System;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] private TMP_Text greenPointsText;
    [SerializeField] private TMP_Text redPointsText;

    [Header("Gamemanager")]
    [SerializeField] private GameManager gameManager;

    private void Start()
    {
        gameManager.OnBluePointsChanged += UpdateBluePointsText;
        gameManager.OnRedPointsChanged += UpdateRedPointsText;

        greenPointsText.text = "Green Points: ";
        redPointsText.text = "Red Points: ";
    }

    private void UpdateBluePointsText(int points)
    {
        greenPointsText.text = "Green Points: " + points.ToString();
    }

    private void UpdateRedPointsText(int points)
    {
        redPointsText.text = "Red Points: " + points.ToString();
    }

    private void OnDisable()
    {
        gameManager.OnBluePointsChanged -= UpdateBluePointsText;
        gameManager.OnRedPointsChanged -= UpdateRedPointsText;
    }
    
}
