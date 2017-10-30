using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcTalk : MonoBehaviour {
    public Dialogue dialogue;
    public bool in_dialogue = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Entered NPC range");
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        Animator animator = FindObjectOfType<DialogueManager>().animator;
        if (other.gameObject.tag == "Player")
        {
            if (Input.inputString == "e" && animator.GetBool("IsOpen") == false)
            {
                Debug.Log("Enter dialogue");
                if (in_dialogue == false)
                {
                    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                }
            }
            else if (Input.inputString == "e" && animator.GetBool("IsOpen") == true)
            {
                FindObjectOfType<DialogueManager>().DisplayNextSentence();
            }
            else if (Input.inputString == "q" && animator.GetBool("IsOpen") == true)
            {
                FindObjectOfType<DialogueManager>().EndDialogue();
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        FindObjectOfType<DialogueManager>().EndDialogue();
    }
}
