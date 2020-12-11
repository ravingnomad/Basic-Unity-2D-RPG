﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public GameObject player;
    public float horizontalAttackDistance;
    public float verticalAttackDistance;
    public Collider2D attackHitBox;
    public Rigidbody2D enemyBody;
    public GoblinChase goblinChasing;
    public EnemyMovement movement;
    public Animator animator;
    public SFXManager sfx;
    public bool canAttack;
    public Vector2 attackDirection;


	void Start () {
        canAttack = true;
        sfx = FindObjectOfType<SFXManager>();
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        enemyBody = GetComponent<Rigidbody2D>();
        goblinChasing = GetComponent<GoblinChase>();
        movement = GetComponent<EnemyMovement>();
   
	}
	

	void Update () {
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        Vector3 directionOfPlayer = (player.transform.position - transform.position).normalized;
        if (canAttack && (canAttackHorizontal(distanceToPlayer, directionOfPlayer) || canAttackVertical(distanceToPlayer, directionOfPlayer)))
        {
            canAttack = false;
            attackPlayer();
            StartCoroutine(pauseAttack());
        }

        else
        {
            animator.SetBool("Moving", true);
            animator.SetBool("Attacking", false);
        }
    }


    IEnumerator pauseAttack()
    {
        yield return new WaitForSeconds(3);
        canAttack = true;
        attackDirection = Vector2.zero;
        enemyBody.constraints &= ~RigidbodyConstraints2D.FreezePosition;
        goblinChasing.enabled = true;
        movement.enabled = true;
    }


    private bool canAttackVertical(float distanceToPlayer, Vector3 directionOfPlayer)
    {
        return distanceToPlayer <= verticalAttackDistance && (directionOfPlayer.y >= .6 || directionOfPlayer.y <= -.6);
    }


    private bool canAttackHorizontal(float distanceToPlayer, Vector3 directionOfPlayer)
    {
        return distanceToPlayer <= horizontalAttackDistance && (directionOfPlayer.x >= .6 || directionOfPlayer.x <= -.6);
    }


    private void attackPlayer()
    {
        goblinChasing.enabled = false;
        movement.enabled = false;
        enemyBody.constraints = RigidbodyConstraints2D.FreezePosition;
        if (attackDirection == Vector2.zero)
        {
            attackDirection = player.transform.position - transform.position;
            Vector2 normalized = attackDirection.normalized;

            /*if (Mathf.Abs(normalized.x) <= .6)
            {
                normalized.x = 0;
            }

            if (Mathf.Abs(normalized.y) <= .6)
            {
                normalized.y = 0;                
            }*/

            if (this.tag == "Goblin")
            {
                int attackSound = Random.Range(1, 3);
                if (attackSound == 1)
                {
                    sfx.GoblinAttack_1.Play();
                }

                if (attackSound == 2)
                {
                    sfx.GoblinAttack_2.Play();
                }
            }
            
            animator.SetBool("Moving", false);
            animator.SetBool("Attacking", true);
            animator.SetFloat("Move X", normalized.x);
            animator.SetFloat("Move Y", normalized.y);
        }
    }


}
