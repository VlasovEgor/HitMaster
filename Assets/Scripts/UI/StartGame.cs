using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private EventManager _eventManager;

    public void StartingLevel()
    {
        _eventManager.OnGameStarted();
        gameObject.SetActive(false);
    }
}
