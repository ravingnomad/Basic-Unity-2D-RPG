using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyManager : MonoBehaviour {

    // Use this for initialization
    public List<string> list;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
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
