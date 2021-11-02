using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthComponent : HealthComponent
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public override void Death()
    {
        base.Death();
        Destroy(gameObject);
    }
    public void bullet(int damage, Collision collision)
    {
        EnemyHealthComponent health = collision.transform.GetComponent<EnemyHealthComponent>();
        PlayerUI ui = GameObject.FindGameObjectWithTag("UI").GetComponent<PlayerUI>();
        ui.adjustScrap(damage);
        health.TakeDamage(damage);
        ui.UpdateUI();
    }
}
