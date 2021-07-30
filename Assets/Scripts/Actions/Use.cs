using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Actions/Use")]
public class Use : Action
{
    public override void processInput(GameController controller, string noun)
    {
        if(noun.Length == 0)
        {
            controller.currText.text = "please enter item to use ";
            return;
        }
        //use item in location
        if(useItems(controller,controller.player.currLocation.items,noun))
        return ;
        //use item in inventory
        if(useItems(controller,controller.player.inventory,noun))
        return ;

        controller.currText.text = "There is no "+noun;
    }
    bool useItems(GameController controller,List<Item> items,string noun)
    {
        foreach(Item item in items)
        {
            if(item.itemName.ToLower() == noun.ToLower())
            {
               if(controller.player.canUseItem(controller,item)){
                if(item.interactWith("use",controller))
                
                    return true;
                }
                
                controller.currText.text = "The "+noun+" does nothing";    
                return true;
            }
        } 
        return false;
    }

    
}
