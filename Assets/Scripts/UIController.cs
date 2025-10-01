 using System;
 using UnityEngine;
 using TMPro;

 public class UIController : MonoBehaviour
 {
     [Header("Texts")]
     [SerializeField] private TMP_Text bluePointsText;
     [SerializeField] private TMP_Text redPointsText;
     [SerializeField] private TMP_Text gameTime;
     
     [Header("Gamemanager")]
     [SerializeField] private GameManager gameManager;

    private void Start()
    {
        gameManager.OnBluePointsChanged += UpdateBluePointsText;
        gameManager.OnRedPointsChanged += UpdateRedPointsText;
        
        bluePointsText.text = "Blue Points: ";
        redPointsText.text = "Red Points: ";
    }


     private void UpdateBluePointsText(int  points)
     {
         bluePointsText.text = "Blue Points: " + points.ToString();
     }
     
     private void UpdateRedPointsText(int  points)
     {
         redPointsText.text = "Red Points: " + points.ToString();
     }

     private void OnDisable()
     {
         gameManager.OnBluePointsChanged -= UpdateBluePointsText;
         gameManager.OnRedPointsChanged -= UpdateRedPointsText;
     }
 }
