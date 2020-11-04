using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour {

    public string previous;
    public string current;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (previous == null)
        {
            current = SceneManager.GetActiveScene().name;
            previous = current;
        }
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += Spawn;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= Spawn;
    }
    void Spawn(Scene scene, LoadSceneMode mode)
    {
        previous = current;
        current = SceneManager.GetActiveScene().name;
        if (string.Compare(previous, current) < 0)
        {
            Destroy(GameObject.Find("Start Point 2"));
        }
        else
        {
            Destroy(GameObject.Find("Start Point 1"));
        }
    }
}
