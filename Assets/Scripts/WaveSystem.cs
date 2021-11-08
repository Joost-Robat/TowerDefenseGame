using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    private float timer, time, progress, spawningTimer, addingEnemies;
    private int amountNormal, amountFast, amountTank, normalSpawns, fastSpawns, tankSpawns;
    public int wave;
    [SerializeField]private GameObject enemy;
    [SerializeField]private GameObject enemyFast;
    [SerializeField] private GameObject enemyTank;
    [SerializeField] private GameObject boss;
    private bool fast, tank, normal, running;
    private GameObject currentEnemy, currentEnemy1;
    // Start is called before the first frame update
    void Start()
    {
        wave = 1;
        time = 5;
        normal = true;
        running = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(running == true)
        {
            timer += Time.deltaTime;
            if(timer >= time)
            {
                time = 10;
                wave++;
                if (normal == true)
                {
                    amountNormal += 2;
                    if(amountNormal >= 8)
                    {
                        fast = true;
                        normal = false;
                        amountFast = amountNormal;
                        amountNormal = 0;
                    }
                }
                if(fast == true)
                {
                   if(amountFast >= 12)
                    {
                        amountNormal = 0;
                        amountFast = 0;
                        tank = true;
                        amountTank = 5;
                        fast = false;
                        return;
                    }
                    else
                    {
                        amountFast += 2;
                    }
                }
                if(tank == true)
                {
                    if(amountTank == 7)
                    {
                        amountNormal = 6;
                        amountFast = 6;
                        amountTank = 4;
                    }
                    amountTank += 2;
                }
                if(wave >= 10)
                {
                    amountTank = 100;
                }


                updateAmounts();
                return;
            }
        }
        else
        {
            spawningTimer += Time.deltaTime;
            if(spawningTimer >= 0.6)
            {
                if(normalSpawns > 0)
                {
                    Instantiate(enemy, transform.position, Quaternion.identity);
                    spawningTimer = 0;
                    normalSpawns -= 1;
                    return;
                }
                if(fastSpawns > 0)
                {
                    Instantiate(enemyFast, transform.position, Quaternion.identity);
                    spawningTimer = 0;
                    fastSpawns -= 1;
                    return;
                }
                if(tankSpawns > 0)
                {
                    Instantiate(enemyTank, transform.position, Quaternion.identity);
                    spawningTimer = 0;
                    tankSpawns -= 1;
                    return;
                }
            }
            if(normalSpawns == 0 && fastSpawns == 0 && tankSpawns == 0)
            {
                running = true;
                return;
            }
        }
    }
    private void updateAmounts()
    {
        normalSpawns = amountNormal;
        fastSpawns = amountFast;
        tankSpawns = amountTank;
        timer = 0;
        running = false;
    }
}
