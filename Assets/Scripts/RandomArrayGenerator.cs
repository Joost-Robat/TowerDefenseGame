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
    protected int diceRoll;
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
        /*
        east = false;
        south = false;
        for (int rowI = 12; rowI++ < randomMap.GetLength(0) - 1; rowI -= 1)
        {
            if(rowI - 1> 0)
            {
                for (int rowPosI = 11; rowPosI + 1 < randomMap.GetLength(1) - 1;)
                {
                    if(rowPosI - 1 > 0)
                    {
                        theCouncil = Random.Range(1, 4);
                        switch (theCouncil)
                        {
                            case 1:
                                diceRoll = Random.Range(1, north0);
                                if (north == true && diceRoll == 1)
                                {
                                    row -= 1;
                                    rowI -= 1;
                                    randomMap[row, rowPos] = 1;
                                    if (north0 > 2)
                                    {
                                        north0 -= 1;
                                        south = false;
                                    }
                                }
                                else
                                {
                                    north0 = 4;
                                    west = true;
                                    east = true;
                                }
                                break;
                            case 2:
                                diceRoll = Random.Range(1, south0);
                                if (south == true && diceRoll == 1)
                                {
                                    row += 1;
                                    rowI += 1;
                                    randomMap[row, rowPos] = 1;
                                    if (south0 > 2)
                                    {
                                        south0 -= 1;
                                        north = false;
                                    }
                                }
                                else
                                {
                                    south0 = 4;
                                    west = true;
                                    east = true;
                                }
                                break;
                            case 3:
                                diceRoll = Random.Range(1, west0);
                                if (west == true && diceRoll == 1)
                                {
                                    rowPos -= 1;
                                    rowPosI -= 1;
                                    randomMap[row, rowPos] = 1;
                                    if (west0 > 2)
                                    {
                                        west0 -= 1;
                                        east = false;
                                    }
                                }
                                else
                                {
                                    west0 = 4;
                                    north = true;
                                    south = true;
                                }
                                break;
                            case 4:
                                diceRoll = Random.Range(1, east0);
                                if (east == true && diceRoll == 1)
                                {
                                    rowPos += 1;
                                    rowPosI += 1;
                                    randomMap[row, rowPos] = 1;
                                    if (east0 > 2)
                                    {
                                        east0 -= 1;
                                        west = false;
                                    }
                                }
                                else
                                {
                                    east0 = 4;
                                    north = true;
                                    south = true;
                                }
                                break;
                        }
                    }
                }
            }
        }
        */
        east = false;
        south = false;
        for (int rowI = 12; rowI < randomMap.GetLength(0);)
        {
            for(int rowPosI = 11; rowPosI < randomMap.GetLength(1);)
            {
                if (randomMap[1, 1] == 1 || randomMap[1, 11] == 1 || randomMap[12, 1] == 1)
                {
                    rowI = 20;
                }
                if (rowI++ >= randomMap.GetLength(1))
                {
                    south = false;
                    rowI--;
                    break;
                }
                if (rowI-- <= 0)
                {
                    north = false;
                    rowI++;
                    break;
                }
                if(rowPosI-- <= 0)
                {
                    west = false;
                    rowPosI--;
                    break;
                }
                if(rowPosI++ >= randomMap.GetLength(0))
                {
                    east = false;
                    rowPosI--;
                    break;
                }
                theCouncil = Random.Range(1, 4);
                switch (theCouncil)
                {
                    case 1:
                        diceRoll = Random.Range(1, north0);
                        if (north == true && diceRoll == 1)
                        {
                            rowI -= 1;
                            randomMap[rowI, rowPosI] = 1;
                            if (north0 > 2)
                            {
                                north0 -= 1;
                                south = false;
                            }
                        }
                        else
                        {
                            north0 = 4;
                            west = true;
                            east = true;
                        }
                        break;
                    case 2:
                        diceRoll = Random.Range(1, south0);
                        if (south == true && diceRoll == 1)
                        {
                            rowI += 1;
                            randomMap[rowI, rowPosI] = 1;
                            if (south0 > 2)
                            {
                                south0 -= 1;
                                north = false;
                            }
                        }
                        else
                        {
                            south0 = 4;
                            west = true;
                            east = true;
                        }
                        break;
                    case 3:
                        diceRoll = Random.Range(1, west0);
                        if (west == true && diceRoll == 1)
                        {
                            rowPosI -= 1;
                            randomMap[rowI, rowPosI] = 1;
                            if (west0 > 2)
                            {
                                west0 -= 1;
                                east = false;
                            }
                        }
                        else
                        {
                            west0 = 4;
                            north = true;
                            south = true;
                        }
                        break;
                    case 4:
                        diceRoll = Random.Range(1, east0);
                        if (east == true && diceRoll == 1)
                        {
                            rowPosI += 1;
                            randomMap[rowI, rowPosI] = 1;
                            if (east0 > 2)
                            {
                                east0 -= 1;
                                west = false;
                            }
                        }
                        else
                        {
                            east0 = 4;
                            north = true;
                            south = true;
                        }
                        break;
                    
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
                switch (randomMap[i, j])
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