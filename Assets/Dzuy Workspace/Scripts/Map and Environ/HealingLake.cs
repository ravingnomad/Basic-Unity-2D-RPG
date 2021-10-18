using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingLake : Interactable {

    private PlayerHealth playerHealthScript;
    private SFXManager sfxManager;


    protected override void Start()
    {
        base.Start();
        playerHealthScript = FindObjectOfType<PlayerHealth>();
        sfxManager = FindObjectOfType<SFXManager>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            healPlayer();
            dialogueManager.LoadSentencesToQueue(dialogue);
            dialogueManager.DisplayNextSentence();
            StartCoroutine(progressDialogue());
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            dialogueManager.EndDialogue();
        }
    }


    void healPlayer()
    {
        sfxManager.healing.Play();
        playerHealthScript.SetMaxHealth();
    }
}

