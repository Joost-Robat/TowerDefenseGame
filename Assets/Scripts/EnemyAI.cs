using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    public int row;
    public int rowPos;
    public float counter;
    public bool west;
    public bool north;
    public bool east;
    public bool south;
    public float movementTrue;
    public bool movement;
    private RandomArrayGenerator randomMap;
    public int[,] map =
    {
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
        {0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0 },
        {0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0 },
        {0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0 },
        {0, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 0 },
        {0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
        {0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
        {0, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 2, 0 },
        {0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
    };
    // Start is called before the first frame update
    void Start()
    {
        randomMap = FindObjectOfType<RandomArrayGenerator>();
        row = 12;
        rowPos = 11;
        south = true;
        north = true;
        west = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(movementTrue < 0.5)
        {
            movementTrue += Time.deltaTime;
            movement = false;
        }
        else if(movementTrue >= 0.5)
        {
            movement = true;
        }
        if(movement == true)
        {
            // west
            if (west == true)
            {
                if (randomMap.randomMap[row, rowPos - 1] == 1 || randomMap.randomMap[row, rowPos - 1] == 2)
                {
                    transform.position += new Vector3(0, 0, Time.deltaTime * speed);
                    counter += Time.deltaTime * speed;
                    if (counter >= 1)
                    {
                        rowPos -= 1;
                        east = false;
                        north = true;
                        south = true;
                        west = true;
                        counter = 0;
                        if(randomMap.randomMap[row, rowPos] == 2)
                        {
                            Debug.Log("Endgoal reached.");
                            FindObjectOfType<PlayerHealthComponent>().TakeDamage(1);
                            Destroy(gameObject);
                            movement = false;
                        }
                    }

                }
            }
            // east
            if (east == true)
            {
                if (randomMap.randomMap[row, rowPos + 1] == 1 || randomMap.randomMap[row, rowPos + 1] == 2)
                {
                    transform.position -= new Vector3(0, 0, Time.deltaTime * speed);
                    counter += Time.deltaTime * speed;
                    if (counter >= 1)
                    {
                        rowPos += 1;
                        west = false;
                        north = true;
                        south = true;
                        east = true;
                        counter = 0;
                        if (randomMap.randomMap[row, rowPos] == 2)
                        {
                            Debug.Log("Endgoal reached.");
                            FindObjectOfType<PlayerHealthComponent>().TakeDamage(1);
                            Destroy(gameObject);
                            movement = false;
                        }
                    }
                }
            }
            // north
            if (north == true)
            {
                if (randomMap.randomMap[row + 1, rowPos] == 1 || randomMap.randomMap[row + 1, rowPos] == 2)
                {
                    transform.position -= new Vector3(Time.deltaTime * speed, 0, 0);
                    counter += Time.deltaTime * speed;
                    if (counter >= 1)
                    {
                        row += 1;
                        south = false;
                        north = true;
                        west = true;
                        east = true;
                        counter = 0;
                        if (randomMap.randomMap[row, rowPos] == 2)
                        {
                            Debug.Log("Endgoal reached.");
                            FindObjectOfType<PlayerHealthComponent>().TakeDamage(1);
                            Destroy(gameObject);
                            movement = false;
                        }
                    }
                }
            }
            // south
            if (south == true)
            {
                if (randomMap.randomMap[row - 1, rowPos] == 1 || randomMap.randomMap[row - 1, rowPos] == 2)
                {
                    transform.position += new Vector3(Time.deltaTime * speed, 0, 0);
                    counter += Time.deltaTime * speed;
                    if (counter >= 1)
                    {
                        row -= 1;
                        north = false;
                        south = true;
                        east = true;
                        west = true;
                        counter = 0;
                        if (randomMap.randomMap[row, rowPos] == 2)
                        {
                            Debug.Log("Endgoal reached.");
                            FindObjectOfType<PlayerHealthComponent>().TakeDamage(1);
                            Destroy(gameObject);
                            movement = false;
                        }
                    }
                }
            }
        }
    }
}
