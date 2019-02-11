using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCtrl : UIBase
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            GameObject tmep = GetUI("Image_UI");
            Debug.Log(tmep.name);
        }
    }
}
