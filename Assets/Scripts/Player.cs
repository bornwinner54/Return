using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Location currLocation;
    public List<Item> inventory = new List<Item>(); 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool changeLoc(GameController controller,string conNoun)
    {
        Connections connection = currLocation.GetConnections(conNoun);
        if(connection != null)
        {
            if(connection.conEnable)
            {
                currLocation = connection.location;
                return true;
            }
        }
        return false;
    }

    public void teleport(GameController controller,Location destination)
    {
        currLocation = destination;
    }

    internal bool canGiveItem(GameController controller, Item item)
    {
        return item.playerCanGiveTo; 
    }

    internal bool canReadItem(GameController controller, Item item)
    {
        return item.playerCanRead;
    }
    internal bool talkToItem(GameController controller, Item item)
    {
        return item.playerCanTalkTo;
    }

    internal bool canUseItem(GameController controller, Item item)
    {
        if(item.targetItem == null)
        {
            //Debug.Log("Target item null");
        return true;
        }
        
        if(hasItem(item.targetItem))
        {
            return true;
        }
        if(currLocation.hasItem(item.targetItem))
        return true;



        return false;
        
    }

    private bool hasItem(Item itemToCheck)
    {
        foreach(Item item in inventory)
        {
            if(item == itemToCheck && item.itemEnable)
            {
                return true;
            }
        }
        return false;
    }
    public bool hasItemByName(string noun)
    {
        foreach(Item item in inventory)
        {
            if (item.itemName.ToLower() == noun.ToLower())
                return true;
        }
        return false;
    }
}
