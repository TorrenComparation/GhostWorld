using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frezze : MonoBehaviour
{
    private float frezzedSpeed = 0;
    private float frezzedDamage = 0;
    private float activeTime = 3f;
    private EnemyStatistic enemyStatistic;

    private void Start()
    {
        enemyStatistic = gameObject.GetComponent<EnemyStatistic>();
        Debug.Log("Frezzed");
        StartCoroutine("FrezzeEnemy");
    }

    private IEnumerator FrezzeEnemy()
    {
        enemyStatistic.speed = frezzedSpeed;
        enemyStatistic.damage = frezzedDamage;
        yield return new WaitForSeconds(activeTime);
        enemyStatistic.damage = enemyStatistic.lastDamage;
        enemyStatistic.speed = enemyStatistic.lastSpeed;
        Destroy(gameObject.GetComponent<Frezze>());
    }
}
