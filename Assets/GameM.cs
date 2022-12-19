using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameM : MonoBehaviour
{

    public GameObject z;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateZombie", 1.0f, 2.0f);
    }


    void CreateZombie()
    {
        Vector3 positionValue = new Vector3
           (Random.Range(-8f, 8f), 0.5f, Random.Range(28.0f, 18.0f));
        GameObject temp = Instantiate(z, positionValue, transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
