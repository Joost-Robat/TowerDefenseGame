using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float speedWS;
    public float speedAD;
    public float speedY;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speedAD, speedY, speedWS);
        if (Input.GetKey(KeyCode.W))
        {
            timer = 0;
            speedWS += Time.deltaTime;
        }
        else if(speedWS > 0)
        {
            speedWS -= Time.deltaTime * 3;
        }
        //
        if (Input.GetKey(KeyCode.S))
        {
            timer = 0;
            speedWS -= Time.deltaTime;
        }
        else if(speedWS < 0)
        {
            speedWS += Time.deltaTime * 3;
        }
        //
        if (Input.GetKey(KeyCode.Space))
        {
            timer = 0;
            speedY += Time.deltaTime;
        }
        else if(speedY > 0)
        {
            speedY -= Time.deltaTime * 3;
        }
        //
        if (Input.GetKey(KeyCode.LeftControl))
        {
            timer = 0;
            speedY -= Time.deltaTime;
        }
        else if(speedY < 0)
        {
            speedY += Time.deltaTime * 3;
        }
        //
        if (Input.GetKey(KeyCode.A))
        {
            speedAD -= Time.deltaTime;
        }
        else if(speedAD > 0)
        {
            speedAD += Time.deltaTime * 3;
        }
        //
        if (Input.GetKey(KeyCode.D))
        {
            speedAD += Time.deltaTime;
        }
        else if(speedAD < 0)
        {
            speedAD -= Time.deltaTime * 3;
        }
        //
        if(speedWS != 0 || speedAD != 0 || speedY != 0)
        {
            timer += Time.deltaTime;
            if(timer >= 0.3)
            {
                speedY = 0;
                speedAD = 0;
                speedWS = 0;
                timer = 0;
            }
        }
    }
}
