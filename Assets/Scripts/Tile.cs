using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField]private bool isBuildable;

    public bool getIsBuildable()
    {
        return isBuildable;
    }
    public void placedTower()
    {
        isBuildable = false;
    }
}
