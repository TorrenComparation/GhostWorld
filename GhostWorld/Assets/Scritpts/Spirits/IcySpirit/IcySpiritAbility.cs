using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcySpiritAbility : MonoBehaviour
{
    [SerializeField]private GameObject spike;
    private PlayerStatistic playerStatistic;
    private float startTimeBetweenLaunch = 2f;
    private float activeTime = 5f;
    private float timeBetweenLaunch;
    private float timeBetweenSpawnSpike = 0.5f;
    private int maxCountCreatedSpikes = 3;
    private float lastShild;
    private float icyShild = 0.8f;

    private void Start()
    {
        playerStatistic = gameObject.GetComponent<PlayerStatistic>();
    }
    private void Update()
    {
       if(timeBetweenLaunch <= 0 && Input.GetKeyDown(KeyCode.R))
        {
          
            StartCoroutine("LaunchSpikes");
            timeBetweenLaunch = startTimeBetweenLaunch;
        }
       else
        {
            timeBetweenLaunch -= Time.deltaTime;
        }
    }


    private IEnumerator LaunchSpikes()
    {
        lastShild = playerStatistic.shield;
        StartCoroutine ("IceDefence");
        for (int i = 0; i < maxCountCreatedSpikes; i++)
        {
            Instantiate(spike, gameObject.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenSpawnSpike);
        }  
    }
    private IEnumerator IceDefence()
    {
        playerStatistic.shield = icyShild;
        yield return new WaitForSeconds(activeTime);
        playerStatistic.shield = lastShild;
    }
}
