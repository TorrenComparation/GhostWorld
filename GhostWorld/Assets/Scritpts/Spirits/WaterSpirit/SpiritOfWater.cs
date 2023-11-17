using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritOfWater : MonoBehaviour
{
    [SerializeField]private GameObject waterLazerPrefab;
    private PlayerMoving playerMoving;
    private PlayerStatistic playerStatistic;
    private float timeBetweenWaterLazer;
    private float startTimeBetweenWaterLazer = 2f;
    private float attackTime = 2f;


    private void Start()
    {
      playerStatistic = gameObject.GetComponent<PlayerStatistic>();
      playerMoving = gameObject.GetComponent<PlayerMoving>();
    }

    private void Update()
    {
        playerStatistic.attackDamage = playerStatistic.heath / 10;
        if (Input.GetKeyDown(KeyCode.R) && timeBetweenWaterLazer <= 0 && playerMoving.isGrounded == true)
        {
  
            Instantiate(waterLazerPrefab, gameObject.transform);
            timeBetweenWaterLazer = startTimeBetweenWaterLazer;

            StartCoroutine("ActiveLazer");

        }
        else
        {
            timeBetweenWaterLazer -= Time.deltaTime;
        }

    }

    private IEnumerator ActiveLazer()
    {
        playerMoving.isCanMove = false;
        yield return new WaitForSeconds(attackTime);
        playerMoving.isCanMove = true;
    }
}