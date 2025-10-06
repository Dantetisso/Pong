using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class MainMenuScript : MonoBehaviourPunCallbacks
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;
    
    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    private void StartGame()    // crea la partida
    {
        SceneLoader.LoadScene(GameStates.Gameplay);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
