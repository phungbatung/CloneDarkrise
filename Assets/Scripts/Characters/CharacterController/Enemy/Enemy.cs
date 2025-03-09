using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public Player player { get; set; }

    [Header("PlayerCheckInfo")]
    public Transform playerCheck;
    public float playerCheckDistance;
    public LayerMask playerLayer;

    public float maxDistanceXToPlayer;
    public float maxDistanceYToPlayer;

    public Transform groundAheadCheck;

    #region State
    public CharacterState idleState { get; protected set; }
    public CharacterState chaseState { get; protected set; }
    public CharacterState jumpState { get; protected set; }
    public CharacterState attackState { get; protected set; }
    public CharacterState deathState { get; protected set; }
    #endregion
    protected override void Start()
    {
        base.Start();
        player = PlayerManager.Instance.player;
    }


    #region Player Interaction Methods
    public RaycastHit2D IsGroundedAhead()
    {
        return Physics2D.Raycast(groundAheadCheck.position, Vector2.down, groundCheckDistance, groundLayer);
    }

    public bool IsPlayerInChaseRange()
    {
        return HorizontalDistanceToPlayer() <= maxDistanceXToPlayer && VerticalDistanceToPlayer() <= maxDistanceXToPlayer;
    }

    public float RawHorizontalDistanceToPlayer()
    {
        return player.transform.position.x - transform.position.x;
    }

    public float HorizontalDistanceToPlayer()
    {
        return Mathf.Abs(RawHorizontalDistanceToPlayer());
    }

    public float RawVerticalDistanceToPlayer()
    {
        return player.transform.position.y - transform.position.y;
    }

    public float VerticalDistanceToPlayer()
    {
        return Mathf.Abs(RawVerticalDistanceToPlayer());
    }

    public float DistanceToPlayer()
    {
        return Vector2.Distance(transform.position, player.transform.position);
    }
    #endregion

    public virtual void Attack()
    {

    }    

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
        if(groundAheadCheck != null ) 
            Gizmos.DrawLine(groundAheadCheck.position, groundAheadCheck.position + new Vector3(0, -groundCheckDistance, 0));
        Gizmos.color = Color.yellow;
        if(playerCheck != null )
            Gizmos.DrawLine(playerCheck.position, playerCheck.position + new Vector3(facingDir * playerCheckDistance, 0, 0));
    }
}
