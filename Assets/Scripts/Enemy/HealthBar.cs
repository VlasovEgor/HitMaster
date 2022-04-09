using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Transform _scaleTransfrom;
    [SerializeField] private Transform _target;

    private Transform _cameraTransfrom;

    void Start()
    {
        _cameraTransfrom = Camera.main.transform;
    }

    void LateUpdate()
    {
        transform.position = _target.position+Vector3.up*2.5f;
        transform.LookAt(_cameraTransfrom);
    }

    public void SetHealth(int currentHealth,int maxHealth)
    { 
        float xScale = (float)currentHealth / maxHealth;
        xScale = Mathf.Clamp01(xScale);
        _scaleTransfrom.localScale = new Vector3(xScale, 1f, 1f); 
    }
}