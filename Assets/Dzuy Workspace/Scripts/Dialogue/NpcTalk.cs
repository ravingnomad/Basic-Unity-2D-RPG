using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcTalk : Interactable
{
    private bool playerInRange;
    private bool playerAlreadyTalking;


    protected override void Start()
    {
        playerInRange = false;
        playerAlreadyTalking = false;
        base.Start();
    }


    private void Update()
    {
        if (playerInRange == true && Input.inputString == "e" && dialogueManager.dialogueBoxStillOpen() == false)
        {
            startDialogue();
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
}
