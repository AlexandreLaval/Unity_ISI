using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System;

public class EndMenu : MonoBehaviour
{
    public Text txtScore;
    public Text txtCongrat;
    public Text txtHighScore;
    public Text txtDate;
    public Text txtMeilleurScore;

    void Start()
    {
        txtCongrat.text = "";

        string path = Directory.GetCurrentDirectory() + @"\scores.txt";
        Dictionary<int, string> lstScore = new Dictionary<int, string>();
        
        int result = 0;

        if (File.Exists(path)){

            StreamReader rd = new StreamReader(path);
            string line;

            while ((line = rd.ReadLine()) != null)
            { 

                string[] resultat = line.Split('-');
                //on met le score dans la datagridview  

                try
                {
                    lstScore.Add(Convert.ToInt32(resultat[0]), resultat[1]);
                }catch(Exception ex)
                {
                    lstScore.Remove(Convert.ToInt32(resultat[0]));
                    lstScore.Add(Convert.ToInt32(resultat[0]), resultat[1]);
                }

                result = Convert.ToInt32(resultat[0]);
            }
            rd.Close();
        }

        txtScore.text = Convert.ToString(result);

        //parcours du dictionnaire pour trouver le meilleur score 
        int bestScore = 0;
        foreach(KeyValuePair<int, string> elemCourant in lstScore)
        {
            if (elemCourant.Key > bestScore)
                bestScore = elemCourant.Key;
        }

        if (result >= bestScore) {
            txtCongrat.text = "Félicitations ! \n Tu as battu ton record !";
            txtHighScore.text = "";
            txtDate.text = "";
            txtMeilleurScore.text = "";
        }
        else
        {
            txtHighScore.text = Convert.ToString(bestScore);
            txtDate.text = lstScore[bestScore];
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene(sceneName: "Menu");
    }
}
