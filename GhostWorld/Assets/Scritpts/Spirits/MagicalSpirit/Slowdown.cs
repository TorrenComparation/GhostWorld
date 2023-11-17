using UnityEngine;

public class Slowdown : MonoBehaviour
{

    private float slowingDown = 1f;
    private float lastSpeed;
    private GameObject enemy;
    private EnemyStatistic _enemyStatistic;

    private void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");

        if (enemy != null)
        {
            
            _enemyStatistic = enemy.GetComponent<EnemyStatistic>();
            lastSpeed = _enemyStatistic.speed;
        }

        
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (enemy != null)
        {
            if (other.CompareTag("Enemy"))
            {
                _enemyStatistic.speed = slowingDown;
            }

            else if (!other.CompareTag("Enemy"))
            {
                _enemyStatistic.speed = lastSpeed;
            }
        }




    }
}
