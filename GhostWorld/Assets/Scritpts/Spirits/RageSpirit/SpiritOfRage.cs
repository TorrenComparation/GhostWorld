using System.Collections;
using UnityEngine;

public class SpiritOfRage : MonoBehaviour
{
    private PlayerStatistic _playerStatistic;
    private EnemyStatistic _enemyStatistic;
    private GameObject player;
    private GameObject enemy;
    

    private float lastDefense;
    private float lastDamage;
    private float lastSpeed;


    private float defenseInRage = 1.3f;
    private float damageInRage = 15f;
    private float speedInRage = 5f;

    private float timeInRage = 3f;
    private float timeBetweenRage;
    private float startTimeBetweenRage = 5f;
    private float recoveryPoints = 1f;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");

        _playerStatistic = player.GetComponent<PlayerStatistic>();
        _enemyStatistic = enemy.GetComponent<EnemyStatistic>();

        lastDefense = _playerStatistic.shield;
        lastDamage = _playerStatistic.attackDamage;
        lastSpeed = _playerStatistic.speed;

        _enemyStatistic.playerRecovery = recoveryPoints;

    }

    private void Update()
    {
        if(timeBetweenRage <= 0 && Input.GetKey(KeyCode.R))
        {
            
                _playerStatistic.shield = defenseInRage;
                _playerStatistic.attackDamage = damageInRage;
                _playerStatistic.speed = speedInRage;
                StartCoroutine("Rage");
               
        }
        else
        {
            timeBetweenRage -= Time.deltaTime;
        }
    }

    private IEnumerator Rage()
    {  
        yield return new WaitForSeconds(timeInRage);

        _playerStatistic.shield = lastDefense;
        _playerStatistic.attackDamage = lastDamage;
        _playerStatistic.speed = lastSpeed;

        timeBetweenRage = startTimeBetweenRage;
    }
}
