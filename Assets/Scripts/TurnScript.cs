using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnScript : MonoBehaviour
{
    [SerializeField]private GameObject Barrel;
    private Transform turn;
    private float turn1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        turn1 = Time.deltaTime * 100;
        if(Barrel.transform.rotation.y > gameObject.transform.position.y)
        {
            gameObject.transform.Rotate(0, turn1, 0);
        }
        else if(Barrel.transform.rotation.y < gameObject.transform.position.y)
        {
            gameObject.transform.Rotate(0, -turn1, 0);
        }
    }
}
