using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBetweenAttack;
    public float startTimeBetweenAttack;
    public float attackRange;
    private float damage;
    private PlayerStatistic playerStatistic;


    public Transform attackPos;
    public LayerMask enemy;

    private void Start()
    {
        playerStatistic = gameObject.GetComponent<PlayerStatistic>();
    }

    private void Update()
    {
        damage = playerStatistic.attackDamage;
        if (timeBetweenAttack <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                
                Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
                for (int i = 0; i < enemies.Length; i++)
                {
                    enemies[i].GetComponent<EnemyStatistic>().TakeDamage(damage);
                    
                }
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
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPos.position, attackRange);
        }
    }
