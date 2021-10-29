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
}
