using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMD : MonoBehaviour
{
    private Transform camT;
    public float yS = 3.0f;
    public float pS = 3.0f;
    
    void Start()
    {
        camT = GetComponent<Transform>();
    }

    
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftAlt))
        {
            Vector3 rot = camT.localEulerAngles + new Vector3(-Input.GetAxis("Mouse Y") * pS, Input.GetAxis("Mouse X") * yS, 0);
            camT.localRotation = Quaternion.Euler(rot);
        }
    }
}
