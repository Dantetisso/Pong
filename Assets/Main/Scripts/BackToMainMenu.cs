using UnityEngine;
using UnityEngine.UI;

public class BackToMainMenu : MonoBehaviour
{
    [SerializeField ]private Button backButton;
    
    void Start()
    {
        backButton.onClick.AddListener(BacktoMenu);
    }

    private void BacktoMenu()
    {
        SceneLoader.LoadScene(GameStates.Mainmenu);
    }
}
