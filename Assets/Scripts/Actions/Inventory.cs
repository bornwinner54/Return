using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Actions/Inventory")]

public class Inventory : Action
{
    public override void processInput(GameController controller, string noun)
    {
        if(controller.player.inventory.Count == 0)
        {
            controller.currText.text = "You have nothing";
            return;
        }

        string result = "You have ";
        bool first = true;
        foreach (Item item in controller.player.inventory)
        {
            if(first){ result+=" a "+item.itemName;
            first = false;
            }
            else
            result+=",a "+item.itemName;
        }
        controller.currText.text = result;
    }

    
}
