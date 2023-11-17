using UnityEngine;


public class DamageZone : MonoBehaviour
{
    public LayerMask enemy;
    public Transform attackPosition;

    private float damage = 5f;
    private float positionX = 7f;
    private float positionY = 1f;
    private float angle = 0f;
    private float startTimeBetweenAttack = 1f;
    private float timeBetweenAttack = 0.1f;
   
    public float zoneRange;


 
    private void FixedUpdate()
    {
        if (timeBetweenAttack <= 0)
        {

            Collider2D[] enemies = Physics2D.OverlapBoxAll(attackPosition.position, new Vector2(positionX, positionY), angle, enemy);
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<EnemyStatistic>().TakeDamage(damage);
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
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(attackPosition.position, new Vector2(positionX, positionY));
    }
}
