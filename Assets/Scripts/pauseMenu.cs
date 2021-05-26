using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Unpause()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
