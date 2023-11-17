using UnityEngine;

public class MagicalSpirit : MonoBehaviour
{

    public GameObject voidZone;
    public GameObject teamate;
    public Transform zonePosition;
    public Transform player;

    public LayerMask enemy;

    public float zoneRange;
    private bool hasInstantiate;
    private float startTimeBetweenSummon = 2f;
    private float timeBetweenSummon;




    void Update()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(zonePosition.position, zoneRange, enemy);

        if (enemies.Length >= 1 && hasInstantiate == false)
        {

            Instantiate(voidZone, zonePosition);
            hasInstantiate = true;
        }

        if (enemies.Length == 0 && hasInstantiate == true)
        {
            hasInstantiate = false;
            Destroy(transform.Find("VoidZone(Clone)").gameObject);
        }


        if (timeBetweenSummon <= 0 && Input.GetKey(KeyCode.R))
        {
            Vector3 playerPosition = new Vector3(player.position.x, player.position.y, player.position.z);
            Instantiate(teamate, playerPosition, Quaternion.identity);
            timeBetweenSummon = startTimeBetweenSummon;
        }
        else
        {
            timeBetweenSummon -= Time.deltaTime;
        }


    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(zonePosition.position, zoneRange);
    }
}
