using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerSplashScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnStartClick(){
		SceneManager.LoadScene("PlayerSelectScene", LoadSceneMode.Single);
	}

	public void OnExitClick() {
		Application.Quit ();
	}
}
