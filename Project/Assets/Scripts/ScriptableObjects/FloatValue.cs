using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatValue : ScriptableObject, ISerializationCallbackReceiver
{
    public float initialValue;

    [HideInInspector]
    public float RuntimeValue;

    public void OnAfterDeserialize()
    {
        RuntimeValue = initialValue;
      //  throw new System.NotImplementedException();
    }

    public void OnBeforeSerialize()
    {
       // throw new System.NotImplementedException();
    }
}
