using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastSelector : MonoBehaviour
{
    public Transform lastHit, lastTile;
    public GameObject towerTransparent, tower, lastTower, lastTower1;
    private bool toggle, placeable;
    [SerializeField]private GameObject buildingOff;
    [SerializeField]private GameObject buildingOn;
    [SerializeField]private PlayerUI ui;
    // Start is called before the first frame update
    void Start()
    {
        ui = FindObjectOfType<PlayerUI>();
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
        if (toggle == true)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                lastHit = hit.transform;
                if (lastHit.GetComponent<Tile>() != null)
                {
                    lastTile = lastHit;
                }
                if (lastTile.GetComponent<Tile>().getIsBuildable() == true)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        if(ui.scrapAmount() >= 50)
                        {
                            ui.adjustScrap(-50);
                            ui.UpdateUI();
                            Instantiate(tower, lastTile.position, Quaternion.identity);
                            lastTile.GetComponent<Tile>().placedTower();
                            return;
                        }
                    }
                    if (lastTower == null)
                    {
                        lastTower = Instantiate(towerTransparent, lastTile.position, Quaternion.identity);
                        if (lastTower1 != null)
                        {
                            Destroy(lastTower1);
                        }
                    }
                    else if (lastTower1 == null)
                    {
                        lastTower1 = Instantiate(towerTransparent, lastTile.position, Quaternion.identity);
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
