using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitVec : MonoBehaviour
{
    Vector3 NorVector;
    public GameObject hitBallVecDir;
  
    public ControlPlayer controlPlayer = ControlPlayer.Null;
    private float angle1,angle2;
    public GameObject hitAnima;
    private Animator hitAnimator;
    private float rotaZ;
    // Start is called before the first frame update
    void Start()
    {
        
      
    }
    private void Awake()
    {
        hitAnimator = hitAnima.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        switch(controlPlayer)
        {
            case ControlPlayer.PlayerOne:
                
                
                    angle1 = Vector3.Angle(new Vector3(1, 1), NorVector);
                    angle2 = Vector3.Angle(new Vector3(1, -1), NorVector);
                  if(angle2<90)
                    if (Input.GetKey(KeyCode.Joystick1Button5))
                    {
                        transform.Rotate(Vector3.forward, 150 * Time.deltaTime, Space.Self);
                    }
                    if(angle1<90)
                    if (Input.GetKey(KeyCode.Joystick1Button4))
                    {
                        transform.Rotate(-Vector3.forward, 150 * Time.deltaTime, Space.Self);
                    }
                
                break;
            case ControlPlayer.PlayerTwo:

                angle1 = Vector3.Angle(new Vector3(1, 1), NorVector);
                angle2 = Vector3.Angle(new Vector3(1, -1), NorVector);
                if (angle2 < 90)
                    if (Input.GetKey(KeyCode.Joystick2Button5))
                    {
                        transform.Rotate(Vector3.forward, 150 * Time.deltaTime, Space.Self);
                    }
                if (angle1 < 90)
                    if (Input.GetKey(KeyCode.Joystick2Button4))
                    {
                        transform.Rotate(-Vector3.forward, 150 * Time.deltaTime, Space.Self);
                    }
                
                break;
            case ControlPlayer.PlayerThree:

                angle1 = Vector3.Angle(new Vector3(-1, 1), NorVector);
                angle2 = Vector3.Angle(new Vector3(-1, -1), NorVector);
                if (angle2 < 90)
                    if (Input.GetKey(KeyCode.Joystick3Button5))
                    {
                        transform.Rotate(-Vector3.forward, 150 * Time.deltaTime, Space.Self);
                    }
                if (angle1 < 90)
                    if (Input.GetKey(KeyCode.Joystick3Button4))
                    {
                        transform.Rotate(Vector3.forward, 150 * Time.deltaTime, Space.Self);
                    }
                
                break;
            case ControlPlayer.PlayerFour:
                angle1 = Vector3.Angle(new Vector3(-1, 1), NorVector);
                angle2 = Vector3.Angle(new Vector3(-1, -1), NorVector);
                if (angle2 < 90)
                    if (Input.GetKey(KeyCode.Joystick4Button5))
                    { 
                        transform.Rotate(-Vector3.forward, 150 * Time.deltaTime, Space.Self);
                    }

                if (angle1 < 90)
                    if (Input.GetKey(KeyCode.Joystick4Button4))
                    {
                        transform.Rotate(Vector3.forward, 150 * Time.deltaTime, Space.Self);
                    }
                
                break;
        }
            NorVector = hitBallVecDir.transform.position - transform.position;
        AnimatorStateInfo info = hitAnimator.GetCurrentAnimatorStateInfo(0);
        if (info.normalizedTime >= 1.0f && info.IsName("HitBallCreat"))
        {
            hitAnimator.SetBool("HitBall", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name=="Ball"||other.name=="Ball(Clone)")
        {
            hitAnimator.SetBool("HitBall", true);
        }
        
    }
    public Vector3 GetVec()
    {  
        return NorVector; 
    }
}
