using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastSelector : MonoBehaviour
{
    public Transform lastHit;
    public GameObject towerTransparent, tower, lastTower, lastTower1;
    public bool toggle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (toggle != true)
            {
                toggle = true;
            }
            else
            {
                toggle = false;
                if(lastTower != null)
                {
                    Destroy(lastTower);
                }
                if(lastTower1 != null)
                {
                    Destroy(lastTower1);
                }
            }
        }
        if(toggle == true)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                lastHit = hit.transform;
                if (lastHit.GetComponent<Tile>() != null)
                {
                    if(lastHit.GetComponent<Tile>().getIsBuildable() == true)
                    {
                        if (lastTower == null)
                        {
                            lastTower = Instantiate(towerTransparent, lastHit.position, Quaternion.identity);
                            if (lastTower1 != null)
                            {
                                Destroy(lastTower1);
                            }
                        }
                        else if (lastTower1 == null)
                        {
                            lastTower1 = Instantiate(towerTransparent, lastHit.position, Quaternion.identity);
                            if (lastTower != null)
                            {
                                Destroy(lastTower);
                            }
                        }
                    }
                }
                if (lastHit.GetComponent<Tile>() != null)
                {
                    if(lastHit.GetComponent<Tile>().getIsBuildable() == true)
                    {
                        if (Input.GetKeyDown(KeyCode.Mouse0))
                        {
                            Instantiate(tower, lastHit.position, Quaternion.identity);
                        }
                    }
                }
            }
        }
    }
}
