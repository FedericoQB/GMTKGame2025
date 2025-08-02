using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            GetComponent<CameraScript>().enabled = true;
        }
    }
}
