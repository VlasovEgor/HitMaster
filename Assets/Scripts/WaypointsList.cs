using System.Collections.Generic;
using UnityEngine;

public class WaypointsList : MonoBehaviour
{
    [SerializeField] private List<GameObject> _waypointsList = new List<GameObject>();

    public Vector3 GetWaypointsElemtsPosition(int ElementIndex)
    {
        return _waypointsList[ElementIndex].transform.position;
    }

    public int GetCountList()
    {
        return _waypointsList.Count;
    }
}
