using UnityEngine;

public class SandStorm : MonoBehaviour
{
    private GameObject storm;
    public GameObject stormPrefab;
    public Transform playerPosition;
    

    private float positionX;
    private float startTimeBetweenSandStorm = 3f;
    private float timeBetweenSandStorm;



    private void Update()
    {
        


        if (timeBetweenSandStorm <= 0 && Input.GetKey(KeyCode.R))
        {
                Vector3 _vector = new Vector3(positionX, -2, 0);
                Instantiate(stormPrefab, playerPosition);
                timeBetweenSandStorm = startTimeBetweenSandStorm;  
        }
        else
        {
            timeBetweenSandStorm -= Time.deltaTime;
        }
    }



}
