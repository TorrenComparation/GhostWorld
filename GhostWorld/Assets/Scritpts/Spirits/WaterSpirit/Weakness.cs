using System.Collections;
using UnityEngine;

public class Weakness : MonoBehaviour
{
    private float livingTime = 3f;
    private EnemyStatistic enemyStatistic;
    private float procentOfWeaknessDamage = 0.7f;
    private float lastDamage;

    private void Start()
    {
        enemyStatistic = gameObject.GetComponent<EnemyStatistic>();
        lastDamage = enemyStatistic.damage;

        enemyStatistic.damage *= procentOfWeaknessDamage;
        StartCoroutine("RemoveEffect");
    }

    private IEnumerator RemoveEffect()
    {
        yield return new WaitForSeconds(livingTime);
        enemyStatistic.damage = lastDamage;
        Destroy(gameObject.GetComponent<Weakness>());
        yield return new WaitForSeconds(0.01f);
        Destroy(gameObject.GetComponent<Weakness>());
    }
}
