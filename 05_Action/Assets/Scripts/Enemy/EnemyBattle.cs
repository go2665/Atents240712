using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(EnemyHealth))]
public class EnemyBattle : MonoBehaviour, IBattle
{
    [SerializeField]
    float attackPower = 10.0f;

    [SerializeField]
    float defencePower = 3.0f;

    [SerializeField]
    float attackInterval = 1.0f;

    float attackCoolTime = 0.0f;

    EnemyHealth enemyHealth;
    Animator animator;

    readonly int Attack_Hash = Animator.StringToHash("Attack");
    readonly int Hit_Hash = Animator.StringToHash("Hit");

    public float AttackPower => attackPower;

    public float DefencePower => defencePower;

    /// <summary>
    /// 맞았음을 알리는 델리게이트(int: 실제로 입은 데미지에서 소수점을 제거한 값)
    /// </summary>
    public event Action<int> onHit;

    void Awake()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        animator = GetComponent<Animator>();
    }

    public void Attack(IBattle target)
    {
        animator.SetTrigger(Attack_Hash);
        target.Defence(AttackPower);
        attackCoolTime = attackInterval;
    }

    public void Defence(float damage)
    {
        if (enemyHealth.IsAlive)
        {
            animator.SetTrigger(Hit_Hash);

            float final = Mathf.Max(1, damage - defencePower);
            enemyHealth.GetDamage(final);
            onHit?.Invoke(Mathf.RoundToInt(final));
        }
    }
}
