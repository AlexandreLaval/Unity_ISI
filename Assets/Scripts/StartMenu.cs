using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject optionMenu;


    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void OptionMenu()
    {
        this.optionMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
