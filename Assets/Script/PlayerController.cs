using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ControlPlayer { Null, PlayerOne, PlayerTwo, PlayerThree, PlayerFour }
public class PlayerController : MonoBehaviour
{
    public GameObject upStick, downStick;
    public float speed;
    public ControlPlayer controlPlayer=ControlPlayer.Null;
    float horizontal;
    float vertical;
    private Animator animator;
    public GameObject animatorObject;
    void Start()
    {
       
    }
    private void Awake()
    {
        animator = animatorObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    private void Update()
    {
        CheckHitBall();
    }
    private void FixedUpdate()
    {
        Move();
        
    }
    private void Move()
    {
        switch(controlPlayer)
         {
          case ControlPlayer.PlayerOne:
                horizontal = Input.GetAxis("Player1Horizontal");
                vertical = Input.GetAxis("Player1Vertical");
                break;
          case ControlPlayer.PlayerTwo:
                horizontal = Input.GetAxis("Player2Horizontal");
                vertical = Input.GetAxis("Player2Vertical");
                break;
          case ControlPlayer.PlayerThree:
                horizontal = Input.GetAxis("Player3Horizontal");
                vertical = Input.GetAxis("Player3Vertical");
                break;
          case ControlPlayer.PlayerFour:
                horizontal = Input.GetAxis("Player4Horizontal");
                vertical = Input.GetAxis("Player4Vertical");
                break;
        }
        Vector3 NorVector = new Vector3(horizontal, -vertical);
        NorVector.Normalize();
        if(NorVector.x==0&&NorVector.y==0)
        {
            animator.SetBool("Idle", true);
            animator.SetBool("Walk", false);
        }
        else
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Walk", true);
        }
        transform.position += NorVector*speed;
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        if (info.normalizedTime >= 1.0f && (info.IsName("moveStickR")||info.IsName("moveStickB")))
        {
            animator.SetBool("MoveStick", false);
            Debug.Log("MoveStick=false");
        }
    }
    void CheckHitBall()
    {
        switch (controlPlayer)
        {
            case ControlPlayer.PlayerOne:
                if(Input.GetKeyDown(KeyCode.Joystick1Button2))
                {

                    animator.SetBool("MoveStick", true);
                    Debug.Log("MoveStick=true");
                }
                break;
            case ControlPlayer.PlayerTwo:
                if (Input.GetKeyDown(KeyCode.Joystick2Button2))
                {

                    animator.SetBool("MoveStick", true);
                }
                break;
            case ControlPlayer.PlayerThree:
                if (Input.GetKeyDown(KeyCode.Joystick3Button2))
                {

                    animator.SetBool("MoveStick", true);
                }
                break;
            case ControlPlayer.PlayerFour:
                if (Input.GetKeyDown(KeyCode.Joystick4Button2))
                {
                    animator.SetBool("MoveStick", true);
                }
                break;
        }
    }
}
