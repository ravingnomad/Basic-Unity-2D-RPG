﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcTalk : MonoBehaviour
{
    public Dialogue dialogue;
    public bool in_range = false;

    private DialogueManager dialogueManager;
    private Animator animator;



    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        animator = dialogueManager.animator;
    }


    private void Update()
    {
        if (in_range == true)
        {
            if (Input.inputString == "e")
            {
                if (animator.GetBool("IsOpen") == false)
                {
                    dialogueManager.StartDialogue(dialogue);
                }
                else if (animator.GetBool("IsOpen") == true)
                {
                    dialogueManager.DisplayNextSentence();
                }
            }

            else if (Input.inputString == "q")
            {
                if (animator.GetBool("IsOpen") == true)
                {
                    dialogueManager.DisplayNextSentence();
                }
            }

            
            
            /*if (Input.inputString == "e" && animator.GetBool("IsOpen") == false)
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            }
            else if (Input.inputString == "e" && animator.GetBool("IsOpen") == true)
            {
                FindObjectOfType<DialogueManager>().DisplayNextSentence();
            }
            else if (Input.inputString == "q" && animator.GetBool("IsOpen") == true)
            {
                FindObjectOfType<DialogueManager>().EndDialogue();
            }*/
        }
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            in_range = true;
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            dialogueManager.EndDialogue();
            in_range = false;
        }
    }
}
