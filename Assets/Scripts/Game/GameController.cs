﻿public class GameController
{
    public delegate void Func();
    public static event Func OnGameStart;
    public static event Func OnGameOver;

    static bool isGameStart;

    public static bool IsGameStart {  get { return isGameStart; } }


    static void _FireEvent_OnGameStart()
    {
        if (OnGameStart != null)
        {
            OnGameStart();
        }
    }

    static void _FireEvent_OnGameOver()
    {
        if (OnGameOver != null)
        {
            OnGameOver();
        }
    }

    public static void GameStart()
    {
        if (isGameStart) { return;  }
        isGameStart = true;
        _FireEvent_OnGameStart();
    }

    public static void GameOver()
    {
        if (!isGameStart) { return;  }
        isGameStart = false;
        _FireEvent_OnGameOver();
    }
}
