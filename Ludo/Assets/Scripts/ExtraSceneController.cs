using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ExtraSceneController : MonoBehaviour 
{
	public static int HowManyPlayers;
	public void LoadExtraScene()
	{
		SceneManager.LoadScene ("ExtraScenes");
	}
	public void LoadProfileScene()
	{
		SceneManager.LoadScene ("ProfileScene");
	}
	public void WalletScene()
	{
		SceneManager.LoadScene ("WalletScene");
	}
	public void  LoadTransactionScene()
	{
		SceneManager.LoadScene ("TransactionScene");
	}
	public void SettingScene()
	{
		SceneManager.LoadScene ("SettingScene");
	}
	public void Logout()
	{
		SceneManager.LoadScene ("GameMenu");
	}
	public void SaveuserDataAndLoadExtraScene()
	{
		SceneManager.LoadScene ("ExtraScenes");
	}	
	public void LoadExtraSceneFromSetting()
	{
		SceneManager.LoadScene ("ExtraScenes");
	}
	public void LoadExtraScenefromtransaction()
	{
		SceneManager.LoadScene ("ExtraScenes");
	}
	public void LoadExtraSceneFromWalletScene()
	{
		SceneManager.LoadScene ("ExtraScenes");
	}
	public void LoadMainGameSceneFromExtraScene()
	{
		SceneManager.LoadScene ("GameMenu");
	}
	public void LoadPlayerVSAIScene()
	{
		HowManyPlayers = 2;
		SceneManager.LoadScene ("PlayerVSAI");
	}
}
