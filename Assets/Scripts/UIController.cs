using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class UIController : MonoBehaviour
{
    public Text t_chrono;
    public Text t_score;
    public Text t_level;
    public Slider playerlifeBar;

    public Slider baselifeBar1;
    public Slider baselifeBar2;
    public Slider baselifeBar3;

    public GameObject Base_1;
    public GameObject Base_2;
    public GameObject Base_3;

    public GameObject pauseMenu;

    float f_score;
    float f_timer;
    int i_level;

    void Start()
    {
        f_timer = 0.0f;
        f_score = 0.0f;
        i_level = 1;

    }

    public void showMenu()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            this.pauseMenu.SetActive(true);
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            this.pauseMenu.SetActive(false);
        }
    }
    void hideMenu()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            showMenu();
        }
        //temps
        float f_minutes = Mathf.FloorToInt(f_timer / 60);
        float f_seconds = Mathf.FloorToInt(f_timer % 60);

        t_chrono.text = string.Format("{0:00}:{1:00}", f_minutes, f_seconds);

        f_timer += Time.deltaTime;
        t_score.text = f_score.ToString();
        t_level.text = i_level.ToString();

        playerlifeBar.value = FindObjectOfType<spacialShipController>().getLife();
        setBaseLife();
        hideIfBaseDestroyed();
    }

    void setBaseLife()
    {
        if(Base_1.gameObject)
            baselifeBar1.value = Base_1.gameObject.GetComponent<baseController>().f_baseLife / 100;
        if (Base_2.gameObject)
            baselifeBar2.value = Base_2.gameObject.GetComponent<baseController>().f_baseLife / 100;
        if (Base_3.gameObject)
            baselifeBar3.value = Base_3.gameObject.GetComponent<baseController>().f_baseLife / 100;
    }

    void hideIfBaseDestroyed()
    {
        if(baselifeBar1.value <= 0)
        {
            baselifeBar1.gameObject.SetActive(false);
        }
        if(baselifeBar2.value <= 0)
        {
            baselifeBar2.gameObject.SetActive(false);
        }
        if(baselifeBar3.value <= 0)
        {
            baselifeBar3.gameObject.SetActive(false);
        }
    }

    public void setScore(float score)
    {
        f_score += score;
    }

    public float getScore()
    {
        return f_score;
    }

    public void upLevel()
    {
        i_level++;
    }
}
