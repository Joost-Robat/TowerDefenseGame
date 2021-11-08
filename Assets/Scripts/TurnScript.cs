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
                barrel1.transform.LookAt(target.transform);
                bulletSpawned = Instantiate(bullet, transform.position, transform.rotation);
                bulletSpawned.transform.forward = Barrel.transform.forward;
                timer = 0;
            }
        }
        enemyCheck();
        if(target != null)
        {
            transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, Barrel.transform.rotation, 1);
        }
        
    }
}
