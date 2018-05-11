using UnityEngine;
using UnityEngine.SceneManagement;

public class UILogic : MonoBehaviour
{
    public void GameStart()
    {
        GameController.GameStart();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        Global.Reset();
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
