using UnityEngine;


public class Bullet : MonoBehaviour
{
    [SerializeField] private int _bulletDamage;
    [SerializeField] private Rigidbody _bulletRigidbody;

    private Shooter _shooter;
    private Vector3 _flightDirection;
    private int _bulletSpeed;

    private void Start() 
    {
        _shooter = FindObjectOfType<Shooter>();
        _shooter.BulletFired += OnBulletFired;
        _bulletRigidbody.velocity = _flightDirection.normalized * _bulletSpeed * -1;
    }

    private void OnBulletFired(Vector3 directionBulletFlight, int bulletSpeed)
    {
        _flightDirection = directionBulletFlight;
        _bulletSpeed = bulletSpeed;
    }

    private void OnEnable()
    {
        _shooter = FindObjectOfType<Shooter>();
        _bulletRigidbody.velocity = _flightDirection.normalized * _bulletSpeed * -1;
    }
 
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent(out IDamageable damageable))
        {
            damageable.ApplyDamage(_bulletDamage);
        }
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        _shooter.BulletFired -= OnBulletFired;
    }
}
