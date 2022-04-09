using System;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public event Action<Vector3, int> BulletFired;

    [SerializeField] private Transform _startShot;
    [SerializeField] private EventManager _eventManager;
    [SerializeField] private int _bulletSpeed = 10;
    [SerializeField] private float _shotPeriod = 1;
    [SerializeField] private Pool _pool;

    private float _timer;
    private bool IsShot = false;

    private Vector3 _directionBulletFlight;
    private Vector3 _enemyPosition;
    
    private void Start()
    {
        _eventManager.ClickedEnemy += OnClickedEnemy;
    }

    private void OnClickedEnemy(Vector3 enemyPosition)
    {
        _enemyPosition = enemyPosition;
        CheckingForPossibilityOfShot();
    }

    private void CheckingForPossibilityOfShot()//переименовать
    {
        if (Input.touchCount > 0 && IsShot == false)
        {
            Shot();
        }
    }

    private void Shot()
    {
        IsShot = true;
        _timer = 0;
        _directionBulletFlight = _startShot.position - _enemyPosition;
        BulletFired?.Invoke(_directionBulletFlight, _bulletSpeed);
        CreateBullet();
    }

    private void CreateBullet()
    {
        var bullet = _pool.GetFreeElement();
        bullet.transform.position = _startShot.position;
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _shotPeriod)
        {
            IsShot = false;
        }
    }

    private void OnDisable()
    {
        _eventManager.ClickedEnemy -= OnClickedEnemy;
    }
}