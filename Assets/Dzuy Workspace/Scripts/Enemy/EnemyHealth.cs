using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyHealth : MonoBehaviour {

    public float CurrentHealth;
    public float MaxHealth;

    private Animator anim;
    private EnemyChasePlayer chasePlayerScript;
    private BoxCollider2D collider;
    private SFXManager sfx;


    void Start ()
    {
        sfx = FindObjectOfType<SFXManager>();
        collider = GetComponent<BoxCollider2D>();
        CurrentHealth = MaxHealth;
        anim = GetComponent<Animator>();
        chasePlayerScript = GetComponent<EnemyChasePlayer>();
    }
	

	void Update ()
    {
        if (CurrentHealth <= 0)
        {
            anim.SetBool("Dead", true);            
        }
    }


    public void HurtEnemy(float damage)
    {
        CurrentHealth -= damage;
        //chasePlayerScript.hitByPlayer = true;
    }


    public void SetMaxHealth()
    {
        CurrentHealth = MaxHealth;
    }


    public void Death()
    {
        if (gameObject.tag == "Goblin")
        {
            GetComponent<GoblinTakeDamage>().enabled = false;
            sfx.GoblinDeath.Play();
        }

        if (gameObject.tag == "Slime")
        {
            GetComponent<SlimeTakeDamage>().enabled = false;
            sfx.SlimeDeath.Play();
        }
        freezeRigidbody();
        anim.Stop();
        disableEnemyScripts();
        collider.enabled = false;
    }


    public bool isDead()
    {
        return CurrentHealth <= 0;
    }


    private void freezeRigidbody()
    {
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.zero;
        rigid.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }


    private void disableEnemyScripts()
    {
        chasePlayerScript.enabled = false;
        GetComponent<EnemyAttack>().enabled = false;
        GetComponent<EnemyMovement>().enabled = false;
        GetComponent<SlimeAttack>().enabled = false;
    }

}
