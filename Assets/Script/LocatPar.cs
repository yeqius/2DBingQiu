using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocatPar : MonoBehaviour
{
    public GameObject aroundPosition;
    public float speed = 50f;
    private float Rb;
    private Vector3 LeaveDir;
    private Vector3 CloseDir;
    private float x, y;
    private bool expland=false,firstexpland=true;
    void Start()
    {
        
    }
    void Update()
    {
        transform.RotateAround(aroundPosition.transform.position, transform.forward, speed * Time.deltaTime);

        LeaveDir = transform.position - aroundPosition.transform.position;

        x = LeaveDir.x;
        y = LeaveDir.y;
        Rb = Mathf.Sqrt(Mathf.Pow(LeaveDir.x, 2) + Mathf.Pow(LeaveDir.y, 2));
        StartCoroutine(Moveed());
        if (Rb <= 1.5f&&expland==true)
        {
            Rb = Rb + 0.1f;
            LeaveDir = LeaveDir.normalized;
            x = LeaveDir.x;
            y = LeaveDir.y;
            LeaveDir = new Vector3(x * Rb * 0.002f, y * Rb * 0.002f);
            transform.position += LeaveDir;
        }
         if (Rb > 0.5 && expland == false)
        {
            Rb = Rb - 0.1f;
            LeaveDir = LeaveDir.normalized;
            x = LeaveDir.x;
            y = LeaveDir.y;
            LeaveDir = new Vector3(-x * Rb * 0.002f, -y * Rb * 0.002f);
            transform.position += LeaveDir;

        }

        
    }
    private IEnumerator Moveed()
    {
        if(expland==true)
        {
            yield return new WaitForSeconds(1f);
            expland = false;
        }  
        if(expland == false)
        {
                yield return new WaitForSeconds(1f);
                expland = true;  
        }
    }
}
