using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallContler : MonoBehaviour
{
    Vector3 formVec;
    private float a;
    private float[] speedGear = { 6f,8f,12f ,16f,20f};
    private int speedNum = 0;
    private bool checkChangeBall=false;
    private HitVec hitvec;
    private float balanceSpeed = 0;
    public GameObject partical;
    private GameControl gameControl;
    private Rigidbody2D rigidbody2D;
    private int HitNum=0;
    private bool BallStart = true;
    void Start()
    {
        a = Random.Range(0, 2);
        if (a < 1)
        {
            formVec = new Vector3(1 * speedGear[speedNum], 1 * speedGear[speedNum]);

        }
        else
        {
            formVec = new Vector3(-1 * speedGear[speedNum], -1 * speedGear[speedNum]);
        }
    }
    private void Awake()
    {
        gameControl = FindObjectOfType<GameControl>();
       
        rigidbody2D = GetComponent<Rigidbody2D>();
        //hitvec = FindObjectsOfType<HitVec>();
    }
    private void FixedUpdate()
    {
        BallStart = gameControl.GetBallStart();
        if (BallStart==true)
        {
            rigidbody2D.velocity = formVec;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 finVec = formVec;
        var x=formVec.x;
        var y=formVec.y;
        if (other.CompareTag("Walls"))
        {
           
            if (other.name == "wall-up")
            {
                y = -y; 
            }
            if (other.name == "wall-down")
            {
                y = -y;
            }
            if (other.name == "wall-left")
            {
                x = -x;
            }
            if (other.name == "wall-right")
            {
                x = -x;
            }
            formVec = new Vector3(x, y);
             

        }
        if(other.CompareTag("Stick"))
        {
            hitvec = other.GetComponent<HitVec>();
            if (speedNum<4)
            speedGear[speedNum] = speedGear[speedNum++];
            ChangeBallDirection();
        }
        if(other.CompareTag("Door"))
        {
            BallPartical();
        }
    }
    public void AbsSpeed()
    {
       
        if ((formVec.x == 0 && formVec.y != 0))
        {
            var y = formVec.y / Mathf.Abs(formVec.y);
            balanceSpeed = Mathf.Sqrt(Mathf.Pow(speedGear[speedNum], 2) + Mathf.Pow(speedGear[speedNum], 2));
            formVec = new Vector3(0, y * balanceSpeed);
        }
        if ((formVec.x != 0 && formVec.y == 0))
        {
            var x = formVec.x / Mathf.Abs(formVec.x);
            balanceSpeed = Mathf.Sqrt(Mathf.Pow(speedGear[speedNum], 2) + Mathf.Pow(speedGear[speedNum], 2));
            formVec = new Vector3( x * balanceSpeed,0);

        }
    }
    public void BallPartical()
    {
        Instantiate(partical, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
    public void ChangeBallDirection()
    {
       
        
        //if (checkChangeBall==true)
        {
            Vector3 lastVec = hitvec.GetVec();
            if (Mathf.Abs(lastVec.y) < 0.1)
            {
                lastVec = new Vector3(lastVec.x, 0);
            }
            lastVec = lastVec.normalized;
            var lx=lastVec.x;
            var ly=lastVec.y;
            formVec = new Vector3(lx * speedGear[speedNum], ly * speedGear[speedNum]);
            //AbsSpeed();
        }
    }
    public float[] GetBallSpeed()
    {
        return speedGear;
    }
}
