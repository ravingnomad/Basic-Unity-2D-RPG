using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{

    public int CurrentHealth;
    public int MaxHealth;
    public bool gunOnly;

    // Use this for initialization
    void Start()
    {
        CurrentHealth = MaxHealth;
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.tag);
        if (gunOnly == true && col.gameObject.tag == "Player Bullet")
        {
            print("Hit by bullet");
            CurrentHealth -= 50;
        }

        //if was hit by the player's sword, extra damage and full knockback
        if (gunOnly == false)
        {
            if (col.gameObject.tag == "Player Weapon")
                CurrentHealth -= 20;

            if (col.gameObject.tag == "Player Bullet")
                CurrentHealth -= 50;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth <= 0)
        {
            FindObjectOfType<DestroyManager>().AddToList(gameObject.name);
            Destroy(gameObject);
        }
    }
}
