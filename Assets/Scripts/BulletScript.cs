using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        bulletSpeed = 250;   
    }

    // Update is called once per frame
    void Update()
    { 
        gameObject.transform.position += new Vector3(0, bulletSpeed * Time.deltaTime, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, -Vector3.up, out hit);
        hit.transform.GetComponent<HealthComponent>();
    }
}
