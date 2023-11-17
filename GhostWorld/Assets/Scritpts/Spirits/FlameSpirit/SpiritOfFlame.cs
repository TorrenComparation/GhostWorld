using System.Collections;
using UnityEngine;


public class SpiritOfFlame : MonoBehaviour
{
    public GameObject Attack;
    private GameObject enemy;
    private PlayerStatistic _playerStatistic;
    private EnemyStatistic _enemyStatistic;


    private float returnedDamage = 3f;
    private float lastReturnedDamage;
    private float livingTime = 2f;
    private float boostedSpeed = 4.5f;
    private float lastSpeed;
    private float timeBetweenIgnition;
    private float startTimeBetweenIgnition = 4f;
    private float timeIsFall = 0f;


    private void Start()
    {
       _playerStatistic = gameObject.GetComponent<PlayerStatistic>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        if(enemy != null)
        {
            _enemyStatistic = enemy.GetComponent<EnemyStatistic>();
            lastReturnedDamage = _enemyStatistic.returnedDamage;
        }
        
        lastSpeed = _playerStatistic.speed;
        
    }

    private void Update()
    {
        if(timeBetweenIgnition <= timeIsFall && Input.GetKey(KeyCode.R))
        {
            StartCoroutine(SplashAttack());
            _playerStatistic.speed = boostedSpeed;
            timeBetweenIgnition = startTimeBetweenIgnition;
        }
        else
        {
            timeBetweenIgnition -= Time.deltaTime;
        }
        if (enemy != null)
        {
            if (_playerStatistic.heath < 130 && _playerStatistic.heath > 0.001)
            {
                _enemyStatistic.returnedDamage = returnedDamage;
            }
            else
            {
                _enemyStatistic.returnedDamage = lastReturnedDamage;
            }
        }
        
    }

    private IEnumerator SplashAttack()
    {
        Instantiate(Attack, gameObject.transform);
        yield return new WaitForSeconds(livingTime);
        _playerStatistic.speed = lastSpeed;
    }

    
}
