using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinTakeDamage : MonoBehaviour {

    public float knockbackForce;
    public float knockbackTime;

    private Animator anim;
    private EnemyHealth enemyHealthScript;
    private EnemyAttack enemyAttackScript;
    private EnemyMovement enemyMovementScript;
    private EnemyChasePlayer chasePlayerScript;
    private Rigidbody2D enemyRigidBody;
    private SFXManager sfx;


    void Start()
    {
        sfx = FindObjectOfType<SFXManager>();
        anim = GetComponent<Animator>();
        enemyRigidBody = GetComponent<Rigidbody2D>();
        enemyMovementScript = GetComponent<EnemyMovement>();
        enemyAttackScript = GetComponent<EnemyAttack>();
        chasePlayerScript = GetComponent<EnemyChasePlayer>();
        enemyHealthScript = GetComponent<EnemyHealth>();
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player Weapon" || col.gameObject.tag == "Player Bullet")
        {
            chasePlayerScript.hitByPlayer = true;
            PlayerWeaponProperties weapon = col.gameObject.GetComponent<PlayerWeaponProperties>();
            playGoblinDamageSound();
            enemyHealthScript.HurtEnemy(weapon.damage);
            Vector3 attackDirection = getDirectionWasAttacked(col);
            applyKnockbackForce(attackDirection);
            if (enemyHealthScript.isDead())
                anim.SetBool("Dead", true);
            else
            {
                playDamageAnimations();
                StartCoroutine(knockbackTimer());
            }


        }
    }


    private void playDamageAnimations()
    {
        anim.SetBool("Moving", false);
        anim.SetBool("Attacking", false);
        anim.SetBool("Damaged", true);
    }


    private Vector3 getDirectionWasAttacked(Collider2D playerAttack)
    {
        Vector3 attackDirection = playerAttack.transform.position - transform.position;
        attackDirection = attackDirection.normalized;
        return attackDirection;
    }


    private void playGoblinDamageSound()
    {
        int damageSound = Random.Range(1, 3);
        if (damageSound == 1)
        {
            sfx.GoblinDamaged_1.Play();
        }

        if (damageSound == 2)
        {
            sfx.GoblinDamaged_2.Play();
        }
    }


    private void applyKnockbackForce(Vector3 attackDirection)
    {
        Vector2 force = new Vector2(attackDirection.x * knockbackForce, attackDirection.y * knockbackForce);
        enemyRigidBody.velocity = Vector2.zero;
        enemyRigidBody.AddForce(-force, ForceMode2D.Impulse);
        enemyMovementScript.enabled = false;
        enemyAttackScript.enabled = false;
        chasePlayerScript.enabled = false;
    }


    IEnumerator knockbackTimer()
    {
        yield return new WaitForSeconds(knockbackTime);
        enemyMovementScript.enabled = true;
        enemyAttackScript.enabled = true;
        chasePlayerScript.enabled = true;
        anim.SetBool("Damaged", false);
    }
}
