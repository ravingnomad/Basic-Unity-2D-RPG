using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyHealth : MonoBehaviour {

    public float CurrentHealth;
    public float MaxHealth;
    public bool dead;
    private Animator anim;
    private GoblinChase attack;
    private DestroyEnemies destroy;
    private BoxCollider2D collider;
   

    // Use this for initialization
    void Start () {
        collider = GetComponent<BoxCollider2D>();
        CurrentHealth = MaxHealth;
        anim = GetComponent<Animator>();
        attack = GetComponent<GoblinChase>();
	}
	
	// Update is called once per frame
	void Update () {

        if (CurrentHealth <= 0)
        {
            anim.SetBool("Dead", true);

        }
    }

    public void HurtEnemy(float damage)
    {
        CurrentHealth -= damage;
        attack.wasHit = true;
    }

    public void SetMaxHealth()
    {
        CurrentHealth = MaxHealth;
    }

    public void Death()
    {

        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.zero;
        rigid.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        anim.Stop();
        GetComponent<EnemyAttack>().enabled = false;
        GetComponent<EnemyMovement>().enabled = false;
        GetComponent<GoblinChase>().enabled = false;
        collider.enabled = false;
        if (gameObject.tag == "Goblin")
        {
            GetComponent<GoblinTakeDamage>().enabled = false;
        }

        if (gameObject.tag == "Slime")
        {
            GetComponent<SlimeTakeDamage>().enabled = false;
        }
    }

}
