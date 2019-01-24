using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerVSAIGameScript : MonoBehaviour
{
	private int totalBlueInHouse, totalGreenInHouse;

	public GameObject BlueFrame, GreenFrame;

	public GameObject BluePlayerI_Border,BluePlayerII_Border,BluePlayerIII_Border,BluePlayerIV_Border;
	public GameObject GreenPlayerI_Border,GreenPlayerII_Border,GreenPlayerIII_Border,GreenPlayerIV_Border;

	public Vector3 BluePlayerI_Pos,BluePlayerII_Pos,BluePlayerIII_Pos,BluePlayerIV_Pos;
	public Vector3 GreenPlayerI_Pos,GreenPlayerII_Pos,GreenPlayerIII_Pos,GreenPlayerIV_Pos;

	public Button BluePlayerI_Button, BluePlayerII_Button, BluePlayerIII_Button, BluePlayerIV_Button;
	public Button GreeplayerI_Button,GreeplayerII_Button,GreeplayerIII_Button,GreeplayerIV_Button;

	public GameObject BlueScreen,GreenScreen;

	public Text BlueRankText, GreenRankText;

	private string playerTurn="BLUE";

	public Transform diceRoll;

	public Button DiceRollButton;

	public Transform BlueDiceRollPosition, GreenDiceRollPosition;

	private string currentPlayer="none";
	private string currentPlayerName = "none";

	public GameObject bluePlayerI, bluePlayerII, bluePlayerIII, bluePlayerIV;
	public GameObject greenPlayerI, greenPlayerII, greenPlayerIII, greenPlayerIV;

	private int bluePlayerI_Steps,bluePlayerII_Steps,bluePlayerIII_Steps,bluePlayerIV_Steps;
	private int greenPlayerI_Steps,greenPlayerII_Steps,greenPlayerIII_Steps,greenPlayerIV_Steps;

	//----------------Selection of dice number Animation------------------
	private int selectDiceNumAnimation;

	//----------------Dice Animation------------------
	public GameObject dice1_Roll_Animation;
	public GameObject dice2_Roll_Animation;
	public GameObject dice3_Roll_Animation;
	public GameObject dice4_Roll_Animation;
	public GameObject dice5_Roll_Animation;
	public GameObject dice6_Roll_Animation;

	//Players movement corresponding to blocks
	public List<GameObject> blueMovemenBlock=new List<GameObject>();
	public List<GameObject> greenMovementBlock=new List<GameObject>();

	//Random generation of dice number
	private System.Random randomNo;
	public GameObject confirmScreen;
	public GameObject gameCompletedScreen;

	// Use this for initialization
	void Start () 
	{
		
	}
}
