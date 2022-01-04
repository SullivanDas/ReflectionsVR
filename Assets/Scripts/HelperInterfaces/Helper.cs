using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper 
{
    public static MonoBehaviour CheckForInterface<T>(GameObject objectToCheck)
    {
        MonoBehaviour[] monoBehaviours = objectToCheck.GetComponents<MonoBehaviour>();
        foreach(MonoBehaviour mb in monoBehaviours)
        {
            if(mb is T)
            {
                return mb;
            }
        }

        return null;
    }
}
