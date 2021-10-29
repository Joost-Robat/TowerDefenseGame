using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastSelector : MonoBehaviour
{
    public Transform lastHit;
    public GameObject towerTransparent, tower, lastTower, lastTower1;
    private bool toggle, placeable;
    [SerializeField]private GameObject buildingOff;
    [SerializeField]private GameObject buildingOn;

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
                buildingOff.SetActive(false);
                buildingOn.SetActive(true);
            }
            else
            {
                toggle = false;
                buildingOn.SetActive(false);
                buildingOff.SetActive(true);
                if (lastTower != null)
                {
                    Destroy(lastTower);
                }
                if(lastTower1 != null)
                {
                    Destroy(lastTower1);
                }
            }
        }
        if(placeable == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Mouse button pressed");
                Instantiate(tower, lastHit.position, Quaternion.identity);
                lastHit.GetComponent<Tile>().placedTower();
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
                        placeable = true;
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
            }
        }
    }
}
