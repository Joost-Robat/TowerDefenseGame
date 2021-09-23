using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Main;
    public GameObject angle1;
    public GameObject angle2;
    public bool camera1;
    public bool camera2;
    public bool camera3;
    // Start is called before the first frame update
    void Start()
    {
        Main.gameObject.SetActive(false);
        angle2.gameObject.SetActive(false);
        camera1 = false;
        camera2 = true;
        camera3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (camera1 == false)
            {
                camera1 = true;
                camera2 = false;
                camera3 = false;
                Main.SetActive(true);
                angle1.SetActive(false);
                angle2.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (camera2 == false)
            {
                camera1 = false;
                camera2 = true;
                camera3 = false;
                Main.SetActive(false);
                angle1.SetActive(true);
                angle2.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if(camera3 == false)
            {
                camera1 = false;
                camera2 = false;
                camera3 = true;
                Main.SetActive(false);
                angle1.SetActive(false);
                angle2.SetActive(true);
            }
        }
    }
}
