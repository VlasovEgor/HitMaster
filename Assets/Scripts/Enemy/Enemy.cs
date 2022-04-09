using System;
using UnityEngine;


public class Enemy : MonoBehaviour, IDamageable
{
    public event Action DiedEnemy;

    [SerializeField] private int _maxHealth;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody[] _allRididbody;
    [SerializeField] private Collider _collider;
    
    private EventManager _eventManager;
    private int _currentHealth;
    
    private void Awake()
    {
        for (int i = 0; i < _allRididbody.Length; i++)
        {
            _allRididbody[i].isKinematic = true;
        }
    }

    private void Start()
    {
        _eventManager = FindObjectOfType<EventManager>();
        _currentHealth = _maxHealth;

    }

    public void ApplyDamage(int damageValue)
    {
        _currentHealth -= damageValue;
        _healthBar.SetHealth(_currentHealth, _maxHealth);
        if (_currentHealth <= 0)
        {
            Die();
            
        }
    }

    private void Die()
    {
        DiedEnemy?.Invoke();
        _healthBar.gameObject.SetActive(false);
        _animator.enabled = false;
        for (int i = 0; i < _allRididbody.Length; i++)
        {
            _allRididbody[i].isKinematic = false;
            _collider.enabled = false;
        }
    }

    private void OnMouseDown()
    {
        _eventManager.OnClickedEnemy(transform.position);
    }

}
