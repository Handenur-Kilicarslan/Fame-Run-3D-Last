using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public static Action OnGameStart;
    public static Action OnGameWin;
    public static Action OnGameLose;
   public void StartGame()
    {
        OnGameStart?.Invoke();
    }
}
