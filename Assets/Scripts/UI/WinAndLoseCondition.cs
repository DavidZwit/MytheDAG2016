using UnityEngine;
using System.Collections;

public class WinAndLoseCondition : MonoBehaviour {

	[SerializeField] private GameObject win;
	[SerializeField] private GameObject lose;
	[SerializeField] private GameObject restart;
	[SerializeField] private GameObject returnMenu;
	[SerializeField] private GameObject cam;

	public bool isEndCondition = false;

	MouseOrbit mouseOr;

	void Start()
	{
		mouseOr = cam.GetComponent<MouseOrbit>();
		mouseOr.enabled = true;
		lose.SetActive (false);
		win.SetActive (false);
		returnMenu.SetActive (false);
		restart.SetActive (false);
	}

	public void Win()
	{
		isEndCondition = true;
			lose.SetActive (false);
			win.SetActive (true);
			Cursor.visible = true;
			mouseOr.enabled = false;
			returnMenu.SetActive (true);
			restart.SetActive (true);
			Time.timeScale = 0;
	}

	public void Lose()
	{
		isEndCondition = true;
			win.SetActive (false);
			lose.SetActive (true);
			Cursor.visible = true;
			mouseOr.enabled = false;
			returnMenu.SetActive (true);
			restart.SetActive (true);
			Time.timeScale = 0;
	}

}
