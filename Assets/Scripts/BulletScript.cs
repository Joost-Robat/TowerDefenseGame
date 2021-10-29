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
        PlayerUI ui = GameObject.FindGameObjectWithTag("UI").GetComponent<PlayerUI>();
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
        PlayerUI ui = GameObject.FindGameObjectWithTag("UI").GetComponent<PlayerUI>();
        ui.giveScrap(bulletDamage);
        health.TakeDamage(bulletDamage);
        ui.UpdateUI();
        Destroy(gameObject);
    }
}
