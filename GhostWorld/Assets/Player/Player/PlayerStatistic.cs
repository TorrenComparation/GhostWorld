using UnityEngine;

public class PlayerStatistic : MonoBehaviour
{
    public float deadGhosts;
    public float heath = 20f;
    public float attackDamage = 10f;
    public float shield = 1f;
    public float speed = 3f;
    public bool IsImmune = false;

    public void Regenerade(int regeneradeHeath)
    {
        heath = regeneradeHeath;
    }

   
    public void TakeHit(float damage)
    {
        heath -= damage * shield;
    }
    
}
