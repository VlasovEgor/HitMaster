using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public event Action<Vector3> ClickedEnemy;
    public event Action LevelPassed;
    public event Action GameStarted;

    public void OnClickedEnemy(Vector3 enemyPosition)
    {
        ClickedEnemy?.Invoke(enemyPosition);
    }

    public void OnLevelPassed()
    {
        LevelPassed?.Invoke();
    }

    public void OnGameStarted()
    {
        GameStarted?.Invoke();
    }
}
