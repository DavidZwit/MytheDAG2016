using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NavigateMenu : MonoBehaviour
{
    private GameObject buttonMenu;
    private GameObject optionMenu;
    private GameObject creditScreen;

    void Start()
    {
        buttonMenu = GameObject.Find("ButtonMenu");
        optionMenu = GameObject.Find("OptionMenu");
        creditScreen = GameObject.Find("CreditScreen");

        optionMenu.SetActive(false);
        creditScreen.SetActive(false);
    }

    //Open the option Menu
    public void OpenOptions()
    {
        buttonMenu.SetActive(false);
        creditScreen.SetActive(false);
        optionMenu.SetActive(true);
    }

    //Return to the mainMenu
    public void ReturnToMenu()
    {
        buttonMenu.SetActive(true);
        creditScreen.SetActive(false);
        optionMenu.SetActive(false);
    }

    //Load the mainGame
    public void PlayGame()
    {
        //Laat hier nog een "Loading" plaatje zien
        SceneManager.LoadScene(1);
    }

    //Load the mainmenu
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowCredits()
    {
        buttonMenu.SetActive(false);
        creditScreen.SetActive(true);
        optionMenu.SetActive(false);
    }

    //Quits the game
    public void QuitGame()
    {
        Application.Quit();
    }
}