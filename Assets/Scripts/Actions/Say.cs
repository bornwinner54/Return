using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Say")]
public class Say : Action
{
    public override void processInput(GameController controller, string noun)
    {
        if (sayToItem(controller, controller.player.currLocation.items, noun))
        {
            return;
        }
        controller.currText.text = "Nothing responds!";
    }

    private bool sayToItem(GameController controller, List<Item> items, string noun)
    {
        foreach(Item item in items)
        {
            if (item.itemEnable)
            {
                if (controller.player.talkToItem(controller, item))
                {
                    
                    if(item.interactWith("say",controller,noun))
                    {
                        return true;
                    }
                }
            }
            
        }
        return false;
    }
}
