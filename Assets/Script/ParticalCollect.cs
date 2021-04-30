using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalCollect : MonoBehaviour
{
    // Start is called before the first frame update
    private int particalnum = 0;
    private float DestoryTime = 1.0f;
    private bool Destory = false;
    private bool changeTime = false;
    public GameObject particalMaker, ballMaker;
    void Start()
    {
        particalMaker = FindObjectOfType<particalMaker>();
    }

    // Update is called once per frame
    void Update()
    {
        if(particalnum==8&&changeTime==true)
        {
            DestoryTime = Time.time + DestoryTime;
            changeTime = false;
            Destory = true;
        }
        if (Time.time > DestoryTime &&Destory==true)
        {
            Destory(particalMaker);
            Instantiate(ballMaker, transform.position, Quaternion.identity);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Partical")
        {
            particalnum++;
        }
    }
}
