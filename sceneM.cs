using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneM : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.lockCursor = false;
		Cursor.visible = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void QuitGame(int q)
	{
		Application.Quit ();
	}
	public void StartGame(int s)
	{
		SceneManager.LoadScene ("levl1");
	} 
}
