using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Content derived from user Brackeys on Youtube. Pretty much identical.

public class DialogueManager : MonoBehaviour {

    public Text objectNameText;
    public Text dialogueText;
    public Animator animator;
    public static bool Exists;

    private Queue<string> sentences;
	

	void Start () {
        if (!Exists)
        {
            Exists = true;
            DontDestroyOnLoad(gameObject);
            sentences = new Queue<string>();
            animator = GameObject.FindGameObjectWithTag("Dialogue Box").GetComponent<Animator>();
        }
        else
        {
            Destroy(gameObject);
        }
	}


    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        Debug.Log("You are speaking to " + dialogue.objectName);
        objectNameText.text = dialogue.objectName;

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
        sentences.Clear();
    }
}
