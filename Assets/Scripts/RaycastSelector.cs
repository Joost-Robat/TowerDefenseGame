using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastSelector : MonoBehaviour
{
    public Transform lastHit;
    public GameObject towerTransparent, tower, lastTower;
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
                Destroy(lastTower);
            }
        }
        if(toggle == true)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                lastHit = hit.transform;
                Destroy(lastTower);
                if (lastHit.GetComponent<Tile>().getIsBuildable() == true)
                {
                    lastTower = Instantiate(towerTransparent, lastHit.position, Quaternion.identity);
                }
                if (lastHit.GetComponent<Tile>().getIsBuildable() == true)
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
