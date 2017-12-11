using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcTalk : MonoBehaviour
{
    public Dialogue dialogue;
    public bool in_range = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Entered NPC range");
        }
    }
    private void Update()
    {

        if (in_range == true)
        {
            Animator animator = FindObjectOfType<DialogueManager>().animator;
            if (Input.inputString == "e" && animator.GetBool("IsOpen") == false)
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
<<<<<<< HEAD
=======

>>>>>>> origin/master
            FindObjectOfType<DialogueManager>().EndDialogue();
            in_range = false;
        }
    }
}
