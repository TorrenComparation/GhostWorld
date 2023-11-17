using UnityEngine;

public class Die : MonoBehaviour
{
    public GameObject diePanel;
    public GameObject[] otherUI;
    public GameObject ourWorld;
    private float minHeath = 0f;
    private float Heath;

    private void Update()
    {
        Heath = this.gameObject.GetComponent<PlayerStatistic>().heath;
        
        if (Heath <= minHeath)
        {
            hasDead();
        }
    }


    public void hasDead()
    {

        diePanel.SetActive(true);
        ourWorld.SetActive(false);
   

        foreach (GameObject _object in otherUI)
        {
            _object.SetActive(false);
        }
    }

}
