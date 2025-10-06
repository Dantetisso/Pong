using Photon.Pun;
using UnityEngine.SceneManagement;

public enum GameStates
{
    Mainmenu,
    Gameplay,
    Lose,
    Victory
}

public class SceneLoader : MonoBehaviourPunCallbacks
{
    public static void LoadScene(GameStates state)
    {
        SceneManager.LoadScene(state.ToString());
    }

    public static void LoadSceneByPhoton(GameStates state)
    {
        PhotonNetwork.LoadLevel(state.ToString());
    }
}
