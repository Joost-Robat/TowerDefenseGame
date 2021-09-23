using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class NormalEnemy : ScriptableObject
{
    public new string name;
    public int speed;
    public int health;
}
