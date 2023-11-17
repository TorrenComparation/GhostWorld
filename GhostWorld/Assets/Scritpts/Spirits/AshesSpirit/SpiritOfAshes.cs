using System.Collections;
using UnityEngine;

public class SpiritOfAshes : MonoBehaviour
{

    private PlayerStatistic _PlayerStatistic;
    

    private float deadGhosts;
    private float timeBetweenBoost;
    private float startTimeBetweenBoost = 5f;
    private float timeInBoost = 3f;
    private float ResetDeadGhosts = 0f;

    private float boostedDefense = 0.1f;
    private float boostedAttack = 20f;
    private float boostedSpeed = 7f;

    private float lastDefense;
    private float lastAttack;
    private float lastSpeed;   

    void Start()
    {
        lastAttack = GetComponent<PlayerStatistic>().attackDamage;
        lastDefense = GetComponent<PlayerStatistic>().shield;
        lastSpeed = GetComponent<PlayerStatistic>().speed;

         _PlayerStatistic = GetComponent<PlayerStatistic>();
    }

    void Update()
    {

        deadGhosts = GetComponent<PlayerStatistic>().deadGhosts;

        if(timeBetweenBoost <= 0 && Input.GetKey(KeyCode.R))
        {
          if(deadGhosts >= 1 && deadGhosts < 5)
            {
                _PlayerStatistic.speed = boostedSpeed;
            }
          else if(deadGhosts >= 5 && deadGhosts < 10)
            {
                _PlayerStatistic.speed = boostedSpeed;
                _PlayerStatistic.shield = boostedDefense;
            }
          else if(deadGhosts >= 10)
            {
                _PlayerStatistic.speed = boostedSpeed;
                _PlayerStatistic.shield = boostedDefense;
                _PlayerStatistic.attackDamage = boostedAttack;
            }

            StartCoroutine("Boost");
        }
        else
        {
            timeBetweenBoost -= Time.deltaTime;
        }
    }

    private IEnumerator Boost()
    {

        _PlayerStatistic.deadGhosts = ResetDeadGhosts;
        
        yield return new WaitForSeconds(timeInBoost);
        timeBetweenBoost = startTimeBetweenBoost;
        _PlayerStatistic.attackDamage = lastAttack;
        _PlayerStatistic.shield = lastDefense; 
        _PlayerStatistic.speed = lastSpeed;
    }

}
