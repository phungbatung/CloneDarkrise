using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingDummy : MonoBehaviour, IDamageable
{
    [SerializeField] private bool isImmortal;
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    private Vector3 startPosition;

    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        startPosition = transform.position;
    }
    public void TakeDamage(int _damage = 0, int _critRate = 0, int _critDamage = 0, int _armorPenetration = 0)
    {
        anim.SetBool("hited", true);
        currentHealth -= 1;
        if (isImmortal)
            return;
        if (currentHealth < 0 )
        {
            Die();
        }
    }
    public void Idle()
    {
        anim.SetBool("hited", false);
    }
    public void Die()
    {
        transform.DOJump(transform.position + new Vector3(3, -6, 0), 7, 1, 1.5f);
        StartCoroutine("BackToStartPosition", 5);
        /*Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(transform.position + new Vector3(0,3,0), .5f));
        sequence.Append(transform.DOMove(transform.position + new Vector3(0,-6,0), 1.5f));*/
    }

    public IEnumerator BackToStartPosition(float _time)
    {
        yield return new WaitForSeconds(_time);
        currentHealth = maxHealth;
        gameObject.SetActive(true);
        transform.position = startPosition;
    }
}
