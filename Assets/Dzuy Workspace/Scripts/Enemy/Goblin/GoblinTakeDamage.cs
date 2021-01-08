using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinTakeDamage : MonoBehaviour {

    public float knockback;
    public float knockbackTime;
    public float knockbackCounter;
    public Vector2 force;
    public bool wasHit;

    private BoxCollider2D collider;
    private Animator anim;
    private EnemyHealth health;
    private EnemyAttack attack;
    private EnemyMovement moving;
    private EnemyChasePlayer chasing;
    private Rigidbody2D rigid;

    private SFXManager sfx;

    // Use this for initialization
    void Start()
    {
        sfx = FindObjectOfType<SFXManager>();
        anim = GetComponent<Animator>();
        wasHit = false;
        rigid = GetComponent<Rigidbody2D>();
        moving = GetComponent<EnemyMovement>();
        attack = GetComponent<EnemyAttack>();
        chasing = GetComponent<EnemyChasePlayer>();
        health = GetComponent<EnemyHealth>();
        knockbackCounter = knockbackTime;
    }

    //used for enemy to take damage
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player Weapon" || col.gameObject.tag == "Player Bullet")
        {
            PlayerWeaponProperties weapon = col.gameObject.GetComponent<PlayerWeaponProperties>();

            int damageSound = Random.Range(1, 3);
            if (damageSound == 1)
            {
                sfx.GoblinDamaged_1.Play();
            }

            if (damageSound == 2)
            {
                sfx.GoblinDamaged_2.Play();
            }
            
            health.HurtEnemy(weapon.damage);
            
            wasHit = true;
            Vector3 attackDirection = col.transform.position - transform.position;
            attackDirection = attackDirection.normalized;

            if (Mathf.Abs(attackDirection.x) < .5)
            {
                attackDirection.x = 0;
                
            }

            if (Mathf.Abs(attackDirection.y) < .5)
            {
                attackDirection.y = 0;
            }

            force = new Vector2(attackDirection.x * knockback, attackDirection.y * knockback);
            anim.SetBool("Moving", false);
            anim.SetBool("Attacking", false);
            anim.SetBool("Damaged", true);
        }
    }

    // used for the knockback
    void Update()
    {
        if (wasHit == true)
        {
            moving.enabled = false;
            attack.enabled = false;
            chasing.enabled = false;
            knockbackCounter -= Time.deltaTime;
            if (knockbackCounter <= 0)
            {
                moving.enabled = true;
                attack.enabled = true;
                chasing.enabled = true;
                knockbackCounter = knockbackTime;
                wasHit = false;
                anim.SetBool("Damaged", false);
            }

            else
            {
                rigid.velocity = new Vector2(-force.x, -force.y);
            }
        }
    }
}
