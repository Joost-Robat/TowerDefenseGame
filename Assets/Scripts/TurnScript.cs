using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnScript : TowerScript
{
    public GameObject Barrel, barrel1, bullet, bulletSpawned;
    private Transform turn;
    private float turn1, timer;
    private bool checkpoint0, checkpoint1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < 1.5)
        {
            timer += Time.deltaTime;
        }
        if(target != null)
        {
            if (timer >= 1.5)
            {
                if (bulletSpawned != null)
                {
                    Destroy(bulletSpawned);
                }
                bulletSpawned = Instantiate(bullet, transform.position, transform.rotation);
                bulletSpawned.transform.forward = Barrel.transform.forward;
                timer = 0;
            }
        }
        enemyCheck();
        if(target != null)
        {
            turn1 = Time.deltaTime * 100;
            if (Barrel.transform.rotation.y > gameObject.transform.rotation.y)
            {
                gameObject.transform.Rotate(0, turn1, 0);
                checkpoint0 = true;
                if (checkpoint1 == true)
                {
                    barrel1.transform.LookAt(target.transform.position);
                }
                checkpoint1 = false;
            }
            else
            {
                gameObject.transform.Rotate(0, -turn1, 0);
                checkpoint1 = true;
                if (checkpoint0 == true)
                {
                    barrel1.transform.LookAt(target.transform.position);
                }
                checkpoint0 = false;
            }
        }
        
    }
}
