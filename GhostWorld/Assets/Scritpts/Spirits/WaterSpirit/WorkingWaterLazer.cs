using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class WorkingWaterLazer : MonoBehaviour
{
    public LayerMask enemyMask;

    private float livingTime = 2f;
    private float angle = 0f;
    private float damage = 1f;

    private float timeBetweenTakeDamage;
    private float startTimeBetweenTakeDamage = 1f;
    private Vector2 size;




    private void Start()
    {
        StartCoroutine("DestroyWaterLazer");

        size = new Vector2(gameObject.transform.position.x + 1.5f, gameObject.transform.position.y);
       
    }

    private void Update()
    {
      

        Collider2D[] enemies = Physics2D.OverlapBoxAll(gameObject.transform.position, size, angle, enemyMask);

        if (timeBetweenTakeDamage <= 0)
        {
            foreach (Collider2D enemy in enemies)
            {
                enemy.GetComponent<EnemyStatistic>().TakeDamage(damage);
                enemy.AddComponent<Weakness>();
            }

            timeBetweenTakeDamage = startTimeBetweenTakeDamage;
        }
        else
        {
            timeBetweenTakeDamage -= Time.deltaTime;
        }

    }
    private IEnumerator DestroyWaterLazer()
    {
        yield return new WaitForSeconds(livingTime);
        Destroy(gameObject);
    }

}
