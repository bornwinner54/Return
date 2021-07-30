using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Get")]
public class Get : Action
{
    public override void processInput(GameController controller, string noun)
    {
         foreach (Item item in controller.player.currLocation.items)
         {
             
            if(item.itemEnable && item.itemName.ToLower() == noun.ToLower())
            {
                //Debug.Log(item.itemName);
                if(item.playerCanTake)
                {
                    controller.player.inventory.Add(item);
                    controller.player.currLocation.items.Remove(item);
                    controller.currText.text = "You take the "+noun;
                    return;
                }
            }
         }
         controller.currText.text = "You can't get that";
    }
}
