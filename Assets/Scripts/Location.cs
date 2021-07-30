using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{

    public string locName;
    [TextArea]
    public string Description;

    public Connections[] connections;
    public List<Item> items = new List<Item>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string getItemText()
    {
        if(items.Count == 0)
        return " ";
        string result = "You see ";
        bool first = true;
        foreach (Item item in items)
        {
            if(item.itemEnable){
            if(!first) result+=" and ";
            result+=item.itemDesc;
            first = false;
            }
        }
        result+= "\n";
        return result;
    }
   public string getConDesc()
   {
       string result = "";
       foreach(Connections conn in connections)
       {
           if(conn.conEnable)
           {
               result += conn.description+"\n";
           }
       }
       return result;
   }

    internal bool hasItem(Item itemToCheck)
    {
        foreach(Item item in items)
        {
            if(item == itemToCheck && item.itemEnable)
            {
                return true;
            }
        }
        return false;
    }

    public Connections GetConnections(string conNoun)
   {
       foreach (Connections connection in connections)
       {
           if(connection.conName.ToLower() == conNoun.ToLower())
           {
                return connection;
           }
       }
       return null;
   }
}
