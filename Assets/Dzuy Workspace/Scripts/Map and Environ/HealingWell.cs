using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingWell : Interactable {

    private PlayerHealth playerHealthScript;
    private SFXManager sfxManager;

    protected override void Start()
    {
        playerHealthScript = FindObjectOfType<PlayerHealth>();
        sfxManager = FindObjectOfType<SFXManager>();
        base.Start();
    }



    /*private void Update()
    {
        if (playerInRange == true && Input.inputString == "e")
        {
            if (animator.GetBool("IsOpen") == false)
            {
                dialogueManager.StartDialogue(dialogue);
                sfxManager.healing.Play();
                healPlayer();
            }
            else if (Input.inputString == "e" && animator.GetBool("IsOpen") == true)
            {
                dialogueManager.DisplayNextSentence();
            }
            else if (Input.inputString == "q" && animator.GetBool("IsOpen") == true)
            {
                dialogueManager.EndDialogue();
            }
        }
    }*/


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && Input.inputString == "e")
        {
            healPlayer();
            startDialogue();
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
        playerHealthScript.SetMaxHealth();
    }
}
