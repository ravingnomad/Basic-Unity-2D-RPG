using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyManager : MonoBehaviour {

    // Use this for initialization
    public List<string> list;

    public static bool Exists;

    private void Start()
    {
        if (!Exists)
        {
            Exists = true;
            DontDestroyOnLoad(transform.gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        foreach (string g in list)
        {

            Destroy(GameObject.Find(g));
        }
    }
    public void AddToList(string g)
    {
        if (list.Contains(g) == false)
        {
            list.Add(g);
        }
    }
}
