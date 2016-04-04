using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour 
{
	[SerializeField] private GameObject resume;
	[SerializeField] private GameObject restart;
	[SerializeField] private GameObject mainmenu;
	[SerializeField] private GameObject menuLayout;
	[SerializeField] private GameObject cam;

	MouseOrbit mouseOr;

	private bool isPaused = false;

	private GameObject pausedMenu;

	void Start()
	{
		mouseOr = cam.GetComponent<MouseOrbit>();
		mouseOr.enabled = true;
		pausedMenu.SetActive (false);
	}

	// Update is called once per frame
	void Update () 
	{
		ThePausedMenu ();
	}

	public void ThePausedMenu()
	{
		if (isPaused == true)
		{
			menuLayout.SetActive (true);
			Cursor.visible = true;
			Time.timeScale = 0;
			mouseOr.enabled = false;
		} 
		else if(!isPaused)
		{
			menuLayout.SetActive (false);
		}

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			isPaused = !isPaused;
			Time.timeScale = 1;
			Cursor.visible = false;
			mouseOr.enabled = true;
		}
	}


	public void BackToMenu()
	{
		SceneManager.LoadScene ("StartMenu");
	}

	public void Restart()
	{
		SceneManager.LoadScene ("MainScene");
		//Application.runInBackground = true;
		Time.timeScale = 1;
		isPaused = false;
	}

	public void Resume()
	{
		isPaused = false;
		Cursor.visible = false;
		mouseOr.enabled = true;
		Time.timeScale = 1;
	}
}
