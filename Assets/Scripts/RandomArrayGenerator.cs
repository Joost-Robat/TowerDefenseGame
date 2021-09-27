using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomArrayGenerator : MonoBehaviour
{
    public int[,] randomMap =
    {
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
    };
    protected bool north, south, west, east;
    public int north0, south0, west0, east0, row, rowPos;
    protected int theCouncil;
    protected float counter;
    public bool buildingProgress;
    public bool generating;
    public GameObject pathTile;
    public GameObject buildTile;
    public Vector3 spawn;
    // Start is called before the first frame update
    void Start()
    {
        theCouncil = Random.Range(1, 4);
        north = true;
        west = true;
        row = 12;
        rowPos = 11;
        north0 = 4;
        east0 = 4;
        south0 = 4;
        west0 = 4;
        generating = true;

        GenerateArray();
        GenerateWorld();
        
        
    }
    public void GenerateArray()
    {
        east = false;
        south = false;
        for(int i = 0; i < randomMap.GetLength(0); i ++)
        {
            for(int j = 0; j < randomMap.GetLength(1); i ++)
            {
                if(north == true)
                {
                    theCouncil = Random.Range(1, north0);
                    if(theCouncil == 1)
                    {
                        row -= 1;
                        randomMap[row, rowPos] = 1;
                        if(north0 > 2)
                        {
                            north0 -= 1;
                            south = false;
                        }
                    }
                    else
                    {
                        north0 = 4;
                        south = true;
                    }
                }
                if(south == true)
                {
                    theCouncil = Random.Range(1, south0);
                    if (theCouncil == 1)
                    {
                        row += 1;
                        randomMap[row, rowPos] = 1;
                        if(south0 > 2)
                        {
                            south0 -= 1;
                            north = false;
                        }
                    }
                    else
                    {
                        north = true;
                        south0 = 4;
                    }
                }
                if(west == true)
                {
                    theCouncil = Random.Range(1, west0);
                    if(theCouncil == 1)
                    {
                        rowPos += 1;
                        randomMap[row, rowPos] = 1;
                        if(west0 > 2)
                        {
                            west0 -= 1;
                            east = false;
                        }
                    }
                    else
                    {
                        west0 = 4;
                        east = true;
                    }
                }
                if(east == true)
                {
                    theCouncil = Random.Range(1, east0);
                    if (theCouncil == 1)
                    {
                        rowPos += 1;
                        randomMap[row, rowPos] = 1;
                        if(east0 > 2)
                        {
                            east0 -= 1;
                            west = false;
                        }
                    }
                    else
                    {
                        east0 = 4;
                        east = true;
                    }
                }
            }
        }
    }
    public void GenerateWorld()
    {
        for (int i = 0; i < randomMap.GetLength(0); i++)
        {
            for (int j = 0; j < randomMap.GetLength(1); j++)
            {
                Vector3 spawnPosition = new Vector3(i * pathTile.GetComponent<Renderer>().bounds.size.x, 0, j * pathTile.GetComponent<Renderer>().bounds.size.z);
                switch (randomMap[i, j] = 1)
                {
                    case 0:
                        Instantiate(buildTile, spawnPosition, Quaternion.identity);
                        break;
                    case 1:
                        Instantiate(pathTile, spawnPosition, Quaternion.identity);
                        break;
                    default:
                        break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}