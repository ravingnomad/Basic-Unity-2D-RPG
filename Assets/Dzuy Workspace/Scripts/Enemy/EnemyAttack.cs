using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    protected GameObject player;
    protected EnemyChasePlayer enemyChaseScript;
    protected Animator animator;

    public float horizontalAttackDistance;
    public float verticalAttackDistance;
    public Vector2 attackDirection;



    protected bool canAttackPlayer(float distanceToPlayer, Vector3 directionOfPlayer)
    {
        return canAttackHorizontal(distanceToPlayer, directionOfPlayer) || canAttackVertical(distanceToPlayer, directionOfPlayer);
    }


    private bool canAttackVertical(float distanceToPlayer, Vector3 directionOfPlayer)
    {
        return distanceToPlayer <= verticalAttackDistance && (directionOfPlayer.y >= .6 || directionOfPlayer.y <= -.6);
    }


    private bool canAttackHorizontal(float distanceToPlayer, Vector3 directionOfPlayer)
    {
        return distanceToPlayer <= horizontalAttackDistance && (directionOfPlayer.x >= .6 || directionOfPlayer.x <= -.6);
    }


    protected void attackPlayer()
    {
        enemyChaseScript.enabled = false;
        if (attackDirection == Vector2.zero)
        {
            attackDirection = player.transform.position - transform.position;
            Vector2 normalized = attackDirection.normalized;
            animator.SetBool("Moving", false);
            animator.SetBool("Attacking", true);
            animator.SetFloat("Move X", normalized.x);
            animator.SetFloat("Move Y", normalized.y);
            attackDirection = Vector2.zero;
        }
    }


}
