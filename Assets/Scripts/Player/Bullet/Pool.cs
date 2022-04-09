using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private GameObject _prefabPoolObject;
    [SerializeField] private Transform _containerPrefabs;
    [SerializeField] private bool _autoExpand;
    
    [SerializeField] private int _poolCount = 3;

    private List<GameObject> _poolObjectList;

    private void Start()
    {
        CreatePool();
    }

    private void CreatePool()
    {
        _poolObjectList = new List<GameObject>();
        for (int i = 0; i < _poolCount; i++)
        {
            CreateElement();

        }
    }

    private GameObject CreateElement(bool isActiveByDefalut = false)
    {
        var createdObject = Instantiate(_prefabPoolObject, _containerPrefabs);
        createdObject.gameObject.SetActive(isActiveByDefalut);
        _poolObjectList.Add(createdObject);

        return createdObject;
    }

    public bool TryGetElement(out GameObject element)
    {
        foreach (var item in _poolObjectList)
        {
            if (item.gameObject.activeInHierarchy == false)
            {
                element = item;
                item.gameObject.SetActive(true);
                return true;
            }
        }

        element = null;
        return false;
    }

    public GameObject GetFreeElement()
    {
        if (TryGetElement(out var element))
        {
            return element;
        }

        if (_autoExpand)
        {
            return CreateElement(true);
        }

        throw new System.Exception("Pool is over!");

    }
}
