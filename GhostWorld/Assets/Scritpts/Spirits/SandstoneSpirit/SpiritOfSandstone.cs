using UnityEngine;

public class SpiritOfSandstone : MonoBehaviour
{
    public float speedReduction;
    public float startedDefense = 1f;
    public float defense = 0.7f;
    private float heath;
    private float thirdtyProcent = 6f;
    private GameObject player;
    private PlayerStatistic _shield;
    void Start()
    {
        
        _shield = gameObject.GetComponent<PlayerStatistic>();
    }

    
    void Update()
    {







        heath = gameObject.GetComponent<PlayerStatistic>().heath;

        if (heath <= thirdtyProcent)
        {
            _shield.shield = defense;
        }
        else if(heath > thirdtyProcent)
        {
            _shield.shield = startedDefense;
        }
    }
}
