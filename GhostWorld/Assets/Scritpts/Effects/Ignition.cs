using System.Collections;
using UnityEngine;

public class Ignition : MonoBehaviour
{
    private EnemyStatistic _enemyStatistic;

    private float damagePerSecound = 0.5f;
    private float timeBetweenDamage;
    private float startTimeBetweenDamage = 1f;
    private float livingTime = 5f;
 

    private void Start()
    {
        StartCoroutine("StartIgnition");
        _enemyStatistic = GetComponent<EnemyStatistic>();
    }
    private void Update()
    {
        if(timeBetweenDamage <= 0)
        {
            _enemyStatistic.heath -= damagePerSecound;
       
            timeBetweenDamage = startTimeBetweenDamage;
        }
        else
        {
            timeBetweenDamage -= Time.deltaTime;
        }
       
    }
    private IEnumerator StartIgnition()
    {
        yield return new WaitForSeconds(livingTime);
        Destroy(GetComponent<Ignition>());
        yield return new WaitForSeconds(0.01f);
        Destroy(GetComponent<Ignition>());

    }
}
