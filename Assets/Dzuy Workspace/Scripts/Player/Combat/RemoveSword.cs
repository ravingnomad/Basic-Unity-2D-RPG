using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveSword : MonoBehaviour
{


    void Update()
    {
        var DialogueBox = GameObject.Find("Dialogue Box");
        if (DialogueBox != null && DialogueBox.GetComponent<Animator>().GetBool("IsOpen") == true)
        {
            FindObjectOfType<PlayerAttack>().hasSword = true;
            FindObjectOfType<DestroyManager>().AddToList(this.name);
            Destroy(gameObject);
        }
    }
}

