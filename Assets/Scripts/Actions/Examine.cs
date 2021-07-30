using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Actions/Examine")]
public class Examine : Action
{
    public override void processInput(GameController controller, string noun)
    {
        //Debug.Log(noun.Length == 0);
        if(noun.Length == 0)
        {
            controller.currText.text = "please enter item to examine ";
            return;
        }
        //check item in location
        if(checkItems(controller,controller.player.currLocation.items,noun))
        return ;
        //check item in inventory
        if(checkItems(controller,controller.player.inventory,noun))
        return ;

        controller.currText.text = "You can't see a "+noun;
    }
    private bool checkItems(GameController controller,List<Item> items,string noun)
    {
        foreach(Item item in items)
        {
            if(item.itemName.ToLower() == noun.ToLower())
            {
                if(item.interactWith("examine",controller))
                    return true;
                else
                controller.currText.text = "You see "+item.itemDesc;    
                return true;
            }
        }
        return false;
    }
}
