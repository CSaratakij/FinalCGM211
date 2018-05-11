using UnityEngine;

public enum View
{
    MainMenu,
    InGameMenu,
    GameOverMenu
}

public class GameMenuController : MonoBehaviour
{
    [SerializeField]
    RectTransform[] views;


    void Awake()
    {
        GameController.OnGameStart += _OnGameStart;
        GameController.OnGameOver += _OnGameOver;
    }

    void Start()
    {
        Show(View.MainMenu);
    }

    void OnDestroy()
    {
        GameController.OnGameStart -= _OnGameStart;
        GameController.OnGameOver -= _OnGameOver;
    }

    void _OnGameStart()
    {
        Show(View.InGameMenu);
    }

    void _OnGameOver()
    {
        Show(View.GameOverMenu);
    }

    void _HideAllView()
    {
        foreach (RectTransform rect in views)
        {
            rect.gameObject.SetActive(false);
        }
    }

    public void Show(View view)
    {
        _HideAllView();
        views[(int)view].gameObject.SetActive(true);
    }
}
