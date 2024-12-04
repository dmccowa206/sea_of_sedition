using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DontDestroyOnLoadManager
{
    static List<GameObject> ddol_Objects = new();

    public static void DontDestroyOnLoad(this GameObject go)
    {
       UnityEngine.Object.DontDestroyOnLoad(go);
       ddol_Objects.Add(go);
    }

    public static GameManager GetGameManager()
    {
        foreach(var go in ddol_Objects)
        {
            if(go != null)
            {
                if (go.GetComponent<GameManager>() != null)
                {
                    return go.GetComponent<GameManager>();
                }
            }
        }
        return null;
    }
}
