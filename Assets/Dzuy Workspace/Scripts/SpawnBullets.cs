using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullets : MonoBehaviour {

    private PlayerMove player;
    public BulletController bullet;
    public bool isFiring;
    public bool firedOnce;

	// Use this for initialization
	void Start () {
        player = GetComponentInParent<PlayerMove>();
	}
	
	// Update is called once per frame
	void Update () {

        if (isFiring == true && firedOnce == false)
        {
            Vector2 playerFace = player.GetLastMove();
            

            Vector3 position = transform.position;
            position.z = 0;

            Vector3 rotation = transform.rotation.eulerAngles;
            
            //if player faces down, rotate bullet to shoot down
            if (playerFace.Equals(new Vector2(playerFace.x, -1)))
                {
                    
                    rotation.y = 0;
                    rotation.z = -90;
            }

            //if player faces up, rotate bullet to shoot up
            if (playerFace.Equals(new Vector2(playerFace.x, 1)))
            {
                rotation.y = 0;
                rotation.z = 90;
            }

            //if player faces left, rotate bullet to shoot up
            if (playerFace.Equals(new Vector2(-1, playerFace.y)))
            {
                rotation.y = 0;
                rotation.z = 180;
            }

            BulletController newBullet = Instantiate(bullet, position, Quaternion.Euler(rotation)) as BulletController;
            firedOnce = true;
        }

	}
}
