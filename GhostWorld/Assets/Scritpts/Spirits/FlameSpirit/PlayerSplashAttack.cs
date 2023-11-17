using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerSplashAttack : MonoBehaviour
{
    public LayerMask enemy;

    private float positionX = 7;
    private float positionY = 0.5f;
    private float angle = 0f;

    private float livingTime = 0.2f;

    private float splashAttackDamage = 1f;
    private bool hasAttacked = false;
    
    void Start()
    {
        StartCoroutine("SplashAttack");
        
    }

    void Update()
    {
        if(!hasAttacked)
        {
            
            Collider2D[] enemies = Physics2D.OverlapBoxAll(gameObject.transform.position, new Vector2(positionX, positionY), angle, enemy);
            for (int i = 0; i < enemies.Length; i++)
            {
                float Chanche = Random.Range(1, 3);
                enemies[i].GetComponent<EnemyStatistic>().TakeDamage(splashAttackDamage);
               
                if (Chanche == 3)
                {
                   
                    enemies[i].AddComponent<Ignition>();
                }
            }
           
            hasAttacked = true;
        }
        
    }

    private IEnumerator SplashAttack()
    {
        yield return new WaitForSeconds(livingTime);
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(gameObject.transform.position, new Vector2(positionX, positionY));
    }
}
