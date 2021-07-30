using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Actions/TalkTo")]
public class TalkTo : Action
{
    public override void processInput(GameController controller, string noun)
    {
        if(talkToItem(controller,controller.player.currLocation.items,noun))
        {
            return;
        }
        controller.currText.text = "There is no "+noun+ " here.";


    }
    private bool talkToItem(GameController controller,List<Item> items,string noun)
    {
        foreach (Item item in items)
        {
            //Debug.Log(item.itemName);
            if (item.itemName.ToLower() == noun.ToLower() && item.itemEnable)
            {
                if (controller.player.talkToItem(controller, item))
                {
                    if (item.interactWith("talkto", controller))

                        return true;
                }

                controller.currText.text = "The " + noun + " doesn't Respond";
                return true;
            }
        }
        return false;
    }
}
