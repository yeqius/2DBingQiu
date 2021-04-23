using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LocatScence : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(LocaScenTime());
    }
    private IEnumerator LocaScenTime()
    {
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene("SampleScene");
    }
}
