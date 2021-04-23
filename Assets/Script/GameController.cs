using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int particalNum=0;
    public GameObject Ball;
    private bool makeoneBall=true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Partical"))
        {
            if(makeoneBall==true)
            StartCoroutine(MakeTheBall());
        }
       
    }
    private IEnumerator MakeTheBall()
    {
        makeoneBall = false;
        yield return new WaitForSeconds(2f);
        Instantiate(Ball, transform.position, Quaternion.identity);
        Destroy(this);
    }
}
