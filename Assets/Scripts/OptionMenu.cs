using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenu : MonoBehaviour
{
    public GameObject mainMenu;

    public void MainMenu()
    {
        this.mainMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
