using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{

    [SerializeField] private EventManager _eventManager;
    [SerializeField] private List<Enemy> _enemyList = new List<Enemy>();

    private int _numberLiveEnemies;

    private void Start()
    {
        _numberLiveEnemies = _enemyList.Count;
        for (int i = 0; i < _enemyList.Count; i++)
        {
            _enemyList[i].DiedEnemy += OnEnemyDied;
        }
    }

    private void OnEnemyDied()
    {
        _numberLiveEnemies--;
        if(_numberLiveEnemies<=0)
        {
            _eventManager.OnLevelPassed();
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _enemyList.Count; i++)
        {
            _enemyList[i].DiedEnemy -= OnEnemyDied;
        }
    }


}
