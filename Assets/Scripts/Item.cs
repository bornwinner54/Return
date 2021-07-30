using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public string itemName;
    [TextArea]
    public string itemDesc;
    public bool playerCanTake;
    public bool itemEnable = true;
    public Interaction[] interactions;
    public Item targetItem = null;
    public bool playerCanTalkTo = false;
    public bool playerCanGiveTo = false;
    public bool playerCanRead = false;
    // Start is called before the first frame update use staff
    public bool interactWith(string actionKey,GameController controller,string noun = "")
    {
        
        foreach(Interaction interaction in interactions)
        {
            //Debug.Log("interactwith pass");
            if(interaction.action.keyword.ToLower() == actionKey.ToLower())
            {
                //Debug.Log(noun);
                //Debug.Log(interaction.textToMatch);
                if (noun != "" && noun.ToLower() != interaction.textToMatch.ToLower())
                    continue;
                
                foreach(Item disableItem in interaction.itemsToDisable)
                disableItem.itemEnable = false;

                foreach(Item enableItem in interaction.itemsToEnable)
                enableItem.itemEnable = true;

                foreach(Connections disableCon in interaction.conToDisable)
                disableCon.conEnable = false;

                foreach(Connections enableCon in interaction.conToEnable)
                enableCon.conEnable = true;
                if(interaction.teleportLocaiton != null)
                {
                    controller.player.teleport(controller, interaction.teleportLocaiton);
                }
                controller.currText.text = interaction.response;
                controller.displayLoc(true);
                return true;
            }
        }
        return false;
    }
}
