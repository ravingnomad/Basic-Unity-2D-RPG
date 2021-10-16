using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyManager : MonoBehaviour {


    public List<string> destroyList;
    public static bool Exists;

    private void Start()
    {
        if (!Exists)
        {
            Exists = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        foreach (string g in destroyList)
        {
            Destroy(GameObject.Find(g));
        }
    }


    public void AddToList(string objectName)
    {
        if (destroyList.Contains(objectName) == false)
        {
            destroyList.Add(objectName);
        }
    }
}
