using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerPlayerSelect : MonoBehaviour {

	public void OnPlayer1Click() {
		SceneManager.LoadScene ("Gauntlet", LoadSceneMode.Single);
	}

	public void OnPlayer2Click() {
		SceneManager.LoadScene ("Gauntlet" , LoadSceneMode.Single);
	}

	public void OnExitToStartClick() {
		SceneManager.LoadScene ("StartScreen", LoadSceneMode.Single);
	}
}
