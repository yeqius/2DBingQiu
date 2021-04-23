using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    private int redNum, blueNum;
    public GameObject RedPoint, BluePoint;
    private SpriteRenderer Red, Blue;
    private Door redScore,blueScore;
    public GameObject redDoor,blueDoor;
    public Sprite[] counts;
    public GameObject[] Player;
    public GameObject BlueWin;
    public GameObject RedWin;
    private bool ballIsMove = true;
    void Start()
    {
        redScore = redDoor.GetComponent<Door>();
        blueScore = blueDoor.GetComponent<Door>();
        Red = RedPoint.GetComponent<SpriteRenderer>();
        Blue= BluePoint.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        redNum=redScore.GetScore();
        blueNum = blueScore.GetScore();
        if(redNum>9||blueNum>9)
        {
            redNum = 9;
            blueNum = 9;
        }
        Blue.sprite = counts[redNum];
        Red.sprite = counts[blueNum];
        if(blueNum==6)
        {
            ballIsMove = false;
            RedWin.SetActive(true);
        }
        if(redNum==6)
        {
            ballIsMove = false;
            BlueWin.SetActive(true);
            
        }

    }
    public bool GetBallStart()
    {
        return ballIsMove;
    }
   
}
