using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemies : MonoBehaviour {

    public static List<GameObject> enemies = new List<GameObject>();
    private static List<GameObject> graveyard = new List<GameObject>();
    public static DestroyEnemies destroy;

    private bool exists;
    // Use this for initialization
    void Start () {

        if (destroy == null)
        {
            DontDestroyOnLoad(gameObject);
            destroy = this;
        }

        else if (destroy != this)
        {
            Destroy(gameObject);
        }

        foreach (GameObject x in enemies)
        {
            if (x != null && x.GetComponent<EnemyHealth>().dead == true)
            {
                graveyard.Add(x);
            }
        }

    }


    public void AddToList(GameObject enemy)
    {
        if (enemies.Contains(enemy) == false)
            enemies.Add(enemy);
        else
            Destroy(enemy);
    }

    // Update is called once per frame
    void Update ()
    {
        if (graveyard.Count != 0)
        {
            foreach (GameObject x in graveyard)
            {
                Destroy(x);
            }
        }
    }
}
