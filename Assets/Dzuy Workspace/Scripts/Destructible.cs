using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{

    public int CurrentHealth;
    public int MaxHealth;
    public bool gunOnly;

<<<<<<< HEAD
    private bool hit;
    private SFXManager sfx;
    // Use this for initialization
    void Start()
    {
        sfx = FindObjectOfType<SFXManager>();
=======
    // Use this for initialization
    void Start()
    {
>>>>>>> origin/master
        CurrentHealth = MaxHealth;
    }


    void OnTriggerEnter2D(Collider2D col)
    {
<<<<<<< HEAD
        hit = false;
        if (gunOnly == true)
        {
            if (col.gameObject.tag == "Player Bullet" && hit == false)
            {
                hit = true;
                CurrentHealth -= 50;
            }

            if (col.gameObject.tag == "Player Weapon" && hit == false)
            {
                hit = true;
                sfx.SwordHitMetal.Play();
            }
=======
        Debug.Log(col.gameObject.tag);
        if (gunOnly == true && col.gameObject.tag == "Player Bullet")
        {
            print("Hit by bullet");
            CurrentHealth -= 50;
>>>>>>> origin/master
        }

        //if was hit by the player's sword, extra damage and full knockback
        if (gunOnly == false)
        {
<<<<<<< HEAD
            if (col.gameObject.tag == "Player Weapon" && hit == false)
            {
                hit = true;
                sfx.SwordHitCrate.Play();
                CurrentHealth -= 20;
            }

            if (col.gameObject.tag == "Player Bullet" && hit == false)
            {
                hit = true;
                sfx.SwordHitCrate.Play();
                CurrentHealth -= 50;
            }
            
=======
            if (col.gameObject.tag == "Player Weapon")
                CurrentHealth -= 20;

            if (col.gameObject.tag == "Player Bullet")
                CurrentHealth -= 50;
>>>>>>> origin/master
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth <= 0)
        {
<<<<<<< HEAD
            sfx.BrokenCrate.Play();
=======
>>>>>>> origin/master
            FindObjectOfType<DestroyManager>().AddToList(gameObject.name);
            Destroy(gameObject);
        }
    }
}
