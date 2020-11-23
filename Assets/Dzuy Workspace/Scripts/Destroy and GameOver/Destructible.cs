using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{

    public int CurrentHealth;
    public int MaxHealth;
    public bool gunOnly;

    private bool hit;
    private SFXManager sfx;
    // Use this for initialization
    void Start()
    {
        sfx = FindObjectOfType<SFXManager>();
        CurrentHealth = MaxHealth;
    }


    void OnTriggerEnter2D(Collider2D col)
    {
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
        }

        //if was hit by the player's sword, extra damage and full knockback
        if (gunOnly == false)
        {
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
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth <= 0)
        {
            sfx.BrokenCrate.Play();
            FindObjectOfType<DestroyManager>().AddToList(gameObject.name);
            Destroy(gameObject);
        }
    }
}
