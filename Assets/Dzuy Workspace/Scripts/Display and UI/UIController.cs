using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Slider healthBar;
    public PlayerHealth playerHealthScript;
    public static bool UIExists;

	void Start () {
        if (!UIExists)
        {
            UIExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
        playerHealthScript = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        healthBar = GetComponentInChildren<Slider>();
	}
	

	void Update () {
        healthBar.maxValue = playerHealthScript.MaxHealth;
        healthBar.value = playerHealthScript.CurrentHealth;
        if (playerHealthScript.dead == true)
        {
            Destroy(gameObject);
        }
	}
}
