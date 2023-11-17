using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private float change;
    private float damage;
    private float returnedDamage;
    private float timeBetweenAttack;
    private float startTimeBetweenAttack = 0.5f;
    [SerializeField] private float attackRange;

    [SerializeField] private LayerMask playerMask;
    private EnemyStatistic _enemyStatistic;
    [SerializeField] private Transform attackPosition;


    private void Start()
    {
        _enemyStatistic = GetComponent<EnemyStatistic>();
    }

    private void Update()
    {
        damage = _enemyStatistic.damage;
        returnedDamage = _enemyStatistic.returnedDamage;

        Collider2D player = Physics2D.OverlapCircle(attackPosition.position, attackRange, playerMask);
        if (player != null)
        {
            if (timeBetweenAttack <= 0)
            {
                player.GetComponent<PlayerStatistic>().TakeHit(damage);

                if (returnedDamage > 0)
                {
                    _enemyStatistic.heath -= (damage / returnedDamage);
                    change = Random.Range(1, 10);
                    if (change == 2 && gameObject.TryGetComponent<Ignition>(out Ignition enemy) == false)
                    {

                        gameObject.AddComponent<Ignition>();
                    }

                }
                timeBetweenAttack = startTimeBetweenAttack;
            }
            else
            {
                timeBetweenAttack -= Time.deltaTime;
            }
        }
    }


   
       

    

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(attackPosition.position, attackRange);
    }

}
