using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wolf : Enemy
{
    public Player player;
    public float maxDistanceToPlayer;
    public LayerMask enemyLayer;
    private float lifeTime;
    public WolfIdleState idleState { get; private set; }
    public WolfMoveState moveState { get; private set; }
    public WolfJumpState jumpState { get; private set; }
    public WolfFallState fallState { get; private set; }
    public WolfBattleState battleState { get; private set; }
    public WolfAttackState attackState { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        idleState = new WolfIdleState(this, stateMachine, "idle");
        moveState = new WolfMoveState(this, stateMachine, "move");
        jumpState = new WolfJumpState(this, stateMachine, "jump");
        fallState = new WolfFallState(this, stateMachine, "fall");
        battleState = new WolfBattleState(this, stateMachine, "move");
        attackState = new WolfAttackState(this, stateMachine, "attack");
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.InitialState(jumpState);
    }
    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
    }

    public RaycastHit2D IsDetectEnenmy()
    {
        return  Physics2D.Linecast(transform.position - new Vector3(3, 0, 0), transform.position + new Vector3(3, 0, 0), enemyLayer);
    }

    public float HorizontalDistanceToPlayer()
    {
        return Mathf.Abs(transform.position.x - player.transform.position.x);
    }
    public bool IsEnemyInAttackRange()
    {
        return Physics2D.Raycast(wallCheck.position, facingDir * Vector3.right, attackPoint.position.x + facingDir * attackRadius - wallCheck.position.x, enemyLayer);
    }
    public void SetUpWolf(Player _player, Vector3 _position, float _lifeTime)
    {
        player = _player;
        transform.position = _position;
        lifeTime=_lifeTime;
        if (player.facingDir == -1)
            Flip();
        stats.moveSpeed.AddModifier(Random.Range(0, 3));
        Invoke("DestroyGO", lifeTime);
    }

    private void DestroyGO()
    {
        Destroy(gameObject);
    }
}
