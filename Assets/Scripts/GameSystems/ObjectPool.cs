using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject objectToPool;
    [SerializeField] private int amountToPool;

    private List<GameObject> pooledObjects;

    private void Awake()
    {
        InstantiatePooledObjects();
    }

    private void InstantiatePooledObjects()
    {
        pooledObjects = new List<GameObject>();
        GameObject pooledObject;

        for (int i = 0; i < amountToPool; i++)
        {
            pooledObject = Instantiate(objectToPool, transform);
            pooledObject.SetActive(false);
            pooledObjects.Add(pooledObject);

        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        return null;
    }

    public int GetObjectAmount()
    {
        return amountToPool;
    }
}
