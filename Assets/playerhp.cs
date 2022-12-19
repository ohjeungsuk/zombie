using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine .UI;

public class playerhp : MonoBehaviour
{
    public Image hp;
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie")) hp.fillAmount -= 1.0f / 5.0f;
    }
    void Update()
    {
        
    }
}
