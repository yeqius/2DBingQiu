using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChooseTeam : MonoBehaviour
{
    // Start is called before the first frame update
    
    private ControlPlayer ControlPlayer;
    private bool[] IsReady= { false,false,false,false};
    private  int[] PositionNum= { 0,0,0,0};
    public GameObject[] PlayerVec;
    public  GameObject[] Player;
    private PlayerController PlayerNumOne;
    private PlayerController PlayerNumTwo;
    private PlayerController PlayerNumThree;
    private PlayerController PlayerNumFour;
    private ChooseVec ChooseOne;
    private ChooseVec ChooseTwo;
    private ChooseVec ChooseThree;
    private ChooseVec ChooseFour;
    private static int[] RedNum = { 0, 0 };
    private static int[] BlueNum = { 0, 0 };
    public Transform[] birthPositions = new Transform[4];
    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "ChooseTeam")
        {
            ChooseOne = PlayerVec[0].GetComponent<ChooseVec>();
            ChooseTwo = PlayerVec[1].GetComponent<ChooseVec>();
            ChooseThree = PlayerVec[2].GetComponent<ChooseVec>();
            ChooseFour = PlayerVec[3].GetComponent<ChooseVec>();
        }
        if(SceneManager.GetActiveScene().name == "SampleScene")
        {
            PlayerNumOne = Player[0].GetComponent<PlayerController>();
            PlayerNumTwo = Player[1].GetComponent<PlayerController>();
            PlayerNumThree = Player[2].GetComponent<PlayerController>();
            PlayerNumFour = Player[3].GetComponent<PlayerController>();

        }
            
    }
    private void Start()
    {
        
    }
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "ChooseTeam")
        {
            JustTeam();
        }
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            CreatPlayer();
        }
    }
    void JustTeam()
    {
        IsReady[0] = ChooseOne.GetIsReady();
        IsReady[1] = ChooseTwo.GetIsReady();
        IsReady[2] = ChooseThree.GetIsReady();
        IsReady[3] = ChooseFour.GetIsReady();
        PositionNum[0] = ChooseOne.GetPositionNum();
        PositionNum[1] = ChooseTwo.GetPositionNum();
        PositionNum[2] = ChooseThree.GetPositionNum();
        PositionNum[3] = ChooseFour.GetPositionNum();
        if (IsReady[0] == true && IsReady[1] == true && IsReady[2] == true && IsReady[3] == true)
        {
            int OneTeamNum1=0, OneTeamNum2=1,OtherTeam1=0,OtherTeam2=0;
            for (OneTeamNum1 = 0; OneTeamNum1 <= 2; OneTeamNum1++)
            {
                for (OneTeamNum2 = 1; OneTeamNum2 <= 2; OneTeamNum2++)
                {
                    if (PositionNum[OneTeamNum1] == PositionNum[OneTeamNum2])
                    {
                        break;
                    }
                }

            }
            int leveNum = 6 - OneTeamNum1 - OneTeamNum2;
            for (int v = 0; v <=leveNum; v++)
            {
                if (v != OneTeamNum1 && v != OneTeamNum2)
                {
                    OtherTeam1 = v;
                }  
            }
            for (int d = 0; d <=leveNum; d++)
            {
                if (d != OneTeamNum1 && d != OneTeamNum2 && d != OtherTeam1)
                {
                    OtherTeam2 = d;
                }
            }
            if(PositionNum[OneTeamNum1]==0)
            {
                RedNum[0] = OneTeamNum1;
                RedNum[1] = OneTeamNum2;
                BlueNum[0] = OtherTeam1;
                BlueNum[1] = OtherTeam2;
            }
            else
            {
                BlueNum[0] = OneTeamNum1;
                BlueNum[1] = OneTeamNum2;
                RedNum[0] = OtherTeam1;
                RedNum[1] = OtherTeam2;
            }
            Debug.Log(RedNum[0]+"  "+RedNum[1]+"is  RedTeam");
            Debug.Log(BlueNum[0] + "  " + BlueNum[1] + "is  BLueTeam");
            SceneManager.LoadScene("LocScene");
        }
        
    }
    void CreatPlayer()
    {
        switch(RedNum[0])
        {
            case 0:
                PlayerNumOne.controlPlayer = ControlPlayer.PlayerOne;
                break;
            case 1:
                PlayerNumOne.controlPlayer = ControlPlayer.PlayerTwo;
                break;
            case 2:
                PlayerNumOne.controlPlayer = ControlPlayer.PlayerThree;
                break;
            case 3:
                PlayerNumOne.controlPlayer = ControlPlayer.PlayerFour;
                break;
        }
        switch (RedNum[1])
        {
            case 0:
                PlayerNumTwo.controlPlayer = ControlPlayer.PlayerOne;
                break;
            case 1:
                PlayerNumTwo.controlPlayer = ControlPlayer.PlayerTwo;
                break;
            case 2:
                PlayerNumTwo.controlPlayer = ControlPlayer.PlayerThree;
                break;
            case 3:
                PlayerNumTwo.controlPlayer = ControlPlayer.PlayerFour;
                break;
        }
        switch (BlueNum[0])
        {
            case 0:
                PlayerNumThree.controlPlayer = ControlPlayer.PlayerOne;
                break;
            case 1:
                PlayerNumThree.controlPlayer = ControlPlayer.PlayerTwo;
                break;
            case 2:
                PlayerNumThree.controlPlayer = ControlPlayer.PlayerThree;
                break;
            case 3:
                PlayerNumThree.controlPlayer = ControlPlayer.PlayerFour;
                break;
        }
        switch (BlueNum[1])
        {
            case 0:
                PlayerNumFour.controlPlayer = ControlPlayer.PlayerOne;
                break;
            case 1:
                PlayerNumFour.controlPlayer = ControlPlayer.PlayerTwo;
                break;
            case 2:
                PlayerNumFour.controlPlayer = ControlPlayer.PlayerThree;
                break;
            case 3:
                PlayerNumFour.controlPlayer = ControlPlayer.PlayerFour;
                break;
        }
    }
}
