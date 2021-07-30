using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Actions/Give")]
public class Give : Action
{
    public override void processInput(GameController controller, string noun)
    {
        if (controller.player.hasItemByName(noun))
        {

            if (giveItem(controller, controller.player.currLocation.items, noun))
            {
                return;
            }
            controller.currText.text = "Nothing takes the " + noun;
            return;
        }

        controller.currText.text = "You don't have " + noun;
    }
    private bool giveItem(GameController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemEnable)
            {
                if (controller.player.canGiveItem(controller, item))
                {

                    if (item.interactWith("give", controller, noun))
                    {
                        return true;
                    }
                }
            }

        }
        return false;
    }
}
