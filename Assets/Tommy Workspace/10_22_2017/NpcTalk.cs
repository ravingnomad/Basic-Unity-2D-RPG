using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (other.gameObject.tag == "Player")
        {
            if (Input.inputString == "e")
            {
                Debug.Log("Enter dialogue");
                if (in_dialogue == false)
                {
                    in_dialogue = true;
                    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                    in_dialogue = false;
                }
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        FindObjectOfType<DialogueManager>().EndDialogue();
    }
}
