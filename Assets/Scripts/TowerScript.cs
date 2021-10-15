using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
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
        enemyCheck();

        if (target == null)
            return;

        transform.LookAt(target.transform);

        /*if (target.GetComponent<EnemyAI>().priority == 0)
        {
            enemyCheck();
        }
        else
        {
            transform.LookAt(target.transform);
        }*/
    }
    void enemyCheck()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        prior = 0;

        if (enemies.Length == 0)
            return;

        foreach (GameObject enemy in enemies)
        {
            if (prior < enemy.GetComponent<EnemyAI>().priority)
            {
                prior = enemy.GetComponent<EnemyAI>().priority;
                target = enemy;
                arrayPos++;
            }
        }
    }
}
