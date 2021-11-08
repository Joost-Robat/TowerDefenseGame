using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthComponent : HealthComponent
{

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public override void TakeDamage(float damage)
    {

        base.TakeDamage(damage);
        FindObjectOfType<PlayerUI>().UpdateUI();
        Debug.Log("Speler krijgt 1 damage.");
    }
    public override void Death()
    {
        base.Death();
        SceneManager.LoadScene("TestScene");
        Debug.Log("Speler is dood.");
    }
}
