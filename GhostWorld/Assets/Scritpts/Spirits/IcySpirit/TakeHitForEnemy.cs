using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TakeHitForEnemy : MonoBehaviour
{

    public LayerMask enemyMask;
    
    [SerializeField]private float range;
    [SerializeField] private Transform attackPosition;
    private float damage = 2f;
    private int randomedNumber;

    private void Start()
    {
        randomedNumber = Random.Range(1,4);
    }
    private void Update()
    {
        Collider2D enemy = Physics2D.OverlapCircle(attackPosition.position, range, enemyMask);
        
        if (enemy != null)
        {
            enemy.GetComponent<EnemyStatistic>().TakeDamage(damage);
            if (randomedNumber == 3)
            {
                enemy.AddComponent<Frezze>();
            }
            Destroy(gameObject);
        }
      
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPosition.position, range);
    }
}
