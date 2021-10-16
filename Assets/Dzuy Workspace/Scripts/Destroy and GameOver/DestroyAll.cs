using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAll : MonoBehaviour
{

    void Start()
    {
        var destroy = new GameObject("temp");
        DontDestroyOnLoad(destroy);
        foreach (var x in destroy.scene.GetRootGameObjects())
        {
            Destroy(x);
        }
    }

}
