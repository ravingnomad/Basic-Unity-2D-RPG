using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public GameObject player;
    public float horizontalAttackDistance;
    public float verticalAttackDistance;
    public Collider2D attackHitBox;
    public Rigidbody2D enemyBody;
    public GoblinChase goblinChasing;
    public Animator animator;
    public SFXManager sfx;


	void Start () {
        sfx = FindObjectOfType<SFXManager>();
        player = GameObject.FindWithTag("Player");
        attackHitBox = transform.Find("Goblin Hit Box").GetComponent<Collider2D>();
        attackHitBox.enabled = false;
        animator = GetComponent<Animator>();
        enemyBody = GetComponent<Rigidbody2D>();
        goblinChasing = GetComponent<GoblinChase>();

	}
	

	void Update () {
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        Vector3 directionOfPlayer = (player.transform.position - transform.position).normalized;
        Debug.Log("Player direction: " + directionOfPlayer);
        if (canAttackHorizontal(distanceToPlayer, directionOfPlayer) || canAttackVertical(distanceToPlayer, directionOfPlayer))
        {
            attackPlayer();
        }

        else
        {
            if (this.tag == "Goblin")
            {
                goblinChasing.enabled = true;
            }   
            animator.SetBool("Moving", true);
            attackHitBox.enabled = false;
            animator.SetBool("Attacking", false);
        }
    }


    private bool canAttackVertical(float distanceToPlayer, Vector3 directionOfPlayer)
    {
        return distanceToPlayer <= verticalAttackDistance && (directionOfPlayer.y >= .6 || directionOfPlayer.y <= -.6);
    }


    private bool canAttackHorizontal(float distanceToPlayer, Vector3 directionOfPlayer)
    {
        return distanceToPlayer <= verticalAttackDistance && (directionOfPlayer.x >= .6 || directionOfPlayer.x <= -.6);
    }


    private void attackPlayer()
    {
        enemyBody.velocity = Vector2.zero;
        Vector3 direction = player.transform.position - transform.position;
        Vector3 normalized = direction.normalized;

        if (Mathf.Abs(normalized.x) <= .6)
        {
            normalized.x = 0;
        }

        if (Mathf.Abs(normalized.y) <= .6)
        {
            normalized.y = 0;                
        }

        if (this.tag == "Goblin")
        {
            goblinChasing.enabled = false;
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
        attackHitBox.enabled = true;
    }


}
