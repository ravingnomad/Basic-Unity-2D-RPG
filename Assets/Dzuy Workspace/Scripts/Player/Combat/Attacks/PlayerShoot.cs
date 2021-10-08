using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    private Animator animator;
    private SpawnBullets bulletSpawner;
    private Rigidbody2D playerRigidBody;
    private Vector2 faceDirection;
    private GameObject player;
    private PlayerMove playerMovementScript;
    private SFXManager sfxManager;

    public float shootWaitTime;
    public float shootWaitTimeCountdown;
    public bool hasGun;

    
    void Start () {
        shootWaitTime = .15f;
        sfxManager = FindObjectOfType<SFXManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerRigidBody = player.GetComponent<Rigidbody2D>();
        animator = player.GetComponent<Animator>();
        bulletSpawner = player.GetComponentInChildren<SpawnBullets>();
        playerMovementScript = player.GetComponent<PlayerMove>();
        bulletSpawner.isFiring = false;
        hasGun = false;
    }
	

	void Update () {
        if (Input.GetKeyDown(KeyCode.Period) && hasGun == true)
        {
            faceDirection = playerMovementScript.GetLastMove();
            shootWaitTimeCountdown = shootWaitTime;
            animator.SetBool("Shooting", true);
            animator.SetFloat("Last Move X", faceDirection.x);
            animator.SetFloat("Last Move Y", faceDirection.y);
            sfxManager.playerGunAttack.Play();
            bulletSpawner.isFiring = true;
        }

        if (shootWaitTimeCountdown > 0)
        {
            shootWaitTimeCountdown -= Time.deltaTime;
            playerMovementScript.enabled = false;
            playerRigidBody.velocity = Vector2.zero;
        }

        if (shootWaitTimeCountdown <= 0)
        {
            animator.SetBool("Shooting", false);
            playerMovementScript.enabled = true;
            bulletSpawner.isFiring = false;
            bulletSpawner.firedOnce = false;
        }
    }
}
