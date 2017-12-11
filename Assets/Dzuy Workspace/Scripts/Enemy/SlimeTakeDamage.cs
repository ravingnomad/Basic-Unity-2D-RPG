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
    private EnemyHealth health;
    private EnemyAttack attack;
    private EnemyMovement moving;
    private GoblinChase chasing;
    private Rigidbody2D rigid;

<<<<<<< HEAD
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
        anim = GetComponent<Animator>();
        wasHit = false;
        rigid = GetComponent<Rigidbody2D>();
        moving = GetComponent<EnemyMovement>();
        attack = GetComponent<EnemyAttack>();
        chasing = GetComponent<GoblinChase>();
        health = GetComponent<EnemyHealth>();
    }

    //used for enemy to take damage
    void OnTriggerEnter2D(Collider2D col)
    {
        //if was hit by player's gun, damage and knockback are minimal
        if (col.gameObject.tag == "Player Bullet")
        {
<<<<<<< HEAD
            PlayerWeaponProperties weapon = col.gameObject.GetComponent<PlayerWeaponProperties>();

            health.HurtEnemy(weapon.damage / 2);
=======
            knockback = 1;
            PlayerWeaponProperties weapon = col.gameObject.GetComponent<PlayerWeaponProperties>();

            health.HurtEnemy(weapon.damage / weapon.damage);
>>>>>>> origin/master
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

<<<<<<< HEAD
            force = new Vector2(attackDirection.x * (knockback * 4f), attackDirection.y * (knockback * 4f));
            anim.SetBool("Moving", false);
            anim.SetBool("Attacking", false);
            anim.SetBool("Damaged", true);
            sfx.SlimeDamaged.Play();
=======
            force = new Vector2(attackDirection.x, attackDirection.y);
            anim.SetBool("Moving", false);
            anim.SetBool("Attacking", false);
            anim.SetBool("Damaged", true);
            //stun?
>>>>>>> origin/master
        }

        //if was hit by the player's sword, extra damage and full knockback
        if (col.gameObject.tag == "Player Weapon")
        {
<<<<<<< HEAD
            PlayerWeaponProperties weapon = col.gameObject.GetComponent<PlayerWeaponProperties>();

            health.HurtEnemy(weapon.damage * 3f);
=======
            knockback = 3;
            PlayerWeaponProperties weapon = col.gameObject.GetComponent<PlayerWeaponProperties>();

            health.HurtEnemy(weapon.damage * 1.5f);
>>>>>>> origin/master
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
<<<<<<< HEAD
            sfx.SlimeDamaged.Play();
=======
>>>>>>> origin/master
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
