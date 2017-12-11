using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Slider healthBar;
    public PlayerHealth health;

<<<<<<< HEAD
    public static bool UIExists;
=======
    private static bool UIExists;
>>>>>>> origin/master
	// Use this for initialization
	void Start () {
        if (!UIExists)
        {
            UIExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }

        else {
            Destroy(gameObject);
        }
        health = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        healthBar = GetComponentInChildren<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        healthBar.maxValue = health.MaxHealth;
        healthBar.value = health.CurrentHealth;
        if (health.dead == true)
        {
            Destroy(gameObject);
        }
	}
}
