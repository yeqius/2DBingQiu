using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WinImage : MonoBehaviour
{
    public Image bgimages2;
    public float fadeTime = 0.5f;
    public float fadeTimeTrigger = 0;
    private bool show = true;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (show)
        {
            fadeTimeTrigger += Time.deltaTime;
            bgimages2.color = new Color(1, 1, 1, (fadeTimeTrigger / fadeTime));
        }
    }
}
