using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeParticle : MonoBehaviour
{
    public GameObject[] partical;
    public GameObject remakeBall;
    private int i = 0;
    void Start()
    {
        Instantiate(remakeBall, new Vector3(0,0,0), Quaternion.identity);
        for (i = 0; i < partical.Length; i++)
        {
            Instantiate(partical[i], transform.position, Quaternion.identity);
        }
    }

    void Update()
    {
        
    }
    
}
