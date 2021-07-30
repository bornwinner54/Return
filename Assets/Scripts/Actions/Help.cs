using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Actions/Help")]
public class Help : Action
{
    public override void processInput(GameController controller, string noun)
    {
        controller.currText.text = "Type a verb followed by noun(eg.\"Go North\")";
        controller.currText.text += "\n Allowed verbs : \nGo, examine, use,read, inventory,get,talkto,give, say, Help";
    }

    
}
