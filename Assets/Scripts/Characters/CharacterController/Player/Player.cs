using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public SkillTree skillTree;
    public Detector detector;
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerFallState fallState { get; private set; }
    public PlayerPrimaryAttack attackState { get; private set; }
    public PlayerDashState dashState { get; private set; }
    public PlayerSlashState slashState { get; private set; }
    public PlayerHealingState healState { get; private set; }
    public PlayerLightCutState lightCut { get; private set; }
    public PlayerWolfCallState wolfCall { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        detector = GetComponentInChildren<Detector>();

        idleState = new PlayerIdleState(this, stateMachine, "idle");
        moveState = new PlayerMoveState(this, stateMachine, "move");
        jumpState = new PlayerJumpState(this, stateMachine, "jump");
        fallState = new PlayerFallState(this, stateMachine, "jump");
        attackState = new PlayerPrimaryAttack(this, stateMachine, "attack");
        dashState = new PlayerDashState(this, stateMachine, "dash");
        slashState = new PlayerSlashState(this, stateMachine, "slash");
        healState = new PlayerHealingState(this, stateMachine, "healing");
        lightCut = new PlayerLightCutState(this, stateMachine, "lightCut");
        wolfCall = new PlayerWolfCallState(this, stateMachine, "wolfCall");
        stateMachine.InitialState(idleState);
    }

    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
    }
}
