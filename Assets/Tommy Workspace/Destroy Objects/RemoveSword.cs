using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveSword : MonoBehaviour
{


    void Update()
    {
        if (GameObject.Find("Dialogue Box").GetComponent<Animator>().GetBool("IsOpen") == true)
        {
            FindObjectOfType<PlayerAttack>().hasSword = true;
            FindObjectOfType<DestroyManager>().AddToList(this.name);
            Destroy(gameObject);
        }
    }
}

