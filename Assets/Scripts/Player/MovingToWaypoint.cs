using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class MovingToWaypoint : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private WaypointsList _waypointsList;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private EventManager _eventManager;

    private int _indexCurrentWaypoint = 1;


    private void Start()
    {
        _eventManager.LevelPassed += OnLevelPassed;
        _eventManager.GameStarted += MovementToSpecifiedWaypoint;
    }

   
    private void Update()
    {
        if (_navMeshAgent.hasPath == false)
        {  
            _playerAnimator.SetBool("Running", false);
        }
        else
        {
            _playerAnimator.SetBool("Running", true);
        }


    }

    private void OnLevelPassed()
    {
        _indexCurrentWaypoint++;
        CheckingEndLevel();
        MovementToSpecifiedWaypoint();
    }

    private void CheckingEndLevel()
    {
        if (_indexCurrentWaypoint >= _waypointsList.GetCountList())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void MovementToSpecifiedWaypoint()
    {
        _playerAnimator.SetBool("Running", true);
        _navMeshAgent.SetDestination(_waypointsList.GetWaypointsElemtsPosition(_indexCurrentWaypoint));
        
    }
    private void OnDisable()
    {
        _eventManager.LevelPassed -= OnLevelPassed;
    }

}