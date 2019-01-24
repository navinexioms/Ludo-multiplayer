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
	public Button GreenPlayerI_Button,GreenPlayerII_Button,GreenPlayerIII_Button,GreenPlayerIV_Button;

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

	void InitializeDice()
	{
		print ("Dice interactable becomes true");

		DiceRollButton.interactable = true;
		
		dice1_Roll_Animation.SetActive (false);
		dice2_Roll_Animation.SetActive (false);
		dice3_Roll_Animation.SetActive (false);
		dice4_Roll_Animation.SetActive (false);
		dice5_Roll_Animation.SetActive (false);
		dice6_Roll_Animation.SetActive (false);

		//==============CHECKING WHO PLAYER WINS SURING===========//
		switch (ExtraSceneController.HowManyPlayers) 
		{
		case 2:
			if (totalBlueInHouse > 3) 
			{
				print ("Player Wins");
				playerTurn = "none";
			}
			if (totalGreenInHouse > 3) 
			{
				print ("AI Wins");
				playerTurn = "none";
			}
			break;
		}

		//=============getting currentPlayer Value===========//
		if (currentPlayerName.Contains ("BLUE PLAYER")) 
		{
			if (currentPlayerName == "BLUE PLAYER I") 
			{
				currentPlayer = BluePlayerI_Script.BluePlayerI_ColName;
				print ("currentPlayerName:" + currentPlayerName);
				print ("currentPlayer:" + currentPlayer);
			}
			if (currentPlayerName == "BLUE PLAYER II") 
			{
				currentPlayer = BluePlayerII_Script.BluePlayerII_ColName;
				print ("currentPlayerName:" + currentPlayerName);
				print ("currentPlayer:" + currentPlayer);
			}
			if (currentPlayerName == "BLUE PLAYER III") 
			{
				currentPlayer = BluePlayerIII_Script.BluePlayerIII_ColName;
				print ("currentPlayerName:" + currentPlayerName);
				print ("currentPlayer:" + currentPlayer);
			}
			if (currentPlayerName == "BLUE PLAYER IV") 
			{
				currentPlayer = BluePlayerIV_Script.BluePlayerIV_ColName;
				print ("currentPlayerName:" + currentPlayerName);
				print ("currentPlayer:" + currentPlayer);
			}
		}
		if (currentPlayerName.Contains ("GREEN PLAYER")) 
		{
			if (currentPlayerName == "GREEN PLAYER I") 
			{
				currentPlayer = GreenPlayerI_Script.GreenPlayerI_ColName;
				print ("currentPlayerName:" + currentPlayerName);
				print ("currentPlayer:" + currentPlayer);
			}
			if (currentPlayerName == "GREEN PLAYER II") 
			{
				currentPlayer = GreenPlayerII_Script.GreenPlayerII_ColName;
				print ("currentPlayerName:" + currentPlayerName);
				print ("currentPlayer:" + currentPlayer);
			}
			if (currentPlayerName == "GREEN PLAYER III") 
			{
				currentPlayer = GreenPlayerIII_Script.GreenPlayerIII_ColName;
				print ("currentPlayerName:" + currentPlayerName);
				print ("currentPlayer:" + currentPlayer);
			}
			if (currentPlayerName == "GREEN PLAYER IV") 
			{
				currentPlayer = GreenPlayerIV_Script.GreenPlayerIV_ColName;
				print ("currentPlayerName:" + currentPlayerName);
				print ("currentPlayer:" + currentPlayer);
			}
		}

		//============PLayer vs Opponent=============//
		if (currentPlayer != "none") 
		{
			switch (ExtraSceneController.HowManyPlayers) 
			{
			case 2:
				if (currentPlayerName.Contains ("BLUE PLAYER")) 
				{
					if (currentPlayer == GreenPlayerI_Script.GreenPlayerI_ColName && (currentPlayer != "Star" && GreenPlayerI_Script.GreenPlayerI_ColName != "Star")) 
					{
						greenPlayerI.transform.position = GreenPlayerI_Pos;
						GreenPlayerI_Script.GreenPlayerI_ColName = "none";
						greenPlayerI_Steps = 0;
						playerTurn = "BLUE";
					}
					if (currentPlayer == GreenPlayerII_Script.GreenPlayerII_ColName && (currentPlayer != "Star" && GreenPlayerII_Script.GreenPlayerII_ColName != "Star")) 
					{
						greenPlayerII.transform.position = GreenPlayerII_Pos;
						GreenPlayerII_Script.GreenPlayerII_ColName = "none";
						greenPlayerII_Steps = 0;
						playerTurn = "BLUE";
					}
					if (currentPlayer == GreenPlayerIII_Script.GreenPlayerIII_ColName && (currentPlayer != "Star" && GreenPlayerIII_Script.GreenPlayerIII_ColName != "Star")) 
					{
						greenPlayerIII.transform.position = GreenPlayerIII_Pos;
						GreenPlayerIII_Script.GreenPlayerIII_ColName = "none";
						greenPlayerIII_Steps = 0;
						playerTurn = "BLUE";
					}
					if (currentPlayer == GreenPlayerIV_Script.GreenPlayerIV_ColName && (currentPlayer != "Star" && GreenPlayerIV_Script.GreenPlayerIV_ColName != "Star")) 
					{
						greenPlayerIV.transform.position = GreenPlayerIV_Pos;
						GreenPlayerIV_Script.GreenPlayerIV_ColName = "none";
						greenPlayerIV_Steps = 0;
						playerTurn = "BLUE";
					}
				}

				if (currentPlayerName.Contains ("GREEN PLAYER")) 
				{
					if (currentPlayer == BluePlayerI_Script.BluePlayerI_ColName && (currentPlayer != "Star" && BluePlayerI_Script.BluePlayerI_ColName != "Star")) 
					{
						bluePlayerI.transform.position = BluePlayerI_Pos;
						BluePlayerI_Script.BluePlayerI_ColName = "none";
						bluePlayerI_Steps = 0;
						playerTurn = "GREEN";
					}
					if (currentPlayer == BluePlayerII_Script.BluePlayerII_ColName && (currentPlayer != "Star" && BluePlayerII_Script.BluePlayerII_ColName != "Star")) 
					{
						bluePlayerII.transform.position = BluePlayerII_Pos;
						BluePlayerII_Script.BluePlayerII_ColName = "none";
						bluePlayerII_Steps = 0;
						playerTurn = "GREEN";
					}
					if (currentPlayer == BluePlayerIII_Script.BluePlayerIII_ColName && (currentPlayer != "Star" && BluePlayerIII_Script.BluePlayerIII_ColName != "Star")) 
					{
						bluePlayerIII.transform.position = BluePlayerIII_Pos;
						BluePlayerIII_Script.BluePlayerIII_ColName = "none";
						bluePlayerIII_Steps = 0;
						playerTurn = "GREEN";
					}
					if (currentPlayer == BluePlayerIV_Script.BluePlayerIV_ColName && (currentPlayer != "Star" && BluePlayerIV_Script.BluePlayerIV_ColName != "Star")) 
					{
						bluePlayerIV.transform.position = BluePlayerIV_Pos;
						BluePlayerIV_Script.BluePlayerIV_ColName = "none";
						bluePlayerIV_Steps = 0;
						playerTurn = "GREEN";
					}
				}
				break;
			}
		}
		switch (ExtraSceneController.HowManyPlayers) 
		{
		case 2:
			if (playerTurn == "BLUE") {
				diceRoll.position = BlueDiceRollPosition.position;
				BlueFrame.SetActive (true);
				GreenFrame.SetActive (false);
			}
			if (playerTurn == "GREEN") {
				diceRoll.position = GreenDiceRollPosition.position;
				BlueFrame.SetActive (false);
				GreenFrame.SetActive (true);
			}
			//=================disabling buttons==============//
			BluePlayerI_Button.interactable = false;
			BluePlayerII_Button.interactable = false;
			BluePlayerIII_Button.interactable = false;
			BluePlayerIV_Button.interactable = false;

			GreenPlayerI_Button.interactable = false;
			GreenPlayerII_Button.interactable = false;
			GreenPlayerI_Button.interactable = false;
			GreenPlayerIV_Button.interactable = false;

			//===================disabling Animations===========//
			BluePlayerI_Border.SetActive (false);
			BluePlayerII_Border.SetActive (false);
			BluePlayerIII_Border.SetActive (false);
			BluePlayerIV_Border.SetActive (false);

			GreenPlayerI_Border.SetActive (false);
			GreenPlayerII_Border.SetActive (false);
			GreenPlayerIII_Border.SetActive (false);
			GreenPlayerIV_Border.SetActive (false);
			break;
		}
		selectDiceNumAnimation = 0;
	}
	public void DiceRoll()
	{
		DiceRollButton.interactable = false;
		print ("DiceRollButton interactable:" + DiceRollButton.interactable);
		selectDiceNumAnimation = randomNo.Next (1, 7);
		switch (selectDiceNumAnimation) 
		{
		//when got one plays one animation
		case 1:
			dice1_Roll_Animation.SetActive (true);
			dice2_Roll_Animation.SetActive (false);
			dice3_Roll_Animation.SetActive (false);
			dice4_Roll_Animation.SetActive (false);
			dice5_Roll_Animation.SetActive (false);
			dice6_Roll_Animation.SetActive (false);
			break;
			// when got two plays two animation
		case 2:
			dice1_Roll_Animation.SetActive (false);
			dice2_Roll_Animation.SetActive (true);
			dice3_Roll_Animation.SetActive (false);
			dice4_Roll_Animation.SetActive (false);
			dice5_Roll_Animation.SetActive (false);
			dice6_Roll_Animation.SetActive (false);
			break;
			// when got three plays two animation
		case 3:
			dice1_Roll_Animation.SetActive (false);
			dice2_Roll_Animation.SetActive (false);
			dice3_Roll_Animation.SetActive (true);
			dice4_Roll_Animation.SetActive (false);
			dice5_Roll_Animation.SetActive (false);
			dice6_Roll_Animation.SetActive (false);
			break;
			// when got four plays two animation
		case 4:
			dice1_Roll_Animation.SetActive (false);
			dice2_Roll_Animation.SetActive (false);
			dice3_Roll_Animation.SetActive (false);
			dice4_Roll_Animation.SetActive (true);
			dice5_Roll_Animation.SetActive (false);
			dice6_Roll_Animation.SetActive (false);
			break;
			// when got five plays two animation
		case 5:
			dice1_Roll_Animation.SetActive (false);
			dice2_Roll_Animation.SetActive (false);
			dice3_Roll_Animation.SetActive (false);
			dice4_Roll_Animation.SetActive (false);
			dice5_Roll_Animation.SetActive (true);
			dice6_Roll_Animation.SetActive (false);
			break;
			// when got six plays two animation
		case 6:
			dice1_Roll_Animation.SetActive (false);
			dice2_Roll_Animation.SetActive (false);
			dice3_Roll_Animation.SetActive (false);
			dice4_Roll_Animation.SetActive (false);
			dice5_Roll_Animation.SetActive (false);
			dice6_Roll_Animation.SetActive (true);
			break;
		}

		StartCoroutine (PlayersNotInitialized ());

	}
	IEnumerator PlayersNotInitialized()
	{
		yield return new WaitForSeconds (.8f);
		//game start initial position of each player(green and blue)
		switch (playerTurn) 
		{
		case "BLUE":
			//=============condition for border glow=============
			print ("Conditon for the border GLOW");
			print ("blueMovemenBlock.Count-bluePlayerI_Steps:" + (blueMovemenBlock.Count - bluePlayerI_Steps) + "blueMovemenBlock.Count:" + blueMovemenBlock.Count + "bluePlayerI_Steps:" + bluePlayerI_Steps);

			if ((blueMovemenBlock.Count - bluePlayerI_Steps) >= selectDiceNumAnimation && bluePlayerI_Steps > 0 && (blueMovemenBlock.Count > bluePlayerI_Steps)) {
				print ("BluePlayerI border glows");
				BluePlayerI_Border.SetActive (true);
				BluePlayerI_Button.interactable = true;
			} else {
				BluePlayerI_Border.SetActive (false);
				BluePlayerI_Button.interactable = false;
			}

			if ((blueMovemenBlock.Count - bluePlayerII_Steps) >= selectDiceNumAnimation && bluePlayerII_Steps > 0 && (blueMovemenBlock.Count > bluePlayerII_Steps)) {
				print ("BluePlayerII border glows");
				BluePlayerII_Border.SetActive (true);
				BluePlayerII_Button.interactable = true;
			} else {
				BluePlayerII_Border.SetActive (false);
				BluePlayerII_Button.interactable = false;
			}

			if ((blueMovemenBlock.Count - bluePlayerIII_Steps) >= selectDiceNumAnimation && bluePlayerIII_Steps > 0 && (blueMovemenBlock.Count > bluePlayerIII_Steps)) {
				print ("BluePlayerIII border glows");
				BluePlayerIII_Border.SetActive (true);
				BluePlayerIII_Button.interactable = true;
			} else {
				BluePlayerIII_Border.SetActive (false);
				BluePlayerIII_Button.interactable = false;
			}

			if ((blueMovemenBlock.Count - bluePlayerIV_Steps) >= selectDiceNumAnimation && bluePlayerIV_Steps > 0 && (blueMovemenBlock.Count > bluePlayerIV_Steps)) {
				print ("BluePlayerIV border glows");
				BluePlayerIV_Border.SetActive (true);
				BluePlayerIV_Button.interactable = true;
			} else {
				BluePlayerIV_Border.SetActive (false);
				BluePlayerIV_Button.interactable = false;
			}

			//===============Players border glow When Opening===============//

			if (selectDiceNumAnimation == 6 && bluePlayerI_Steps == 0) {
				print ("Border glow of BluePlayerI When Opening");
				BluePlayerI_Border.SetActive (true);
				BluePlayerI_Button.interactable = true;
			}

			if (selectDiceNumAnimation == 6 && bluePlayerII_Steps == 0) {
				print ("Border glow of BluePlayerI When Opening");
				BluePlayerII_Border.SetActive (true);
				BluePlayerII_Button.interactable = true;
			}

			if (selectDiceNumAnimation == 6 && bluePlayerIII_Steps == 0) {
				print ("BluePlayerIII border glows when opening");
				BluePlayerIII_Border.SetActive (true);
				BluePlayerIII_Button.interactable = true;
			}

			if (selectDiceNumAnimation == 6 && bluePlayerIV_Steps == 0) {
				print ("BluePlayerIV border glows when opening");
				BluePlayerIV_Border.SetActive (true);
				BluePlayerIV_Button.interactable = true;
			}

			//=========================PLAYERS DON'T HAVE ANY MOVES , SWITCH TO NEXT PLAYER'S TURN=========================//
			if (!BluePlayerI_Border.activeInHierarchy && !BluePlayerII_Border.activeInHierarchy &&
			   !BluePlayerIII_Border.activeInHierarchy && !BluePlayerIV_Border.activeInHierarchy) 
			{
				BluePlayerI_Button.interactable = false;
				BluePlayerII_Button.interactable = false;
				BluePlayerII_Button.interactable = false;
				BluePlayerIV_Button.interactable = false;

				switch (ExtraSceneController.HowManyPlayers) 
				{
				case 2:
					print ("PLAYERS DON'T HAVE OPTION TO MOVE , SWITCH TO NEXT PLAYER TURN");
					playerTurn = "GREEN";
					InitializeDice ();
				break;

				}
			}
			break;

		case "GREEN":
			//=============condition for border glow=============
			print ("Conditon for the border GLOW");
			print ("greenMovementBlock.Count-greenPlayerI_Steps:" + (greenMovementBlock.Count - greenPlayerI_Steps) + "greenMovementBlock.Count:" + greenMovementBlock.Count + "greenPlayerI_Steps:" + greenPlayerI_Steps);

			if ((greenMovementBlock.Count - greenPlayerI_Steps) >= selectDiceNumAnimation && greenPlayerI_Steps > 0 && (greenMovementBlock.Count > greenPlayerI_Steps)) {
				print ("GreenPlayerI border glows");
				GreenPlayerI_Border.SetActive (true);
				GreenPlayerI_Button.interactable = true;
			} else {
				GreenPlayerI_Border.SetActive (false);
				GreenPlayerI_Button.interactable = false;
			}

			if ((greenMovementBlock.Count - greenPlayerII_Steps) >= selectDiceNumAnimation && greenPlayerII_Steps > 0 && (greenMovementBlock.Count > greenPlayerII_Steps)) {
				print ("GreenPlayerII border glows");
				GreenPlayerII_Border.SetActive (true);
				GreenPlayerII_Button.interactable = true;
			} else {
				GreenPlayerII_Border.SetActive (false);
				GreenPlayerII_Button.interactable = false;
			}

			if ((greenMovementBlock.Count - greenPlayerIII_Steps) >= selectDiceNumAnimation && greenPlayerIII_Steps > 0 && (greenMovementBlock.Count > greenPlayerIII_Steps)) {
				print ("GreenPlayerIII border glows");
				GreenPlayerIII_Border.SetActive (true);
				GreenPlayerIII_Button.interactable = true;
			} else {
				GreenPlayerIII_Border.SetActive (false);
				GreenPlayerIII_Button.interactable = false;
			}

			if ((greenMovementBlock.Count - greenPlayerIV_Steps) >= selectDiceNumAnimation && greenPlayerIV_Steps > 0 && (greenMovementBlock.Count > greenPlayerIV_Steps)) {
				print ("GreenPlayerIV border glows");
				GreenPlayerIV_Border.SetActive (true);
				GreenPlayerIV_Button.interactable = true;
			} else {
				GreenPlayerIV_Border.SetActive (false);
				GreenPlayerIV_Button.interactable = false;
			}

			//===============Players border glow When Opening===============//

			if (selectDiceNumAnimation == 6 && greenPlayerI_Steps == 0) {
				print ("GreenPlayerI border glows when opening");
				GreenPlayerI_Border.SetActive (true);
				GreenPlayerI_Button.interactable = true;
			}

			if (selectDiceNumAnimation == 6 && greenPlayerII_Steps == 0) {
				print ("GreenPlayerII border glows when opening");
				GreenPlayerII_Border.SetActive (true);
				GreenPlayerII_Button.interactable = true;
			}

			if (selectDiceNumAnimation == 6 && greenPlayerIII_Steps == 0) {
				print ("GreenPlayerIII border glows when opening");
				GreenPlayerIII_Border.SetActive (true);
				GreenPlayerIII_Button.interactable = true;
			}

			if (selectDiceNumAnimation == 6 && greenPlayerIV_Steps == 0) {
				print ("GreenPlayerIV border glows when opening");
				GreenPlayerIV_Border.SetActive (true);
				GreenPlayerIV_Button.interactable = true;
			}

			//=========================PLAYERS DON'T HAVE ANY MOVES , SWITCH TO NEXT PLAYER'S TURN=========================//
			if (!GreenPlayerI_Border.activeInHierarchy && !GreenPlayerII_Border.activeInHierarchy &&
				!GreenPlayerIII_Border.activeInHierarchy && !GreenPlayerIV_Border.activeInHierarchy) 
			{
				GreenPlayerI_Button.interactable = false;
				GreenPlayerII_Button.interactable = false;
				GreenPlayerII_Button.interactable = false;
				GreenPlayerIV_Button.interactable = false;

				switch (ExtraSceneController.HowManyPlayers) 
				{
				case 2:
					print ("GREEN PLAYER DON'T HAVE OPTION TO MOVE , SWITCH TO NEXT PLAYER TURN");
					playerTurn = "BLUE";
					InitializeDice ();
					break;
				}
			}
			break;
		}
	}

	//==================Blue player Movement==================//

	public void BluePlayerI_UI()
	{
		BluePlayerI_Border.SetActive (false);
		BluePlayerII_Border.SetActive (false);
		BluePlayerIII_Border.SetActive (false);
		BluePlayerIV_Border.SetActive (false);

		BluePlayerI_Button.interactable = false;
		BluePlayerII_Button.interactable = false;
		BluePlayerIII_Button.interactable = false;
		BluePlayerIV_Button.interactable = false;

		if (playerTurn == "BLUE" && (blueMovemenBlock.Count - bluePlayerI_Steps) > selectDiceNumAnimation) {
			if (bluePlayerI_Steps > 0) {
				Vector3[] bluePlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++) {
					bluePlayer_Path [i] = blueMovemenBlock [bluePlayerI_Steps + i].transform.position;
				}

				bluePlayerI_Steps += selectDiceNumAnimation;

				//============Keeping the Turn to blue Players side============//
				if (selectDiceNumAnimation == 6) {
					playerTurn = "BLUE";	
				} else {
					switch (ExtraSceneController.HowManyPlayers) {
					case 2:
						playerTurn = "GREEN";
						break;
					}
				}

				currentPlayerName = "BLUE PLAYER I";

				if (bluePlayer_Path.Length > 1) {
					iTween.MoveTo (bluePlayerI, iTween.Hash ("path", bluePlayer_Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} else {
					iTween.MoveTo (bluePlayerI, iTween.Hash ("position", bluePlayer_Path [0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
			} else {
				if (selectDiceNumAnimation == 6 && bluePlayerI_Steps == 0) {
					Vector3[] bluePlayer_Path = new Vector3[selectDiceNumAnimation];
					bluePlayer_Path [0] = blueMovemenBlock [bluePlayerI_Steps].transform.position;
					bluePlayerI_Steps += 1;
					playerTurn = "BLUE";
					currentPlayerName = "BLUE PLAYER I";
					iTween.MoveTo (bluePlayerI, iTween.Hash ("position", bluePlayer_Path [0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
			}
		}
		else 
		{
			//condition when player coin is reached successfully in house
			if (playerTurn == "BLUE" && (blueMovemenBlock.Count - bluePlayerI_Steps) == selectDiceNumAnimation) {
				Vector3[] bluePlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++) {
					bluePlayer_Path [i] = blueMovemenBlock [bluePlayerI_Steps + i].transform.position;
				}

				bluePlayerI_Steps += selectDiceNumAnimation;

				playerTurn = "BLUE";

				if (bluePlayer_Path.Length > 1) {
					iTween.MoveTo (bluePlayerI, iTween.Hash ("path", bluePlayer_Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} else {
					iTween.MoveTo (bluePlayerI, iTween.Hash ("position", bluePlayer_Path [0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
				totalBlueInHouse += 1;
				print ("Cool");
				BluePlayerI_Button.enabled = false;
			}
			else 
			{
				print ("You need" + (blueMovemenBlock.Count - bluePlayerI_Steps).ToString () + "To enter in safe house");
				if (bluePlayerII_Steps + bluePlayerIII_Steps + bluePlayerIV_Steps == 0 && selectDiceNumAnimation != 6) 
				{
					switch (ExtraSceneController.HowManyPlayers) 
					{
					case 2:
						playerTurn = "GREEN";
						break;
					}
					InitializeDice();
				}
			}
		}
	}
	public void BlueplayerII_UI()
	{
		BluePlayerI_Border.SetActive (false);
		BluePlayerII_Border.SetActive (false);
		BluePlayerIII_Border.SetActive (false);
		BluePlayerIV_Border.SetActive (false);

		BluePlayerI_Button.interactable = false;
		BluePlayerII_Button.interactable = false;
		BluePlayerIII_Button.interactable = false;
		BluePlayerIV_Button.interactable = false;

		if (playerTurn == "BLUE" && (blueMovemenBlock.Count - bluePlayerII_Steps) > selectDiceNumAnimation)
		{
			if (bluePlayerII_Steps > 0) 
			{
				Vector3[] bluePlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++)
				{
					bluePlayer_Path [i] = blueMovemenBlock [bluePlayerII_Steps + i].transform.position;
				}

				bluePlayerII_Steps += selectDiceNumAnimation;

				//============Keeping the Turn to blue Players side============//
				if (selectDiceNumAnimation == 6) 
				{
					playerTurn = "BLUE";	
				} 
				else 
				{
					switch (ExtraSceneController.HowManyPlayers) 
					{
					case 2:
						playerTurn = "GREEN";
						break;
					}
				}

				currentPlayerName = "BLUE PLAYER II";

				if (bluePlayer_Path.Length > 1) 
				{
					iTween.MoveTo (bluePlayerII, iTween.Hash ("path", bluePlayer_Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (bluePlayerII, iTween.Hash ("position", bluePlayer_Path [0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
			} 
			else 
			{
				if (selectDiceNumAnimation == 6 && bluePlayerII_Steps == 0)
				{
					Vector3[] bluePlayer_Path = new Vector3[selectDiceNumAnimation];
					bluePlayer_Path [0] = blueMovemenBlock [bluePlayerII_Steps].transform.position;
					bluePlayerII_Steps += 1;
					playerTurn = "BLUE";
					currentPlayerName = "BLUE PLAYER II";
					iTween.MoveTo (bluePlayerII, iTween.Hash ("position", bluePlayer_Path [0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
			}
		}
		else 
		{
			//condition when player coin is reached successfully in house
			if (playerTurn == "BLUE" && (blueMovemenBlock.Count - bluePlayerII_Steps) == selectDiceNumAnimation) 
			{
				Vector3[] bluePlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++)
				{
					bluePlayer_Path [i] = blueMovemenBlock [bluePlayerII_Steps + i].transform.position;
				}

				bluePlayerII_Steps += selectDiceNumAnimation;

				playerTurn = "BLUE";

				if (bluePlayer_Path.Length > 1) 
				{
					iTween.MoveTo (bluePlayerII, iTween.Hash ("path", bluePlayer_Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (bluePlayerII, iTween.Hash ("position", bluePlayer_Path [0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
				totalBlueInHouse += 1;
				print ("Cool");
				BluePlayerII_Button.enabled = false;
			}
			else 
			{
				print ("You need" + (blueMovemenBlock.Count - bluePlayerII_Steps).ToString () + "To enter in safe house");
				if (bluePlayerI_Steps + bluePlayerIII_Steps + bluePlayerIV_Steps == 0 && selectDiceNumAnimation != 6) 
				{
					switch (ExtraSceneController.HowManyPlayers) 
					{
					case 2:
						playerTurn = "GREEN";
						break;
					}
					InitializeDice();
				}
			}
		}
	}
	public  void BluePlayerIII_UI()
	{
		BluePlayerI_Border.SetActive (false);
		BluePlayerII_Border.SetActive (false);
		BluePlayerIII_Border.SetActive (false);
		BluePlayerIV_Border.SetActive (false);

		BluePlayerI_Button.interactable = false;
		BluePlayerII_Button.interactable = false;
		BluePlayerIII_Button.interactable = false;
		BluePlayerIV_Button.interactable = false;

		if (playerTurn == "BLUE" && (blueMovemenBlock.Count - bluePlayerIII_Steps) > selectDiceNumAnimation) 
		{
			if (bluePlayerIII_Steps > 0) 
			{
				Vector3[] bluePlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++)
				{
					bluePlayer_Path [i] = blueMovemenBlock [bluePlayerIII_Steps + i].transform.position;
				}

				bluePlayerIII_Steps += selectDiceNumAnimation;

				//============Keeping the Turn to blue Players side============//
				if (selectDiceNumAnimation == 6) 
				{
					playerTurn = "BLUE";	
				} 
				else 
				{
					switch (ExtraSceneController.HowManyPlayers) 
					{
					case 2:
						playerTurn = "GREEN";
						break;
					}
				}

				currentPlayerName = "BLUE PLAYER III";

				if (bluePlayer_Path.Length > 1) 
				{
					iTween.MoveTo (bluePlayerIII, iTween.Hash ("path", bluePlayer_Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (bluePlayerIII, iTween.Hash ("position", bluePlayer_Path [0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
			} 
			else 
			{
				if (selectDiceNumAnimation == 6 && bluePlayerIII_Steps == 0)
				{
					Vector3[] bluePlayer_Path = new Vector3[selectDiceNumAnimation];
					bluePlayer_Path [0] = blueMovemenBlock [bluePlayerIII_Steps].transform.position;
					bluePlayerIII_Steps += 1;
					playerTurn = "BLUE";
					currentPlayerName = "BLUE PLAYER III";
					iTween.MoveTo (bluePlayerIII, iTween.Hash ("position", bluePlayer_Path [0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
			}
		}
		else 
		{
			//condition when player coin is reached successfully in house
			if (playerTurn == "BLUE" && (blueMovemenBlock.Count - bluePlayerIII_Steps) == selectDiceNumAnimation) 
			{
				Vector3[] bluePlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++)
				{
					bluePlayer_Path [i] = blueMovemenBlock [bluePlayerIII_Steps + i].transform.position;
				}

				bluePlayerIII_Steps += selectDiceNumAnimation;

				playerTurn = "BLUE";

				if (bluePlayer_Path.Length > 1) 
				{
					iTween.MoveTo (bluePlayerIII, iTween.Hash ("path", bluePlayer_Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (bluePlayerIII, iTween.Hash ("position", bluePlayer_Path [0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
				totalBlueInHouse += 1;
				print ("Cool");
				BluePlayerIII_Button.enabled = false;
			}
			else 
			{
				print ("You need" + (blueMovemenBlock.Count - bluePlayerIII_Steps).ToString () + "To enter in safe house");
				if (bluePlayerI_Steps + bluePlayerII_Steps + bluePlayerIV_Steps == 0 && selectDiceNumAnimation != 6) 
				{
					switch (ExtraSceneController.HowManyPlayers) 
					{
					case 2:
						playerTurn = "GREEN";
						break;
					}
					InitializeDice();
				}
			}
		}
	}
	public void BluePlayerIV_UI()
	{
		BluePlayerI_Border.SetActive (false);
		BluePlayerII_Border.SetActive (false);
		BluePlayerIII_Border.SetActive (false);
		BluePlayerIV_Border.SetActive (false);

		BluePlayerI_Button.interactable = false;
		BluePlayerII_Button.interactable = false;
		BluePlayerIII_Button.interactable = false;
		BluePlayerIV_Button.interactable = false;

		if (playerTurn == "BLUE" && (blueMovemenBlock.Count - bluePlayerIV_Steps) > selectDiceNumAnimation) 
		{
			if (bluePlayerIV_Steps > 0) 
			{
				Vector3[] bluePlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++)
				{
					bluePlayer_Path [i] = blueMovemenBlock [bluePlayerIV_Steps + i].transform.position;
				}

				bluePlayerIV_Steps += selectDiceNumAnimation;

				//============Keeping the Turn to blue Players side============//
				if (selectDiceNumAnimation == 6) 
				{
					playerTurn = "BLUE";	
				} 
				else 
				{
					switch (ExtraSceneController.HowManyPlayers) 
					{
					case 2:
						playerTurn = "GREEN";
						break;
					}
				}

				currentPlayerName = "BLUE PLAYER IV";

				if (bluePlayer_Path.Length > 1) 
				{
					iTween.MoveTo (bluePlayerIV, iTween.Hash ("path", bluePlayer_Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (bluePlayerIV, iTween.Hash ("position", bluePlayer_Path [0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
			} 
			else 
			{
				if (selectDiceNumAnimation == 6 && bluePlayerIV_Steps == 0)
				{
					Vector3[] bluePlayer_Path = new Vector3[selectDiceNumAnimation];
					bluePlayer_Path [0] = blueMovemenBlock [bluePlayerIV_Steps].transform.position;
					bluePlayerIV_Steps += 1;
					playerTurn = "BLUE";
					currentPlayerName = "BLUE PLAYER IV";
					iTween.MoveTo (bluePlayerIV, iTween.Hash ("position", bluePlayer_Path [0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
			}
		}
		else 
		{
			//condition when player coin is reached successfully in house
			if (playerTurn == "BLUE" && (blueMovemenBlock.Count - bluePlayerIV_Steps) == selectDiceNumAnimation) 
			{
				Vector3[] bluePlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++)
				{
					bluePlayer_Path [i] = blueMovemenBlock [bluePlayerIV_Steps + i].transform.position;
				}

				bluePlayerIV_Steps += selectDiceNumAnimation;

				playerTurn = "BLUE";

				if (bluePlayer_Path.Length > 1) 
				{
					iTween.MoveTo (bluePlayerIV, iTween.Hash ("path", bluePlayer_Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (bluePlayerIV, iTween.Hash ("position", bluePlayer_Path [0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
				totalBlueInHouse += 1;
				print ("Cool");
				BluePlayerIV_Button.enabled = false;
			}
			else 
			{
				print ("You need" + (blueMovemenBlock.Count - bluePlayerIV_Steps).ToString () + "To enter in safe house");
				if (bluePlayerI_Steps + bluePlayerII_Steps + bluePlayerIII_Steps == 0 && selectDiceNumAnimation != 6) 
				{
					switch (ExtraSceneController.HowManyPlayers) 
					{
					case 2:
						playerTurn = "GREEN";
						break;
					}
					InitializeDice();
				}
			}
		}
	}

	//==================Green player Movement==================//

	public void GreenPlayerI_UI()
	{
		GreenPlayerI_Border.SetActive (false);
		GreenPlayerII_Border.SetActive (false);
		GreenPlayerIII_Border.SetActive (false);
		GreenPlayerIV_Border.SetActive (false);

		GreenPlayerI_Button.interactable = false;
		GreenPlayerII_Button.interactable = false;
		GreenPlayerIII_Button.interactable = false;
		GreenPlayerIV_Button.interactable = false;

		if (playerTurn == "GREEN" && (greenMovementBlock.Count - greenPlayerI_Steps) > selectDiceNumAnimation) 
		{
			if (greenPlayerI_Steps > 0) 
			{
				Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++) 
				{
					greenPlayer_Path [i] = greenMovementBlock [greenPlayerI_Steps + i].transform.position;
				}

				greenPlayerI_Steps += selectDiceNumAnimation;

				//============Keeping the Turn to blue Players side============//
				if (selectDiceNumAnimation == 6) 
				{
					playerTurn = "GREEN";	
				}
				else 
				{
					switch (ExtraSceneController.HowManyPlayers) 
					{
					case 2:
						playerTurn = "BLUE";
						break;
					}
				}

				currentPlayerName = "GREEN PLAYER I";

				if (greenPlayer_Path.Length > 1) 
				{
					iTween.MoveTo (greenPlayerI, iTween.Hash ("path", greenPlayer_Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
				else
				{
					iTween.MoveTo (greenPlayerI, iTween.Hash ("position", greenPlayer_Path [0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
			} 
			else 
			{
				if (selectDiceNumAnimation == 6 && greenPlayerI_Steps == 0) 
				{
					Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];
					greenPlayer_Path [0] = greenMovementBlock [greenPlayerI_Steps].transform.position;
					greenPlayerI_Steps += 1;
					playerTurn = "GREEN";
					currentPlayerName = "GREEN PLAYER I";
					iTween.MoveTo (greenPlayerI, iTween.Hash ("position", greenPlayer_Path [0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
			}
		}
		else 
		{
			//condition when player coin is reached successfully in house
											
			if (playerTurn == "GREEN" && (greenMovementBlock.Count - greenPlayerI_Steps) == selectDiceNumAnimation) 
			{
				Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++)
				{
					greenPlayer_Path [i] = greenMovementBlock [greenPlayerI_Steps + i].transform.position;
				}

				greenPlayerI_Steps += selectDiceNumAnimation;

				playerTurn = "BLUE";

				if (greenPlayer_Path.Length > 1) 
				{
					iTween.MoveTo (greenPlayerI, iTween.Hash ("path", greenPlayer_Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (greenPlayerI, iTween.Hash ("position", greenPlayer_Path [0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
				totalGreenInHouse += 1;
				print ("Cool");
				GreenPlayerI_Button.enabled = false;
			}
			else 
			{
				print ("You need" + (greenMovementBlock.Count - greenPlayerI_Steps).ToString () + "To enter in safe house");
				if (greenPlayerII_Steps + greenPlayerIII_Steps + greenPlayerIV_Steps == 0 && selectDiceNumAnimation != 6) 
				{
					switch (ExtraSceneController.HowManyPlayers) 
					{
					case 2:
						playerTurn = "BLUE";
						break;
					}
					InitializeDice();
				}
			}
		}
	}
	public void GreenplayerII_UI()
	{
		GreenPlayerI_Border.SetActive (false);
		GreenPlayerII_Border.SetActive (false);
		GreenPlayerIII_Border.SetActive (false);
		GreenPlayerIV_Border.SetActive (false);

		GreenPlayerI_Button.interactable = false;
		GreenPlayerII_Button.interactable = false;
		GreenPlayerIII_Button.interactable = false;
		GreenPlayerIV_Button.interactable = false;

		if (playerTurn == "GREEN" && (greenMovementBlock.Count - greenPlayerII_Steps) > selectDiceNumAnimation) 
		{
			if (greenPlayerII_Steps > 0) 
			{
				Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++) 
				{
					greenPlayer_Path [i] = greenMovementBlock [greenPlayerII_Steps + i].transform.position;
				}

				greenPlayerII_Steps += selectDiceNumAnimation;

				//============Keeping the Turn to blue Players side============//
				if (selectDiceNumAnimation == 6) 
				{
					playerTurn = "GREEN";	
				}
				else 
				{
					switch (ExtraSceneController.HowManyPlayers) 
					{
					case 2:
						playerTurn = "BLUE";
						break;
					}
				}

				currentPlayerName = "GREEN PLAYER II";

				if (greenPlayer_Path.Length > 1) 
				{
					iTween.MoveTo (greenPlayerII, iTween.Hash ("path", greenPlayer_Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
				else
				{
					iTween.MoveTo (greenPlayerII, iTween.Hash ("position", greenPlayer_Path [0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
			} 
			else 
			{
				if (selectDiceNumAnimation == 6 && greenPlayerII_Steps == 0) 
				{
					Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];
					greenPlayer_Path [0] = greenMovementBlock [greenPlayerII_Steps].transform.position;
					greenPlayerII_Steps += 1;
					playerTurn = "GREEN";
					currentPlayerName = "GREEN PLAYER II";
					iTween.MoveTo (greenPlayerII, iTween.Hash ("position", greenPlayer_Path [0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
			}
		}
		else 
		{
			//condition when player coin is reached successfully in house

			if (playerTurn == "GREEN" && (greenMovementBlock.Count - greenPlayerII_Steps) == selectDiceNumAnimation) 
			{
				Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++)
				{
					greenPlayer_Path [i] = greenMovementBlock [greenPlayerII_Steps + i].transform.position;
				}

				greenPlayerII_Steps += selectDiceNumAnimation;

				playerTurn = "BLUE";

				if (greenPlayer_Path.Length > 1) 
				{
					iTween.MoveTo (greenPlayerII, iTween.Hash ("path", greenPlayer_Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (greenPlayerII, iTween.Hash ("position", greenPlayer_Path [0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
				totalGreenInHouse += 1;
				print ("Cool");
				GreenPlayerII_Button.enabled = false;
			}
			else 
			{
				print ("You need" + (greenMovementBlock.Count - greenPlayerII_Steps).ToString () + "To enter in safe house");
				if (greenPlayerI_Steps + greenPlayerIII_Steps + greenPlayerIV_Steps == 0 && selectDiceNumAnimation != 6) 
				{
					switch (ExtraSceneController.HowManyPlayers) 
					{
					case 2:
						playerTurn = "BLUE";
						break;
					}
					InitializeDice();
				}
			}
		}
	}
	public  void GreenPlayerIII_UI()
	{
		GreenPlayerI_Border.SetActive (false);
		GreenPlayerII_Border.SetActive (false);
		GreenPlayerIII_Border.SetActive (false);
		GreenPlayerIV_Border.SetActive (false);

		GreenPlayerI_Button.interactable = false;
		GreenPlayerII_Button.interactable = false;
		GreenPlayerIII_Button.interactable = false;
		GreenPlayerIV_Button.interactable = false;

		if (playerTurn == "GREEN" && (greenMovementBlock.Count - greenPlayerIV_Steps) > selectDiceNumAnimation) 
		{
			if (greenPlayerIV_Steps > 0) 
			{
				Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++) 
				{
					greenPlayer_Path [i] = greenMovementBlock [greenPlayerIV_Steps + i].transform.position;
				}

				greenPlayerIV_Steps += selectDiceNumAnimation;

				//============Keeping the Turn to blue Players side============//
				if (selectDiceNumAnimation == 6) 
				{
					playerTurn = "GREEN";	
				}
				else 
				{
					switch (ExtraSceneController.HowManyPlayers) 
					{
					case 2:
						playerTurn = "BLUE";
						break;
					}
				}

				currentPlayerName = "GREEN PLAYER IV";

				if (greenPlayer_Path.Length > 1) 
				{
					iTween.MoveTo (greenPlayerIV, iTween.Hash ("path", greenPlayer_Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
				else
				{
					iTween.MoveTo (greenPlayerIV, iTween.Hash ("position", greenPlayer_Path [0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
			} 
			else 
			{
				if (selectDiceNumAnimation == 6 && greenPlayerIV_Steps == 0) 
				{
					Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];
					greenPlayer_Path [0] = greenMovementBlock [greenPlayerIV_Steps].transform.position;
					greenPlayerIV_Steps += 1;
					playerTurn = "GREEN";
					currentPlayerName = "GREEN PLAYER IV";
					iTween.MoveTo (greenPlayerIV, iTween.Hash ("position", greenPlayer_Path [0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
			}
		}
		else 
		{
			//condition when player coin is reached successfully in house

			if (playerTurn == "GREEN" && (greenMovementBlock.Count - greenPlayerIV_Steps) == selectDiceNumAnimation) 
			{
				Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++)
				{
					greenPlayer_Path [i] = greenMovementBlock [greenPlayerIV_Steps + i].transform.position;
				}

				greenPlayerIV_Steps += selectDiceNumAnimation;

				playerTurn = "BLUE";

				if (greenPlayer_Path.Length > 1) 
				{
					iTween.MoveTo (greenPlayerIV, iTween.Hash ("path", greenPlayer_Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (greenPlayerIV, iTween.Hash ("position", greenPlayer_Path [0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
				totalGreenInHouse += 1;
				print ("Cool");
				GreenPlayerIV_Button.enabled = false;
			}
			else 
			{
				print ("You need" + (greenMovementBlock.Count - greenPlayerIV_Steps).ToString () + "To enter in safe house");
				if (greenPlayerI_Steps + greenPlayerII_Steps + greenPlayerIII_Steps == 0 && selectDiceNumAnimation != 6) 
				{
					switch (ExtraSceneController.HowManyPlayers) 
					{
					case 2:
						playerTurn = "BLUE";
						break;
					}
					InitializeDice();
				}
			}
		}
	}
	public void GreenPlayerIV_UI()
	{
		GreenPlayerI_Border.SetActive (false);
		GreenPlayerII_Border.SetActive (false);
		GreenPlayerIII_Border.SetActive (false);
		GreenPlayerIV_Border.SetActive (false);

		GreenPlayerI_Button.interactable = false;
		GreenPlayerII_Button.interactable = false;
		GreenPlayerIII_Button.interactable = false;
		GreenPlayerIV_Button.interactable = false;

		if (playerTurn == "GREEN" && (greenMovementBlock.Count - greenPlayerIII_Steps) > selectDiceNumAnimation) 
		{
			if (greenPlayerIII_Steps > 0) 
			{
				Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++) 
				{
					greenPlayer_Path [i] = greenMovementBlock [greenPlayerIII_Steps + i].transform.position;
				}

				greenPlayerIII_Steps += selectDiceNumAnimation;

				//============Keeping the Turn to blue Players side============//
				if (selectDiceNumAnimation == 6) 
				{
					playerTurn = "GREEN";	
				}
				else 
				{
					switch (ExtraSceneController.HowManyPlayers) 
					{
					case 2:
						playerTurn = "BLUE";
						break;
					}
				}

				currentPlayerName = "GREEN PLAYER III";

				if (greenPlayer_Path.Length > 1) 
				{
					iTween.MoveTo (greenPlayerIII, iTween.Hash ("path", greenPlayer_Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
				else
				{
					iTween.MoveTo (greenPlayerIII, iTween.Hash ("position", greenPlayer_Path [0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
			} 
			else 
			{
				if (selectDiceNumAnimation == 6 && greenPlayerIII_Steps == 0) 
				{
					Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];
					greenPlayer_Path [0] = greenMovementBlock [greenPlayerIII_Steps].transform.position;
					greenPlayerIII_Steps += 1;
					playerTurn = "GREEN";
					currentPlayerName = "GREEN PLAYER III";
					iTween.MoveTo (greenPlayerIII, iTween.Hash ("position", greenPlayer_Path [0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
			}
		}
		else 
		{
			//condition when player coin is reached successfully in house

			if (playerTurn == "GREEN" && (greenMovementBlock.Count - greenPlayerIII_Steps) == selectDiceNumAnimation) 
			{
				Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];

				for (int i = 0; i < selectDiceNumAnimation; i++)
				{
					greenPlayer_Path [i] = greenMovementBlock [greenPlayerIII_Steps + i].transform.position;
				}

				greenPlayerIII_Steps += selectDiceNumAnimation;

				playerTurn = "BLUE";

				if (greenPlayer_Path.Length > 1) 
				{
					iTween.MoveTo (greenPlayerIII, iTween.Hash ("path", greenPlayer_Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				} 
				else 
				{
					iTween.MoveTo (greenPlayerIII, iTween.Hash ("position", greenPlayer_Path [0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
				}
				totalGreenInHouse += 1;
				print ("Cool");
				GreenPlayerIII_Button.enabled = false;
			}
			else 
			{
				print ("You need" + (greenMovementBlock.Count - greenPlayerIII_Steps).ToString () + "To enter in safe house");
				if (greenPlayerI_Steps + greenPlayerII_Steps + greenPlayerIV_Steps == 0 && selectDiceNumAnimation != 6) 
				{
					switch (ExtraSceneController.HowManyPlayers) 
					{
					case 2:
						playerTurn = "BLUE";
						break;
					}
					InitializeDice();
				}
			}
		}
	}


	// Use this for initialization
	void Start () 
	{
		QualitySettings.vSyncCount = 1;
		Application.targetFrameRate = 30;

		randomNo = new System.Random ();

		dice1_Roll_Animation.SetActive (false);
		dice2_Roll_Animation.SetActive (false);
		dice3_Roll_Animation.SetActive (false);
		dice4_Roll_Animation.SetActive (false);
		dice5_Roll_Animation.SetActive (false);
		dice6_Roll_Animation.SetActive (false);

		//Player initial positions...........
		BluePlayerIII_Pos=bluePlayerI.transform.position;
		BluePlayerIII_Pos = bluePlayerII.transform.position;
		BluePlayerIII_Pos = bluePlayerIII.transform.position;
		BluePlayerIV_Pos = bluePlayerIV.transform.position;

		GreenPlayerI_Pos = greenPlayerI.transform.position;
		GreenPlayerII_Pos = greenPlayerII.transform.position;
		GreenPlayerIII_Pos = greenPlayerIII.transform.position;
		GreenPlayerIV_Pos = greenPlayerIV.transform.position;

		BluePlayerI_Border.SetActive (false);
		BluePlayerII_Border.SetActive (false);
		BluePlayerIII_Border.SetActive (false);
		BluePlayerIV_Border.SetActive (false);

		GreenPlayerI_Border.SetActive (false);
		GreenPlayerII_Border.SetActive (false);
		GreenPlayerIII_Border.SetActive (false);
		GreenPlayerIV_Border.SetActive (false);

		//Initializing Players
		switch (ExtraSceneController.HowManyPlayers) 
		{
		case 2:
			print ("Two Players");
			playerTurn = "BLUE";
			BlueFrame.SetActive (true);
			GreenFrame.SetActive (false);
			break;
		}
	}
	void Update()
	{
		print ("PlayerTurn:"+playerTurn);
	}
}
