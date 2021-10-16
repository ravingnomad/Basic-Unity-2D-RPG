using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour {

    public AudioSource playerHurtGrunt;
    public AudioSource playerHurtByGoblin;
    public AudioSource playerHurtBySlime;
    public AudioSource playerDeadMusic;
    public AudioSource playerDeadGrunt;
    public AudioSource playerSwordAttack;
    public AudioSource playerGunAttack;

    public AudioSource SlimeMove;
    public AudioSource SlimeDeath;
    public AudioSource SlimeDamaged;

    public AudioSource GoblinAttack_1;
    public AudioSource GoblinAttack_2;
    public AudioSource GoblinDamaged_1;
    public AudioSource GoblinDamaged_2;
    public AudioSource GoblinDeath;

    public AudioSource healing;

    public AudioSource SwordHitCrate;
    public AudioSource BrokenCrate;
    public AudioSource SwordHitMetal;

    public AudioSource GameOverDecision;

    public static bool Exists;



	void Start () {
        if (!Exists)
        {
            Exists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
