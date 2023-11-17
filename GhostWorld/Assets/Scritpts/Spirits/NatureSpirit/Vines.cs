using System.Collections;
using UnityEngine;

public class Vines : MonoBehaviour
{
    private GameObject enemy;
    private EnemyStatistic _enemyStatistic;

    private float recovery = 1f;
    private float timeBetweenTakeDamage;
    private float startTimeBetweenDamage = 1f;
    private float damage = 0.5f;
    private float livingTime = 2f;
    private float speedInVines = 0.5f;
    private float firstSpeed;


    private void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        _enemyStatistic = enemy.GetComponent<EnemyStatistic>();
        _enemyStatistic.playerRecovery = recovery;
        firstSpeed = _enemyStatistic.speed;
        StartCoroutine("Vine");
    }
    

    private void OnTriggerStay2D(Collider2D other)
    {
       
        if (other.CompareTag("Enemy") && timeBetweenTakeDamage <= 0)
        {
            _enemyStatistic.TakeDamage(damage);
            _enemyStatistic.speed = speedInVines;
            timeBetweenTakeDamage = startTimeBetweenDamage;
        }
        else
        {
            timeBetweenTakeDamage -= Time.deltaTime; 
        }
    }

    private IEnumerator Vine()
    {
        yield return new WaitForSeconds(livingTime);
        Destroy(gameObject);
        _enemyStatistic.speed = firstSpeed;
        
    }
}
