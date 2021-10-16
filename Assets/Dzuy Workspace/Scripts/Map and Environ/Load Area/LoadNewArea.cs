﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadNewArea : MonoBehaviour {

    public Texture2D fadeoutTexture; //is black screen
    public float fadeSpeed = 0.0f;
    public string exitPoint;
    public string LevelToLoad;

    private int drawDepth;
    private float alpha;
    private int fadeDir;




    void Start()
    {
        drawDepth = -1000;
        alpha = 1.0f;
        fadeDir = -1;
    }


    void OnGUI()
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeoutTexture);
    }


    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return (fadeSpeed);
    }


    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLoadCallback;
    }


    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLoadCallback;
    }


    void OnLoadCallback(Scene scene, LoadSceneMode mode)
    {
        BeginFade(-1);
    }


    IEnumerator ChangeLevel()
    {
        float fade = BeginFade(1);
        yield return new WaitForSeconds(fade);
        SceneManager.LoadScene(LevelToLoad);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerMove>().StartPoint = exitPoint;
            StartCoroutine(ChangeLevel());
        }
    }        
}
