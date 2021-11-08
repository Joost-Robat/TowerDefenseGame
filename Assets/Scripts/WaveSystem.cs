using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    private float timer, time, progress, spawningTimer, addingEnemies;
    private int amountNormal, amountFast, amountTank, baseAmount0, baseAmount1;
    public int wave;
    [SerializeField]private GameObject enemy;
    [SerializeField]private GameObject enemyFast;
    [SerializeField] private GameObject enemyTank;
    private bool fast, tank, normal;
    // Start is called before the first frame update
    void Start()
    {
        wave = 1;
        amountNormal = 2;
        time = 5;
        normal = true;
    }
    private void spawn(int amount, GameObject enemyVariant)
    {
        for(int spawns = amount; spawns >= 1;)
        {
            spawningTimer += Time.deltaTime;
            if (spawningTimer >= 0.6)
            {
                Instantiate(enemy, transform.position, Quaternion.identity);
                spawningTimer = 0;
                spawns -= 1;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= time)
        {
            if (time == 5)
            {
                time = 10;
            }
            wave += 1;
            if(normal == true)
            {
                spawn(amountNormal, enemy);
            }
            if(fast == true)
            {
                spawn(amountFast, enemyFast);
                progress += 1;
            }
            if(tank == true)
            {
                spawn(amountTank, enemyTank);
            }
            if(tank == false && fast == false)
            {
                amountNormal += 2;
                if(amountNormal >= 10)
                {
                    fast = true;
                    spawn(amountNormal, enemyFast);
                    amountFast = amountNormal;
                    amountFast /= 2;
                    amountNormal = 4;
                }
            }
            if(progress >= 4)
            {
                time = 1;
                amountTank += 1;
                tank = true;
                spawn(amountNormal, enemyTank);
                if(progress >= 6)
                {
                    spawn(10, enemyTank);
                    progress = 0;
                }
            }
            timer = 0;
        }
    }
}
