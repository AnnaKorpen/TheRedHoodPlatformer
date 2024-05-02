using System;
using UnityEngine;

public class EnemyStateCreator : MonoBehaviour
{
    [NonSerialized]public EnemyStateSO instance;

    private void Awake()
    {
        instance = ScriptableObject.CreateInstance<EnemyStateSO>();
    }
}
