﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    //initialize items
    public GameObject VampireBat, Easter, Exhilarant, Eye, HealthPlus, MilkNBread, Mushroom, SpeedBoost;
  
    //temp position used to make it appear in front of the shop object
    Vector3 temPos;

    //spawn prefabs once per 2 seconds
    public float spawnRate = 2f;

    //variable to set next spawn time
    float nextSpawn = 0f;

    //variable to contain random value
    int whatToSpawn;

    //item price
    public float price;
    public float DiscountRate;

    //other variable that is needed
    GameObject player;
    PlayerStats playerStats;
    DiscountDiamond diamond;
    DiscountTicket ticket;
    public bool arrived = false;
    bool wantbuy = false;
    void Start()
    {
        SetCollider();
        //adjust spawn position
        temPos = transform.position;
        temPos.z -= 3.5f;
        temPos.y -= 6f;
    }
    
    // Update is called once per frame
    void Update()
    {

       
        if (arrived)
        {
           
            whatToSpawn = Random.Range(1, 8);


            
            
            arrived = false;

            //NEED TO REVISE PRICE FOR EACH ITEM 


            switch (whatToSpawn)
            {
                case 1:
                    Instantiate(VampireBat, temPos, Quaternion.identity);
                    price = 1*DiscountRate;
                    Debug.Log(price);
                    return;
                case 2:
                    Instantiate(Easter, temPos, Quaternion.identity);
                    price = 1*DiscountRate;
                    Debug.Log(price);
                    return;
                case 3:
                    Instantiate(Exhilarant, temPos, Quaternion.identity);
                    price = 1*DiscountRate;
                    Debug.Log(price);
                    return;
                case 4:
                    Instantiate(Eye, temPos, Quaternion.identity);
                    price = 1*DiscountRate;
                    Debug.Log(price);
                    return;
                case 5:
                    Instantiate(HealthPlus, temPos, Quaternion.identity);
                    price = 1*DiscountRate;
                    Debug.Log(price);
                    return;
                case 6:
                    Instantiate(MilkNBread, temPos, Quaternion.identity);
                    price = 1*DiscountRate;
                    Debug.Log(price);
                    return;
                case 7:
                    Instantiate(Mushroom, temPos, Quaternion.identity);
                    price = 1*DiscountRate;
                    Debug.Log(price);
                    return;
                case 8:
                    Instantiate(SpeedBoost, temPos, Quaternion.identity);
                    price = 1*DiscountRate;
                    Debug.Log(price);
                    return;
                   
                //If there are more items, add them below and change the random number range.
            }
        }
    }

    //Interact with player if player arrives the shop
    
    void SetCollider()
    {

        this.gameObject.AddComponent<BoxCollider>();
        this.gameObject.GetComponent<BoxCollider>().size = new Vector3(1f, 1f, 1f);
        this.gameObject.GetComponent<BoxCollider>().isTrigger = true;

    }
    
   
    void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Player")
        {
          
            arrived = true;
            player = other.gameObject;
            Debug.Log("Welcome to the shop. Would you like to buy this item?");
            playerStats = player.GetComponent<PlayerStats>();
            
            //If player gives Yes response, reduce player's money.
            if (Input.GetKeyDown("space"))
            {
               
                playerStats.money -= price;
                if(ticket.collected){
                	ticket.collected = false;
                }
                if(diamond.collected){
                	diamond.collected = false;
                }
            }
            
        }


    }
}
