using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingLake : MonoBehaviour {

    public DialogueSentences dialogue;
    public bool playerInRange;
    public PlayerHealth playerHealthScript;
    public bool playerEnteredLake;

    private SFXManager sfxManager;
    private Animator animator;
    private DialogueManager dialogueManager;

    void Start()
    {
        playerInRange = false;
        playerHealthScript = FindObjectOfType<PlayerHealth>();
        sfxManager = FindObjectOfType<SFXManager>();
        dialogueManager = FindObjectOfType<DialogueManager>();
        animator = dialogueManager.animator;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            healPlayer();
            playerInRange = true;
            playerEnteredLake = true;
            sfxManager.healing.Play();
        }
    }
    private void Update()
    {
        if (playerInRange == true && playerEnteredLake == true)
        {
            if (animator.GetBool("IsOpen") == false)
            {
                dialogueManager.StartDialogue(dialogue);
            }
            else if (Input.inputString == "e" && animator.GetBool("IsOpen") == true)
            {
                dialogueManager.DisplayNextSentence();
                if (animator.GetBool("IsOpen") == false)
                {
                    playerEnteredLake = false;
                }
            }
            else if (Input.inputString == "q" && animator.GetBool("IsOpen") == true)
            {
                dialogueManager.EndDialogue();
                playerEnteredLake = false;
            }
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

