using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public class enemyNormal
    {
        public float health = 20f;
        public float damage;
        public float speed = 10;
        public bool endGoal;
        public void Damage()
        {
            if (endGoal == true)
            {
                damage = health;
            }
        }
    }


    // Update is called once per frame
}
