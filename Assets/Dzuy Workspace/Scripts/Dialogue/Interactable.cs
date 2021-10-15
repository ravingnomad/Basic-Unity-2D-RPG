using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public DialogueSentences dialogue;
    public DialogueManager dialogueManager;



	protected virtual void Start () {
		dialogueManager = FindObjectOfType<DialogueManager>();
	}


    protected void startDialogue()
    {
        dialogueManager.LoadSentencesToQueue(dialogue);
        StopAllCoroutines();
        StartCoroutine(progressDialogue());
    }


    protected IEnumerator progressDialogue()
    {
        while (dialogueManager.dialogueBoxStillOpen() == true)
        {
            if (Input.inputString == "e")
            {
                dialogueManager.DisplayNextSentence();
            }
            else if (Input.inputString == "q")
            {
                dialogueManager.EndDialogue();
            }
            yield return null;
        }
        StopAllCoroutines();
    }
}
