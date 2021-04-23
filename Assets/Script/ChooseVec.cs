using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ChooseVec : MonoBehaviour
{

    public  ControlPlayer controlPlayer = ControlPlayer.Null;
    public Sprite[] vecSprite;
    private SpriteRenderer spriteRenderer;
    private bool isReady = false;
    private float[] positionOneX = { -5.46f, -0.38f, 4.51f };
    private float[] positionTwoX = { -4.63f,0.45f, 5.34f };
    private float[] positionThreeX = { -3.75f,1.33f,6.22f};
    private float[] positionFourX = { -6.32f, -1.24f, 3.65f };
    private int PositionNum = 1;
    private float posititonY = 2.25f;
    void Start()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        //PlayerVecSprite();
        StartPosition();
    }

    // Update is called once per frame
    void Update()
    {
        switch (controlPlayer)
        {
            case ControlPlayer.PlayerOne:
                if (isReady == false)
                {
                    if (Input.GetAxis("Player1Horizontal") > 0f && PositionNum != 2)
                    {
                        PositionNum++;
                        transform.position = new Vector3(positionOneX[PositionNum], posititonY);
                    }
                    if (Input.GetAxis("Player1Horizontal") < 0f && PositionNum != 0 && isReady == false)
                    {
                        PositionNum--;
                        transform.position = new Vector3(positionOneX[PositionNum], posititonY);
                    }
                }
                if(Input.GetKeyDown(KeyCode.Joystick1Button0))
                {
                    if (PositionNum == 0 || PositionNum == 2)
                        isReady = true;

                }
                if (isReady == true)
                {
                    if (Input.GetKeyDown(KeyCode.Joystick1Button1))
                    {
                        isReady = false;
                    }
                }
                break;
            case ControlPlayer.PlayerTwo:
                if (isReady == false)
                {
                    if (Input.GetAxis("Player2Horizontal") > 0f && PositionNum != 2)
                    {
                        PositionNum++;
                        transform.position = new Vector3(positionTwoX[PositionNum], posititonY);
                    }
                    if (Input.GetAxis("Player2Horizontal") < 0f && PositionNum != 0)
                    {
                        PositionNum--;
                        transform.position = new Vector3(positionTwoX[PositionNum], posititonY);
                    }
                }
                   
                if (Input.GetKeyDown(KeyCode.Joystick2Button0))
                {
                    if (PositionNum == 0 || PositionNum == 2)
                        isReady = true;
                }
                if (isReady == true)
                {
                    if (Input.GetKeyDown(KeyCode.Joystick2Button1))
                    {
                        isReady = false;
                    }
                }
                break;
            case ControlPlayer.PlayerThree:
                if (isReady == false)
                {

                    if (Input.GetAxis("Player3Horizontal") > 0f && PositionNum != 2)
                    {
                        PositionNum++;
                        transform.position = new Vector3(positionThreeX[PositionNum], posititonY);
                    }
                    if (Input.GetAxis("Player3Horizontal") < 0f && PositionNum != 0)
                    {
                        PositionNum--;
                        transform.position = new Vector3(positionThreeX[PositionNum], posititonY);
                    }
                }
                if (Input.GetKeyDown(KeyCode.Joystick3Button0))
                {
                    if (PositionNum == 0 || PositionNum == 2)
                        isReady = true;
                }
                if (isReady == true)
                {
                    if (Input.GetKeyDown(KeyCode.Joystick3Button1))
                    {
                        isReady = false;
                    }
                }
                break;
            case ControlPlayer.PlayerFour:
                if (isReady == false)
                {
                    if (Input.GetAxis("Player4Horizontal") > 0f && PositionNum != 2)
                    {
                        PositionNum++;
                        transform.position = new Vector3(positionFourX[PositionNum], posititonY);
                    }
                    if (Input.GetAxis("Player4Horizontal") < 0f && PositionNum != 0)
                    {
                        PositionNum--;
                        transform.position = new Vector3(positionFourX[PositionNum], posititonY);
                    }
                }
                if (Input.GetKeyDown(KeyCode.Joystick4Button0))
                {
                    if(PositionNum==0||PositionNum==2)
                    isReady = true;
                }
                if(isReady==true)
                {
                    if(Input.GetKeyDown(KeyCode.Joystick4Button1))
                    {
                        isReady = false;
                    }
                }
                break;
        }
       

    }
    void PlayerVecSprite()
    {
        switch (controlPlayer)
        {
            case ControlPlayer.PlayerOne:
                spriteRenderer.sprite = vecSprite[0];
                break;
            case ControlPlayer.PlayerTwo:
                spriteRenderer.sprite = vecSprite[1];
                break;
            case ControlPlayer.PlayerThree:
                spriteRenderer.sprite = vecSprite[2];
                break;
            case ControlPlayer.PlayerFour:
                spriteRenderer.sprite = vecSprite[3];
                break;
        }
    }
    void StartPosition()
    {
        switch (controlPlayer)
        {
            case ControlPlayer.PlayerOne:
                transform.position = new Vector3(positionOneX[PositionNum], posititonY);
                break;
            case ControlPlayer.PlayerTwo:
                transform.position = new Vector3(positionTwoX[PositionNum], posititonY);
                break;
            case ControlPlayer.PlayerThree:
                transform.position = new Vector3(positionThreeX[PositionNum], posititonY);
                break;
            case ControlPlayer.PlayerFour:
                transform.position = new Vector3(positionFourX[PositionNum], posititonY);
                break;
        }
    }
   public int GetPositionNum()
    {
        return PositionNum;
    }
    public bool GetIsReady()
    {
        return isReady;
    }
}
