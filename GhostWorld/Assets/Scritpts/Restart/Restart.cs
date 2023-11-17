using UnityEngine;

public class Restart : MonoBehaviour
{
    public GameObject player;
    public GameObject diePanel;
    public GameObject[] otherUI;
    public GameObject ourWorld;
    private PlayerStatistic playerHeath;
    private SearchNearbyStatue statue;
    private Transform statuePosition;

    private int regeneredHeath = 20;
    private bool isRegenred = false;

    private void Start()
    {
        playerHeath = FindObjectOfType<PlayerStatistic>(); 
        statue = player.GetComponent<SearchNearbyStatue>();
    }
    private void Update()
    {
        statuePosition = statue.closestStatuePosition;     
    }
    public void Restarted()
    {
        diePanel.SetActive(false);
        ourWorld.SetActive(true);
        Vector3 SpawnPoint = new Vector3(0, 0, 0);


        foreach (GameObject _object in otherUI)
        {
            _object.SetActive(true);
        }
        if(statuePosition != null)
        {
            player.transform.position = statuePosition.position;
        }
        else
        {
            player.transform.position = SpawnPoint;
        }
        
        isRegenred = true;

        if (isRegenred == true)
        {
            playerHeath.Regenerade(regeneredHeath);
            isRegenred = false;
        }
        
    }
}
