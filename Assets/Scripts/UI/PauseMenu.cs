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
	[SerializeField] private GameObject hitFXPanel;

	MouseOrbit mouseOr;
	WinAndLoseCondition condition;

	private bool isPaused = false;

	private GameObject pausedMenu;

	void Start()
	{
		condition = GameObject.Find ("WinAndLoseCondition").GetComponent<WinAndLoseCondition> ();
		mouseOr = cam.GetComponent<MouseOrbit>();
		mouseOr.enabled = true;
	}

	// Update is called once per frame
	void Update () 
	{
		ThePausedMenu ();
	}

	public void ThePausedMenu()
	{
		
		if (isPaused)
		{
			menuLayout.SetActive (true);
			Cursor.visible = true;
			Time.timeScale = 0;
			mouseOr.enabled = false;
			hitFXPanel.SetActive (false);
		} 
		else if(!isPaused)
		{
			menuLayout.SetActive (false);
		}

		if(Input.GetKeyDown(KeyCode.Escape) && !condition.isEndCondition)
		{
			isPaused = !isPaused;
			Time.timeScale = 1;
			Cursor.visible = false;
			mouseOr.enabled = true;
			hitFXPanel.SetActive (true);
		}
	}


	public void BackToMenu()
	{
		SceneManager.LoadScene ("StartMenu");
	}

	public void Restart()
	{
		SceneManager.LoadScene ("MainScene");
		Time.timeScale = 1;
		isPaused = false;
	}

	public void Resume()
	{
		isPaused = false;
		Cursor.visible = false;
		mouseOr.enabled = true;
		hitFXPanel.SetActive (true);
		Time.timeScale = 1;
	}
}
