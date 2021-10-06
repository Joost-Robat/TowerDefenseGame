using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthComponent : HealthComponent
{

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        FindObjectOfType<PlayerHealthUI>().UpdateUI();
        Debug.Log("Speler krijgt 1 damage.");
    }
    protected override void Death()
    {
        base.Death();
        Debug.Log("Speler is dood.");
    }
}
