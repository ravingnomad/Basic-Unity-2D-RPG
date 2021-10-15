using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour {

    public static bool Exists;

    private Text nameText;
    private Text dialogueText;
    public Animator animator;
    private Queue<string> sentenceQueue;
	

	void Start () {
        if (!Exists)
        {
            Exists = true;
            DontDestroyOnLoad(gameObject);
            sentenceQueue = new Queue<string>();
            animator = GameObject.FindGameObjectWithTag("Dialogue Box").GetComponent<Animator>();
            nameText = GameObject.FindGameObjectWithTag("NPC Name Text").GetComponent<Text>();
            dialogueText = GameObject.FindGameObjectWithTag("Dialogue Text").GetComponent<Text>();
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
