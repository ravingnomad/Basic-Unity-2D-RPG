using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAll : MonoBehaviour
{

    void Start()
    {
        DontDestroyOnLoadManager.DestroyAll();
    }

}
