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
            BulletController newBullet = Instantiate(bullet, this.transform.position, this.transform.rotation) as BulletController;

            Vector3 temp = newBullet.transform.position;
            temp.z = 0;
            newBullet.transform.position = temp;
            //if player faces down, rotate bullet to shoot down
            if (playerFace.Equals(new Vector2(playerFace.x, -1)))
                {
                    Vector3 rotation = transform.rotation.eulerAngles;
                    temp.y = 0;
                    temp.z = -90;
                    newBullet.transform.rotation = Quaternion.Euler(rotation);
                }

            //if player faces up, rotate bullet to shoot up
            if (playerFace.Equals(new Vector2(playerFace.x, 1)))
            {
                Vector3 rotation = transform.rotation.eulerAngles;
                temp.y = 0;
                temp.z = 90;
                newBullet.transform.rotation = Quaternion.Euler(rotation);
            }
            print(newBullet.transform.position);
            firedOnce = true;
        }

	}
}
