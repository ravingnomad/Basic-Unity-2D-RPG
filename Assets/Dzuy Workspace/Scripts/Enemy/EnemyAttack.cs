using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public GameObject player;
    public float attackDistance;
    public Collider2D HitBox;

    private Rigidbody2D body;
    private GoblinChase chasing;
    private Animator anim;

    private SFXManager sfx;

	// Use this for initialization
	void Start () {
        sfx = FindObjectOfType<SFXManager>();
        player = GameObject.FindWithTag("Player");
        HitBox.enabled = false;
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        chasing = GetComponent<GoblinChase>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Vector3.Distance(player.transform.position, transform.position) <= attackDistance)
        {
            body.velocity = Vector2.zero;
            chasing.enabled = false;
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
            if (gameObject.tag == "Goblin")
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

            anim.SetBool("Moving", false);
            anim.SetBool("Attacking", true);
            HitBox.enabled = true;
            anim.SetFloat("Move X", normalized.x);
            anim.SetFloat("Move Y", normalized.y);   
        }

        else
        {
            chasing.enabled = true;
            anim.SetBool("Moving", true);
            HitBox.enabled = false;
            anim.SetBool("Attacking", false);
        }

    }
}
