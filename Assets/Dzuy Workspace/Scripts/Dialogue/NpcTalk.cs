using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcTalk : MonoBehaviour
{
    public DialogueSentences dialogue;
    public bool in_range = false;


    private void Update()
    {
        if (in_range == true)
        {
            DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
            if (Input.inputString == "e")
            {
                Animator animator = dialogueManager.animator;
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
                Animator animator = dialogueManager.animator;
                if (animator.GetBool("IsOpen") == true)
                {
                    dialogueManager.DisplayNextSentence();
                }
            }
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
            FindObjectOfType<DialogueManager>().EndDialogue();
            in_range = false;
        }
    }
}
