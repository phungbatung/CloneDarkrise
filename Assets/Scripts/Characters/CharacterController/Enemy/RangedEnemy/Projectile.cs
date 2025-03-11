using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private Animator anim;
    private Rigidbody2D rb;

    private Vector2 rootPos;
    private Vector2 flyDir;
    private float maxDistance;
    private float flySpeed;

    private IAttacker attacker;
    private LayerMask targetLayer;

    private Action OnProjectileHit;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, rootPos)>= maxDistance)
        {
            DestroyThisProjectile();
        }    
    }

    public void SetupProjectile(IAttacker _attacker, LayerMask _targetLayer, Vector2 _rootPos, Vector2 _flyDir, float _maxDistance ,Action _onProjectileHit)
    {
        attacker = _attacker;
        targetLayer = _targetLayer;
        rootPos = _rootPos;
        transform.position= rootPos;
        flyDir = _flyDir;
        maxDistance = _maxDistance;
        OnProjectileHit = _onProjectileHit;
        flySpeed = 20;
        rb.velocity = flyDir.normalized * flySpeed;
        float angle = Mathf.Atan2(flyDir.y, flyDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(IsInLayerMask(collision.gameObject, targetLayer))
        {
            IDamageable target = collision.GetComponent<IDamageable>();
            if(target != null)
            {
                attacker.DoDamage(target);
            }
        }
        DestroyThisProjectile();
    }

    public void DestroyThisProjectile()
    {
        OnProjectileHit?.Invoke();
        //Debug.Log($"Projectile name \"{gameObject.name}\" was destroyed");
        Destroy(gameObject);
    }    

    bool IsInLayerMask(GameObject obj, LayerMask mask)
    {
        return ((mask.value & (1 << obj.layer)) > 0);
    }
}
