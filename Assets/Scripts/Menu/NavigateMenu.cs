using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NavigateMenu : MonoBehaviour
{
    private GameObject buttonMenu;
    private GameObject optionMenu;

    void Start()
    {
        buttonMenu = GameObject.Find("ButtonMenu");
        optionMenu = GameObject.Find("OptionMenu");

        optionMenu.SetActive(false);
    }

    //Open the option Menu
    public void OpenOptions()
    {
        buttonMenu.SetActive(false);
        optionMenu.SetActive(true);
    }

    //Return to the mainMenu
    public void ReturnToMenu()
    {
        buttonMenu.SetActive(true);
        optionMenu.SetActive(false);
    }

    //Load the mainGame
    public void PlayGame()
    {
        //Laat hier nog een "Loading" plaatje zien
        SceneManager.LoadScene(1);
    }

    //Quits the game
    public void QuitGame()
    {
        Application.Quit();
    }
}