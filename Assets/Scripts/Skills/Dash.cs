using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : Skill
{
    public override void Called()
    {
        base.Called();
        player.stateMachine.ChangeState(player.dashState);
    }
}
