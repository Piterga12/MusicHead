using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/Carnation/Action/Idle")]

public class Phase1Action : FSM.Action
{
    // Start is called before the first frame update
    public override void Act(Controller controller)
    {
        controller.SetAnimation("Phase1", true);
        //controller.SetAnimation("attack", true);
        controller.SetAnimation("Phase2", false);
    }
}
