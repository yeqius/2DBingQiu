using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    // Start is called before the first frame updates
    private bool changeBallVec;
    
    void Start()
    {
        changeBallVec = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name=="Ball")
        {
            changeBallVec = true;
        }
    }
   public bool CheckBallOnTrigger()
    {
        return changeBallVec;
    }
}
