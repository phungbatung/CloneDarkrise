using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float moveSpeed;
    public float facingDir;
    public float jumpForce;

    public float dashSpeed;
    public float dashDuration;

    [Header("Ground check info")] 
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected LayerMask groundLayer;

    [Header("Attack info")]
    [SerializeField] public Transform attackPoint;
    [SerializeField] public float attackRadius;
    [SerializeField] public LayerMask targetLayer;

    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public CapsuleCollider2D cd { get; private set; }
    public CharacterStats stats { get; private set; }

    public StateMachine stateMachine { get; private set; }
    protected virtual void Awake()
    {
        facingDir = 1;

        stateMachine = new StateMachine();
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<CapsuleCollider2D>();
        stats = GetComponent<CharacterStats>();
    }
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    public virtual bool Grounded()
    {
        return Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);
    }

    public virtual void Flip()
    {
        transform.Rotate(0, 180, 0);
        facingDir *= -1;
    }

    public virtual void SetVelocity(float x, float y)
    {
        if ( x<0 && facingDir > 0 || x>0 && facingDir <0)
            Flip();
        rb.velocity = new Vector2(x, y);
    }
    public virtual void SetZeroVelocity()
    { 
        rb.velocity = Vector2.zero; 
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, groundCheck.position + new Vector3(0, -groundCheckDistance, 0));
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
