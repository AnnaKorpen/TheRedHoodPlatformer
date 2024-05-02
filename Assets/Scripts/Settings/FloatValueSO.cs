using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Float Value", order = 51)]
public class FloatValueSO : ScriptableObject, ISerializationCallbackReceiver
{
    public float initialValue;

    [NonSerialized]
    public float runtimeValue;

    public void OnAfterDeserialize()
    {
        runtimeValue = initialValue;
    }

    public void OnBeforeSerialize(){}

}
