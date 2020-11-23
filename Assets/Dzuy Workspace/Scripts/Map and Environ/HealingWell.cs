using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingWell : MonoBehaviour {

    public Dialogue dialogue;
    public bool in_range = false;
    public PlayerHealth health;

    private SFXManager sfx;

    void Start()
    {
        sfx = FindObjectOfType<SFXManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            health = FindObjectOfType<PlayerHealth>();
            health.CurrentHealth = health.MaxHealth;
            in_range = true;
        }
    }

    private void Update()
    {

        if (in_range == true && Input.inputString == "e")
        {
            Animator animator = FindObjectOfType<DialogueManager>().animator;
            if (animator.GetBool("IsOpen") == false)
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                sfx.healing.Play();
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
            if (other.gameObject.tag == "Player")
            {
                in_range = true;
            }
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
