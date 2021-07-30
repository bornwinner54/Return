using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Read")]
public class Read : Action
{
    public override void processInput(GameController controller, string noun)
    {
       // Debug.Log(noun);
        if (noun.Length == 0)
        {
            controller.currText.text = "please enter item to read ";
            return;
        }
        //use item in location
        if (readItems(controller, controller.player.currLocation.items, noun))
            return;
        //use item in inventory
        if (readItems(controller, controller.player.inventory, noun))
            return;

        controller.currText.text = "There is no " + noun;
    }

    bool readItems(GameController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            //Debug.Log(noun);
            //Debug.Log(item.itemName);
            if (item.itemName.ToLower() == noun.ToLower())
            {
                if (controller.player.canReadItem(controller, item))
                {
                    if (item.interactWith("read", controller))

                        return true;
                }

                controller.currText.text = "There is nothing written on " + noun ;
                return true;
            }
        }
        return false;
    }
}
