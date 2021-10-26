using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnScript : TowerScript
{
    [SerializeField]private GameObject Barrel, barrel1;
    private Transform turn;
    private float turn1;
    private bool checkpoint0, checkpoint1;
    int arrayPos;
    float prior = 0;
    private GameObject target;
    GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        turn1 = Time.deltaTime * 100;
        if(Barrel.transform.rotation.y > gameObject.transform.rotation.y)
        {
            gameObject.transform.Rotate(0, turn1, 0);
            checkpoint0 = true;
            if(checkpoint1 == true)
            {
                enemyCheck();
                barrel1.transform.LookAt(target.transform.position);
            }
            checkpoint1 = false;
        }
        else
        {
            gameObject.transform.Rotate(0, -turn1, 0);
            checkpoint1 = true;
            if(checkpoint0 == true)
            {
                enemyCheck();
                barrel1.transform.LookAt(target.transform.position);
            }
            checkpoint0 = false;
        }
        
    }
}
