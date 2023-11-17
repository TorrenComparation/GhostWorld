using UnityEngine;

public class EmenyMoving : MonoBehaviour
{
    private EnemyStatistic _enemyStatistic;

    public LayerMask playerMask;

   
    private float moveSpeed;
    public float locatorRange;
    private bool isAlive = true;


    private void Start()
    {
        _enemyStatistic = gameObject.GetComponent<EnemyStatistic>();
    }
    private void Update()
    {
        Collider2D playerInRange = Physics2D.OverlapCircle(gameObject.transform.position, locatorRange, playerMask);
        moveSpeed = _enemyStatistic.speed;

        if (isAlive == true && playerInRange == true)
        {
          
            Vector3 directionToPlayer = playerInRange.transform.position - transform.position;
            directionToPlayer.Normalize();

            
            Vector3 newPosition = transform.position + directionToPlayer * moveSpeed * Time.deltaTime;

           
            transform.position = newPosition;
        }
        
    }

    public void Die()
    {
        isAlive = false;
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(gameObject.transform.position, locatorRange);
    }

}
