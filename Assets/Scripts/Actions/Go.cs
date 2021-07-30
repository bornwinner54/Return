using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (menuName = "Actions/Go")]
public class Go : Action
{
    public override void processInput(GameController controller, string noun)
    {
        if(controller.player.changeLoc(controller,noun))
        {
            controller.displayLoc();
        }
        else
        {
            controller.currText.text = "You can't go that way! ";
        }
    }
}
