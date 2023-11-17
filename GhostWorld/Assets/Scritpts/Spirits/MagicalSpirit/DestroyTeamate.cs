using System.Collections;
using UnityEngine;

public class DestroyTeamate : MonoBehaviour
{
    private float timeOfLiving;
    void Start()
    {
        timeOfLiving = GetComponent<TeamateStatistic>().timeOfLiving;
        StartCoroutine("KillTeamate");
    }

    private IEnumerator KillTeamate()
    {
        yield return new WaitForSeconds(timeOfLiving);
        Destroy(gameObject);
    }
}
