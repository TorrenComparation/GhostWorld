using UnityEngine;

public class TeamateMoving : MonoBehaviour
{
    private float moveSpeed;
    private bool enemyIsAlive = false;
    public float rangeOfView;

    public LayerMask enemy;

    public Transform heroPosition;
    private Transform playerPosition;
    private GameObject _player;
    private Transform enemyPosition;

    private void Start()
    {
        moveSpeed = GetComponent<TeamateStatistic>().speed;
        _player = GameObject.FindGameObjectWithTag("Player");
        playerPosition = _player.transform;
    }
    void Update()
    {
        
            

        if(!enemyIsAlive)
        {
            if (_player != null)
            {
                Vector3 PlayerPosition = new Vector3 (playerPosition.position.x - 2, playerPosition.position.y, playerPosition.position.z);
                Vector3 directionToPlayer = PlayerPosition - transform.position;
                directionToPlayer.Normalize();

                Vector3 newPosition = transform.position + directionToPlayer * moveSpeed * Time.deltaTime;

                transform.position = newPosition;
            }
        }

        Collider2D[] enemies = Physics2D.OverlapCircleAll(heroPosition.position, rangeOfView, enemy);
        
        
            
        
        if (enemies.Length > 0)
        {
            enemyPosition = enemies[0].transform;
            enemyIsAlive = true;
            Vector3 directionToEnemy = enemyPosition.position - transform.position;
            directionToEnemy.Normalize();


            Vector3 newPosition = transform.position + directionToEnemy * moveSpeed * Time.deltaTime;


            transform.position = newPosition;
        }
        else if (enemies.Length == 0)
        {
            enemyIsAlive = false;  
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(heroPosition.position, rangeOfView);
    }
}
