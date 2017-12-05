using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamaged : MonoBehaviour {

    public float knockback;
    public float knockbackTime;
    public float knockbackCounter;
    public Vector2 force;
    public bool wasHit;

    private Animator anim;
    private PlayerAttack attack;
    private PlayerMove moving;
    private Rigidbody2D rigid;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        wasHit = false;
        rigid = GetComponent<Rigidbody2D>();
        moving = GetComponent<PlayerMove>();
        attack = GetComponent<PlayerAttack>();
        knockbackCounter = knockbackTime;
	}


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy Attack")
        {
            wasHit = true;
            anim.SetBool("Damaged", true);
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

            anim.SetFloat("Damaged X", attackDirection.x);
            anim.SetFloat("Damaged Y", attackDirection.y);
            force = new Vector2(attackDirection.x * knockback, attackDirection.y * knockback);
        }
    }

	// Update is called once per frame
	void Update () {

        if (wasHit == true)
        {
            moving.enabled = false;
            attack.weaponSprite.enabled = false;
            attack.attackTrigger.enabled = false;
            attack.enabled = false;

            knockbackCounter -= Time.deltaTime;
            if (knockbackCounter <= 0)
            {
                moving.enabled = true;
                attack.enabled = true;
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
