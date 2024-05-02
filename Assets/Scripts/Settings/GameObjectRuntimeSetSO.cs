using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Collections/GameObject Runtime Set", order = 51)]
public class GameObjectRuntimeSetSO : ScriptableObject
{
    private List<GameObject> items = new List<GameObject>();
    
    public List<GameObject> Items => items;

    public void Add(GameObject item)
    {
        if(!items.Contains(item))
        {
            items.Add(item);
        }
    }

    public void Remove(GameObject item)
    {
        if(items.Contains(item))
        {
            items.Remove(item);
        }
    }

    public void Clear()
    {
        items.Clear();
    }
}
