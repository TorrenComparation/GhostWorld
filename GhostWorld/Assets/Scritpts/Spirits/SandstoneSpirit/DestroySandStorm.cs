using System.Collections;
using UnityEngine;

public class DestroySandStorm : MonoBehaviour
{
    private float lenghtOfTime = 3f;
    private float firstSpeed;
    private EnemyStatistic _enemyStatistic;
    private GameObject enemy;

    private void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (enemy != null )
        {
            _enemyStatistic = enemy.GetComponent<EnemyStatistic>();
            firstSpeed = _enemyStatistic.speed;
            StartCoroutine("DestroyStorm");
        }
        else if(enemy == null)
        {
            StartCoroutine("DestroyStorm");
        }
        
    }

    private IEnumerator DestroyStorm()
    {
        yield return new WaitForSeconds(lenghtOfTime);
       if(enemy != null)
        {
            _enemyStatistic.speed = firstSpeed;
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
