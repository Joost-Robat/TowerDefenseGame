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
        south = true;
        west = true;
        row = 12;
        rowPos = 11;
        north0 = 1;
        east0 = 1;
        south0 = 1;
        west0 = 1;
        generating = true;

        //GenerateArray();
        GenerateWorld();
        
        
    }

    public void GenerateArray()
    {
        //for(int .Parse...)
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
        if(counter < 5)
        {
            counter += Time.deltaTime;
        }
        if (counter >= 5)
        {
            generating = false;
            north = false;
            south = false;
            east = false;
            west = false;
            buildingProgress = true;
            row = 0;
            rowPos = 0;
        }
        if (buildingProgress == true)
        {
            spawn.x = row;
            spawn.z = rowPos;
            if (randomMap[row, rowPos] == 1)
            {
                Debug.Log(spawn);
                Instantiate(pathTile, spawn, transform.rotation);
                rowPos += 1;
            }
            else if(randomMap[row, rowPos] == 0)
            {
                Debug.Log(spawn);
                rowPos += 1;
                Instantiate(buildTile, spawn, transform.rotation);
            }
            if(rowPos >= 13)
            {
                rowPos = 0;
                row += 1;
            }
            if(row >= 14)
            {
                buildingProgress = false;
            }
        }
        if (generating == true)
        {
            if (row >= randomMap.GetLength(0))
            {
                south = false;
            }
            if (row <= randomMap.GetLongLength(0))
            {
                north = false;
            }
            if (rowPos <= 1)
            {
                west = false;
            }
            if (rowPos >= 11)
            {
                east = false;
            }
            if (theCouncil == 1)
            {
                if (north == true)
                {
                    if (Random.Range(1, north0) == 1)
                    {
                        row -= 1;
                        randomMap[row, rowPos] = 1;
                        east = true;
                        west = true;
                        north = true;
                        south = false;
                        if (west0! <= 2)
                        {
                            west0 += 1;
                        }
                        if (east0! <= 2)
                        {
                            east0 += 1;
                        }
                    }
                }
            }
            if (theCouncil == 2)
            {
                if (east == true)
                {
                    if (Random.Range(1, east0) == 1)
                    {
                        rowPos += 1;
                        randomMap[row, rowPos] = 1;
                        east = true;
                        west = false;
                        north = true;
                        south = true;
                        if (north0! <= 2)
                        {
                            north0 += 1;
                        }
                        if (south0! <= 2)
                        {
                            south0 += 1;
                        }
                    }
                }
            }
            if (theCouncil == 3)
            {
                if (south == true)
                {
                    if (Random.Range(1, south0) == 1)
                    {
                        row += 1;
                        randomMap[row, rowPos] = 1;
                        east = true;
                        west = true;
                        north = false;
                        south = true;
                        if (west0! <= 2)
                        {
                            west0 += 1;
                        }
                        if (east0! <= 2)
                        {
                            east0 += 1;
                        }
                    }
                }
            }
            if (theCouncil == 4)
            {
                if (west == true)
                {
                    if (Random.Range(1, west0) == 1)
                    {
                        rowPos -= 1;
                        randomMap[row, rowPos] = 1;
                        east = false;
                        west = true;
                        north = true;
                        south = true;
                        if (north0! <= 2)
                        {
                            north0 += 1;
                        }
                        if (south0! <= 2)
                        {
                            south0 += 1;
                        }
                    }
                    if (row >= 12)
                    {
                        south = false;
                    }
                    if (row <= 1)
                    {
                        north = false;
                    }
                    if (rowPos <= 1)
                    {
                        west = false;
                    }
                    if (rowPos >= 11)
                    {
                        east = false;
                    }
                    if (theCouncil == 1)
                    {
                        if (north == true)
                        {
                            if (Random.Range(1, north0) == 1)
                            {
                                row -= 1;
                                randomMap[row, rowPos] = 1;
                                east = true;
                                west = true;
                                north = true;
                                south = false;
                                if (west0! <= 2)
                                {
                                    west0 += 1;
                                }
                                if (east0! <= 2)
                                {
                                    east0 += 1;
                                }
                            }
                        }
                    }
                    if (theCouncil == 2)
                    {
                        if (east == true)
                        {
                            if (Random.Range(1, east0) == 1)
                            {
                                rowPos += 1;
                                randomMap[row, rowPos] = 1;
                                east = true;
                                west = false;
                                north = true;
                                south = true;
                                if (north0! <= 2)
                                {
                                    north0 += 1;
                                }
                                if (south0! <= 2)
                                {
                                    south0 += 1;
                                }
                            }
                        }
                    }
                    if (theCouncil == 3)
                    {
                        if (south == true)
                        {
                            if (Random.Range(1, south0) == 1)
                            {
                                row += 1;
                                randomMap[row, rowPos] = 1;
                                east = true;
                                west = true;
                                north = false;
                                south = true;
                                if (west0! <= 2)
                                {
                                    west0 += 1;
                                }
                                if (east0! <= 2)
                                {
                                    east0 += 1;
                                }
                            }
                        }
                    }
                    if (theCouncil == 4)
                    {
                        if (west == true)
                        {
                            if (Random.Range(1, west0) == 1)
                            {
                                rowPos -= 1;
                                randomMap[row, rowPos] = 1;
                                east = false;
                                west = true;
                                north = true;
                                south = true;
                                if (north0! <= 2)
                                {
                                    north0 += 1;
                                }
                                if (south0! <= 2)
                                {
                                    south0 += 1;
                                }
                            }
                        }
                    }
                }
            }
        }
    }

}