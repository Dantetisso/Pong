using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class MainMenuScript : MonoBehaviourPunCallbacks
{
    [SerializeField ]private Button startButton;
    [SerializeField ]private Button quitButton;
    
    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    void Update()
    {
        
    }

    private void StartGame()
    {
        SceneLoader.LoadScene(GameStates.Gameplay);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
