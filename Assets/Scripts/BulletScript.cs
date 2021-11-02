using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : TowerScript
{
    [SerializeField]private float bulletSpeed;
    [SerializeField]private int bulletDamage;
    // Start is called before the first frame update
    void Start()
    {
        EnemyHealthComponent enemyHealth = FindObjectOfType<EnemyHealthComponent>();
    }
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += gameObject.transform.forward * bulletSpeed * Time.deltaTime;
        enemyCheck();
        if (target == null) return;
        
        gameObject.transform.LookAt(target.transform);
    }
    private void OnCollisionEnter(Collision collision)
    {
        EnemyHealthComponent enemyHealth = FindObjectOfType<EnemyHealthComponent>();
        enemyHealth.bullet(bulletDamage, collision);
        Destroy(gameObject);
    }
}
