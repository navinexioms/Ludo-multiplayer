using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ExtraSceneController : MonoBehaviour 
{
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
	// Use this for initialization

}
