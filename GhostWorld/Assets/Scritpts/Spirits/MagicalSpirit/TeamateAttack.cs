using UnityEngine;

public class TeamateAttack : MonoBehaviour
{
 
    public Transform attackPosition;

    public LayerMask enemy;

    private float attackForce;
    private float startTimeBetweenAttack = 0.5f;
    private float timeBetweenAttack;
    public float attackRange;

    void Start()
    {
        attackForce = GetComponent<TeamateStatistic>().damage;
    }

   
    void Update()
    {
      
        if (timeBetweenAttack <= 0)
        {
            
            Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, enemy);

            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<EnemyStatistic>().TakeDamage(attackForce);
            }
            timeBetweenAttack = startTimeBetweenAttack;
        }
        else
        {
            timeBetweenAttack -= Time.deltaTime;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPosition.position, attackRange);
    }
}
