using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyHealth : MonoBehaviour {

    public float CurrentHealth;
    public float MaxHealth;

    private SpriteRenderer spriteRenderer;
    private Animator anim;
    public EnemyChasePlayer chasePlayerScript;
    private BoxCollider2D collider;
    private SFXManager sfx;


    void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        sfx = FindObjectOfType<SFXManager>();
        collider = GetComponent<BoxCollider2D>();
        CurrentHealth = MaxHealth;
        anim = GetComponent<Animator>();
        chasePlayerScript = GetComponent<EnemyChasePlayer>();
    }
	


    public void HurtEnemy(float damage)
    {
        CurrentHealth -= damage;
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
        disableEnemyScripts();
        freezeRigidbody();
        collider.enabled = false;
        spriteRenderer.sortingLayerName = "Ground";
        anim.Stop();
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
        EnemyAttack enemyAttackScript = GetComponent<EnemyAttack>();
        EnemyMovement enemyMovementScript = GetComponent<EnemyMovement>();
        enemyAttackScript.enabled = false;
        enemyMovementScript.enabled = false;
        chasePlayerScript.enabled = false;
    }

}
