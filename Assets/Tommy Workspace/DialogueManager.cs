using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Content derived from user Brackeys on Youtube. Pretty much identical.

public class DialogueManager : MonoBehaviour {

    public Text nameText;
    public Text dialogueText;
    public Animator animator;

    private Queue<string> sentences;
	// Use this for initialization
	void Start () {
        sentences = new Queue<string>();
	}
    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        Debug.Log("You are speaking to " + dialogue.name);
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();

        Debug.Log(sentence);
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
    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        Debug.Log("End of conversation.");
    }
}
