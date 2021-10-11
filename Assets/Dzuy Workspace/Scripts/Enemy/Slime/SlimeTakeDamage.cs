using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeTakeDamage : MonoBehaviour {


    public float knockback;
    public float knockbackTime;
    public float knockbackCounter;
    public Vector2 force;
    public bool wasHit;

    private Animator anim;
    private EnemyHealth enemyHealthScript;
    private EnemyAttack enemyAttackScript;
    private EnemyMovement enemyMovementScript;
    private EnemyChasePlayer chasePlayerScript;
    private Rigidbody2D rigid;
    private SFXManager sfx;


    void Start()
    {
        sfx = FindObjectOfType<SFXManager>();
        anim = GetComponent<Animator>();
        wasHit = false;
        rigid = GetComponent<Rigidbody2D>();
        enemyMovementScript = GetComponent<EnemyMovement>();
        enemyAttackScript = GetComponent<EnemyAttack>();
        chasePlayerScript = GetComponent<EnemyChasePlayer>();
        enemyHealthScript = GetComponent<EnemyHealth>();
    }

    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player Bullet")
        {
            chasePlayerScript.hitByPlayer = true;
            PlayerWeaponProperties weapon = col.gameObject.GetComponent<PlayerWeaponProperties>();
            enemyHealthScript.HurtEnemy(weapon.damage / 2);
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

            force = new Vector2(attackDirection.x * (knockback * 4f), attackDirection.y * (knockback * 4f));
            anim.SetBool("Moving", false);
            anim.SetBool("Attacking", false);
            anim.SetBool("Damaged", true);
            sfx.SlimeDamaged.Play();
        }


        if (col.gameObject.tag == "Player Weapon")
        {
            chasePlayerScript.hitByPlayer = true;
            PlayerWeaponProperties weapon = col.gameObject.GetComponent<PlayerWeaponProperties>();

            enemyHealthScript.HurtEnemy(weapon.damage * 3f);
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
            anim.SetFloat("Damaged X", attackDirection.x);
            anim.SetFloat("Damaged Y", attackDirection.y);
            sfx.SlimeDamaged.Play();
        }

        if (enemyHealthScript.isDead())
            anim.SetBool("Dead", true);
    }


    void Update()
    {
        if (wasHit == true)
        {
            enemyMovementScript.enabled = false;
            enemyAttackScript.enabled = false;
            chasePlayerScript.enabled = false;
            knockbackCounter -= Time.deltaTime;
            if (knockbackCounter <= 0)
            {
                enemyMovementScript.enabled = true;
                enemyAttackScript.enabled = true;
                chasePlayerScript.enabled = true;
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
