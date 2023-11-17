using UnityEngine;

public class ApplyingEffect : MonoBehaviour
{

    public float enemySpeed = 1f;

    private GameObject enemy;
    private EnemyStatistic _enemySpeed;


    private void Start()
    {

        enemy = GameObject.FindGameObjectWithTag("Enemy");

        if (enemy != null)
        {
            _enemySpeed = enemy.GetComponent<EnemyStatistic>();
        }

        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
       if(collision.CompareTag("Enemy"))
        {
            _enemySpeed.speed = enemySpeed;
        }
    }
}
