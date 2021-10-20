using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class DialogueManager : MonoBehaviour {

    public static bool Exists;
    public Animator animator;
    public Text nameText;
    public Text dialogueText;

    private Queue<string> sentenceQueue;
	

	void Start () {
        if (!Exists)
        {
            Exists = true;
            DontDestroyOnLoadManager.SetDontDestroy(this.gameObject);
            sentenceQueue = new Queue<string>();
        }
        else
        {
            Destroy(gameObject);
        }
	}


    public void LoadSentencesToQueue(DialogueSentences dialogue)
    {
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.objectName;
        sentenceQueue.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentenceQueue.Enqueue(sentence);
        }
    }


    public void DisplayNextSentence()
    {
        if (sentenceQueue.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentenceQueue.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }


    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        
        foreach (char letter in sentence)
        {
            dialogueText.text += letter;
            yield return null;
        }
    }


    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        sentenceQueue.Clear();
    }


    public bool dialogueBoxStillOpen()
    {
        return animator.GetBool("IsOpen");
    }
}
