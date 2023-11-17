using UnityEngine;
using UnityEngine.UI;

public class ButtonTracker : MonoBehaviour
{
    private MiniMapWithStatues miniMap;
    private GameObject player;
    public Button[] buttons;
    public Transform[] Statues;
    Vector3[] TransformTo = new Vector3[5];

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            miniMap = player.GetComponent<MiniMapWithStatues>(); 
        }
        for (int i = 0; i < Statues.Length; i++)
        {
           TransformTo[i] = Statues[i].transform.position;
        }
    }
    public void PressButton(Button button)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            
            if (buttons[i].name == button.name)
            {
               player.transform.position = TransformTo[i];
                miniMap.map.SetActive(false);
                miniMap.hasMapOpen = false;
            }
            
        }
    }
}


