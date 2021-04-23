using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum RotaVec { up,upright,upleft,down,downright,downleft,right,left}
public class RoatPar : MonoBehaviour
{
    public RotaVec rotaVec = RotaVec.down;
    private MakeParticle makeParticle;
    private Vector3 MoveVec;
    private float x;
    private float y;
    private Vector3 backgroundCenter = new Vector3(0, 0, 0);
    private Vector3 moveDir;
    public float speed=12f,dirSpeed;
    private float targetAngle, circleAngle=60f;
    void Start()
    {
        MoveParticle();
        moveDir = Vector3.right;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        StartCoroutine(MoveToCenter());
    }
    private void MoveParticle()
    {
        switch (rotaVec)
        {
            case RotaVec.down:
                MoveVec = new Vector3(0,-1);
                MoveVec=MoveVec.normalized;
                x = MoveVec.x;
                y = MoveVec.y;
                MoveVec = new Vector3(x*dirSpeed, y*dirSpeed);
                break;
            case RotaVec.downleft:
                MoveVec = new Vector3(-1, -1);
                MoveVec = MoveVec.normalized;
                x = MoveVec.x;
                y = MoveVec.y;
                MoveVec = new Vector3(x * dirSpeed, y * dirSpeed);
                break;
            case RotaVec.downright:
                MoveVec = new Vector3(1, -1);
                MoveVec = MoveVec.normalized;
                x = MoveVec.x;
                y = MoveVec.y;
                MoveVec = new Vector3(x * dirSpeed, y * dirSpeed);
                break;
            case RotaVec.up:
                MoveVec = new Vector3(0, 1);
                MoveVec = MoveVec.normalized;
                x = MoveVec.x;
                y = MoveVec.y;
                MoveVec = new Vector3(x * dirSpeed, y * dirSpeed);
                break;
            case RotaVec.upleft:
                MoveVec = new Vector3(-1, 1);
                MoveVec = MoveVec.normalized;
                x = MoveVec.x;
                y = MoveVec.y;
                MoveVec = new Vector3(x * dirSpeed, y * dirSpeed);
                break;
            case RotaVec.upright:
                MoveVec = new Vector3(1, 1);
                MoveVec = MoveVec.normalized;
                x = MoveVec.x;
                y = MoveVec.y;
                MoveVec = new Vector3(x * dirSpeed, y * dirSpeed);
                break;
            case RotaVec.left:
                MoveVec = new Vector3(-1,0);
                MoveVec = MoveVec.normalized;
                x = MoveVec.x;
                y = MoveVec.y;
                MoveVec = new Vector3(x * dirSpeed, y * dirSpeed);
                break;
            case RotaVec.right:
                MoveVec = new Vector3(1, 0);
                MoveVec = MoveVec.normalized;
                x = MoveVec.x;
                y = MoveVec.y;
                MoveVec = new Vector3(x * dirSpeed, y * dirSpeed);
                break;
                 

        }
    }
    private IEnumerator MoveToCenter()
    {
        bool explandMove = true;
        if(explandMove)
        {
            transform.position += MoveVec;
        }
       
        yield return new WaitForSeconds(0.3f);
        explandMove = false;
        yield return new WaitForSeconds(0.6f);

        moveDir = backgroundCenter - this.transform.position;
        targetAngle = 360 - Mathf.Atan2(moveDir.x, moveDir.y) * Mathf.Rad2Deg;
        //矫正方向到正对目标点
        this.transform.eulerAngles = new Vector3(0, 0, 90 + targetAngle);
        //产生偏移以制造弧度
        this.transform.rotation = this.transform.rotation * Quaternion.Euler(0, 0, circleAngle);
        this.transform.Translate(Vector3.right * Time.deltaTime * speed);
        yield return new WaitForSeconds(3.2f);
        {
            Destroy(this.gameObject);
        }

    }
}
