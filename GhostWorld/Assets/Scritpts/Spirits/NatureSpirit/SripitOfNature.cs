using UnityEngine;

public class SripitOfNature : MonoBehaviour
{
    private PlayerStatistic _playerStatistic;
    public Transform playerPosition;
    public GameObject vineZone;

    public LayerMask enemy;

  
    private float timeBetweenVine;
    private float startTimeBetweenVine = 4f;
    private bool IsImmune = true;
    public float locatorRange;


    private void Start()
    {
        _playerStatistic = GetComponent<PlayerStatistic>();
        _playerStatistic.IsImmune = IsImmune;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R) && timeBetweenVine <= 0)
        {
            Collider2D[] enemies = Physics2D.OverlapCircleAll(playerPosition.position, locatorRange, enemy);
            for (int i = 0; i < enemies.Length; i++)
            {
                Instantiate(vineZone, enemies[i].transform.position, Quaternion.identity);
            }
            timeBetweenVine = startTimeBetweenVine;
        }
        else
        {
            timeBetweenVine -= Time.deltaTime;
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(playerPosition.position, locatorRange);
    }
}
