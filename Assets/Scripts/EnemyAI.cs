using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public int row, rowPos;
    public float counter, counter1, movementTrue, speed, priority;
    public bool west, north, east, south, movement;
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
        row = 12;
        rowPos = 11;
        south = true;
        north = true;
        west = true;
        priority = 0.001f;
    }

    // Update is called once per frame
    void endPoint()
    {
        Debug.Log("Endpoint reached.");
        FindObjectOfType<PlayerHealthComponent>().TakeDamage(1);
        priority = 0;
        gameObject.SetActive(false);
        Destroy(gameObject);
        movement = false;
    }
    void Update()
    {
        if (movementTrue < 0.5)
        {
            movementTrue += Time.deltaTime;
        }
        else
        {
            movement = true;
        }
        if (movement == true)
        {
            priority += Time.deltaTime;
            // west
            if (west == true)
            {
                if (map[row, rowPos - 1] == 1 || map[row, rowPos - 1] == 2)
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
                        if (map[row, rowPos] == 2)
                        {
                            endPoint();
                        }
                    }

                }
            }
            // east
            if (east == true)
            {
                if (map[row, rowPos + 1] == 1 || map[row, rowPos + 1] == 2)
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
                        if (map[row, rowPos] == 2)
                        {
                            endPoint();
                        }
                    }
                }
            }
            // north
            if (north == true)
            {
                if (map[row + 1, rowPos] == 1 || map[row + 1, rowPos] == 2)
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
                        if (map[row, rowPos] == 2)
                        {
                            endPoint();
                        }
                    }
                }
            }
            if (south == true)
            {
                if (map[row - 1, rowPos] == 1 || map[row - 1, rowPos] == 2)
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
                        if (map[row, rowPos] == 2)
                        {
                            endPoint();
                        }
                    }
                }
            }
        }
    }
}
