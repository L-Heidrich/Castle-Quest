using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class Bool : ScriptableObject, ISerializationCallbackReceiver
{

    public   static bool inititalValue;
    public   bool runtimeValue;

    public void OnAfterDeserialize()
    {
        runtimeValue = inititalValue;
    }

    public void OnBeforeSerialize()
    {
    }
}


