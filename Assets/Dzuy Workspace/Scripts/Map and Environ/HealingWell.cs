using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingWell : Interactable {

    private bool playerInRange;
    private PlayerHealth playerHealthScript;
    private SFXManager sfxManager;

    protected override void Start()
    {
        playerInRange = false;
        playerHealthScript = FindObjectOfType<PlayerHealth>();
        sfxManager = FindObjectOfType<SFXManager>();
        base.Start();
    }



    private void Update()
    {
        if (playerInRange == true && Input.inputString == "e" && dialogueManager.dialogueBoxStillOpen() == false)
        {
            healPlayer();
            startDialogue();
        }
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            playerInRange = true;
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            dialogueManager.EndDialogue();
            playerInRange = false;
        }
    }


    void healPlayer()
    {
        sfxManager.healing.Play();
        playerHealthScript.SetMaxHealth();
    }
}
