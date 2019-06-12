﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodFire : MonoBehaviour
{
    public int bloodamount;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            other.gameObject.GetComponent<PlayerStats>().currentHealth += bloodamount;
            Debug.Log("Collect Blood");
            Destroy(this.gameObject);
        }
    }

}
