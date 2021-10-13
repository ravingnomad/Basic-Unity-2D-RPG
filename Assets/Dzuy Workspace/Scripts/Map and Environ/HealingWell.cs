using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingWell : MonoBehaviour {

    public DialogueSentences dialogue;
    public bool playerInRange;

    private DialogueManager dialogueManager;
    private PlayerHealth playerHealthScript;
    private Animator animator;
    private SFXManager sfxManager;

    void Start()
    {
        playerHealthScript = FindObjectOfType<PlayerHealth>();
        dialogueManager = FindObjectOfType<DialogueManager>();
        animator = dialogueManager.animator;
        sfxManager = FindObjectOfType<SFXManager>();
        playerInRange = false;
    }



    private void Update()
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
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
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
        playerHealthScript.SetMaxHealth();
    }
}
