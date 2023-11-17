using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject Circle;
  public void SwitchScene()
    {

        Circle.SetActive(true);
        StartCoroutine(ITimer());
         
    }
    public void SceneReturn()
    {
        Circle.SetActive(true);
        StartCoroutine(ISecondTimer());
    }

    private IEnumerator ITimer()
    {
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene("OtherScene");
    }
    private IEnumerator ISecondTimer()
    {
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene("SampleScene");
    }
}
