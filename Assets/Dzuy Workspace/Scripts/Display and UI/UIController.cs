using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Slider healthBar;
    public PlayerHealth playerHealthScript;
    public static bool Exists;

    private Canvas uiCanvas;

	void Start () {
        if (!Exists)
        {
            Exists = true;
            DontDestroyOnLoadManager.SetDontDestroy(this.gameObject);
            playerHealthScript = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
            healthBar = GetComponentInChildren<Slider>();
            uiCanvas = GetComponent<Canvas>();
        }
        else
        {
            Destroy(gameObject);
        }
	}
	

	void Update () {
        healthBar.maxValue = playerHealthScript.MaxHealth;
        healthBar.value = playerHealthScript.CurrentHealth;
        if (playerHealthScript.dead == true)
        {
            uiCanvas.enabled = false;
        }
	}
}
