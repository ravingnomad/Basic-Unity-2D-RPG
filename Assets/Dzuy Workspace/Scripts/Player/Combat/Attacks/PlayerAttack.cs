using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private bool playerAttacking;
    private GameObject player;
    private Animator animator;
    private Rigidbody2D playerRigidbody;
    private SFXManager sfxManager;
    private PlayerMove playerMovementScript;

    public bool hasSword;
    public float attackTime;
    public float attackTimeCountdown;
    public Collider2D attackTrigger;
    public SpriteRenderer weaponSprite;


	void Start () {
        sfxManager = FindObjectOfType<SFXManager>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerRigidbody = player.GetComponent<Rigidbody2D>();
        playerMovementScript = player.GetComponent<PlayerMove>();
        attackTrigger.enabled = false;
        weaponSprite.enabled = false;
        hasSword = false;
	}


	void Update () {
        if (hasSword == true && Input.GetKeyDown(KeyCode.Comma))
        {
            Vector2 faceDirection = player.GetComponent<PlayerMove>().GetLastMove();
            if (faceDirection == Vector2.zero)
            {
                faceDirection = new Vector2(0, -1);
            }
            attackTimeCountdown = attackTime;
            playerAttacking = true;
            attackTrigger.enabled = true;
            weaponSprite.enabled = true;
            animator.SetBool("Attacking", true);
            animator.SetFloat("Last Move X", faceDirection.x);
            animator.SetFloat("Last Move Y", faceDirection.y);
            sfxManager.playerSwordAttack.Play();
        }

        if (attackTimeCountdown > 0)
        {
            attackTimeCountdown -= Time.deltaTime;
            playerMovementScript.enabled = false;
            playerRigidbody.velocity = Vector2.zero;
        }

        if (attackTimeCountdown <= 0)
        {
            weaponSprite.enabled = false;
            attackTrigger.enabled = false;
            playerAttacking = false;
            animator.SetBool("Attacking", false);
            playerMovementScript.enabled = true;
        }
	}

    public bool isAttacking()
    {
        return playerAttacking;
    }
}
