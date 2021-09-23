using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewEnemy : MonoBehaviour
{
    public NormalEnemy enemy;

    public Text nameText;
    public int speedValue;
    public int healthPoints;

    // Start is called before the first frame update
    void Start()
    {
        speedValue = enemy.speed;
        healthPoints = enemy.health;
        name = enemy.name;
    }
}
