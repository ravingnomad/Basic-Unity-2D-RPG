using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{

    public int CurrentHealth;
    public int MaxHealth;
    public bool damagedByGunOnly;

    private SFXManager sfxManager;
    private DestroyManager destroyManager;




    void Start()
    {
        destroyManager = FindObjectOfType<DestroyManager>();
        sfxManager = FindObjectOfType<SFXManager>();
        CurrentHealth = MaxHealth;
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player Bullet")
        {
            sfxManager.SwordHitCrate.Play();
            CurrentHealth -= 50;
        }
        if (col.gameObject.tag == "Player Weapon")
        {
            if (damagedByGunOnly == true)
            {
                sfxManager.SwordHitMetal.Play();
            }
            if (damagedByGunOnly == false)
            {
                sfxManager.SwordHitCrate.Play();
                CurrentHealth -= 20;
            }
        }
        if (CurrentHealth <= 0)
        {
            sfxManager.BrokenCrate.Play();
            destroyManager.AddToList(gameObject.name);
            Destroy(gameObject);
        }
    }
}
