using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : TurnScript
{
    [SerializeField]private float bulletSpeed;
    [SerializeField]private float bulletDamage;
    // Start is called before the first frame update
    void Start()
    {
        
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
        EnemyHealthComponent health = collision.transform.GetComponent<EnemyHealthComponent>();
        health.TakeDamage(bulletDamage);
        Destroy(gameObject);
    }
}
