using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Door : MonoBehaviour
{
    private int score=0;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       
       
        if(other.tag=="Ball")
        {
            score++;
            
        }
        
    }
    public int GetScore()
    {
       
           return score;
        
    }
}
