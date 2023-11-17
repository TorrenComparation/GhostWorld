using System;
using UnityEngine;

public class EnemyStatistic : MonoBehaviour
{
    private GameObject player;
    private PlayerStatistic _playerStatistic;
    public GameObject enemy;

    private float hasDead = 1f;
    public float returnedDamage = 0f;
    public float playerRecovery = 0f;
    public float heath = 20f;
    public float damage = 1f;
    public float defense = 1f;
    public float speed = 3f;

    [NonSerialized] public float lastDamage;
    [NonSerialized] public float lastDefense;
    [NonSerialized] public float lastSpeed;
    
    

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _playerStatistic = player.GetComponent<PlayerStatistic>();

        lastDamage = damage;
        lastDefense = defense;
        lastSpeed = speed;
    }
    public void TakeDamage(float damage)
    {
        heath -= damage * defense;
    }

    private void Update()
    {
        if(heath <= 0)
        {
            Destroy(enemy);
            _playerStatistic.heath += playerRecovery;
            _playerStatistic.deadGhosts += hasDead;
        }
    }
}
