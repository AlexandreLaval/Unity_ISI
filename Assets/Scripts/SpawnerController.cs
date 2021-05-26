using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject[] asteroides; //contient le prefab de mon asteroide
    public Camera cam;
    float f_coordY; //position random entre les deux extrémités X de la caméra
    int i_nbAsteroides = 0; // à bouger dans le manager
    int i_nbAsteroidesMAX;
    int i_scoreDeb;
    int i_level;

    void Start()
    {
        i_nbAsteroidesMAX = 2;
        i_level = 1;
        i_scoreDeb = 0;
    }

    void Update()
    {
        upLevel();

        while (i_nbAsteroides < i_nbAsteroidesMAX)
        {
           SpawnAsteroide();
        }

    }
    
    public void SupAsteroide() { 

        i_nbAsteroides--; 
    }

    void SpawnAsteroide()
    {
        int i = Random.Range(0, asteroides.Length);

        //les astéroïdes apparaissent dans la zone de caméra
        f_coordY = Random.Range(-cam.aspect * (cam.orthographicSize/2), cam.aspect * (cam.orthographicSize/2));

        Instantiate(asteroides[i], new Vector3(this.transform.position.x, f_coordY,0), Quaternion.identity);

        i_nbAsteroides++;
    }

    void upLevel()
    {
        int scorePlafond = i_scoreDeb + (5 * i_level);

        if (FindObjectOfType<UIController>().getScore() == scorePlafond)
        {
            i_scoreDeb = scorePlafond;
            i_nbAsteroidesMAX++;
            i_level++;
            FindObjectOfType<UIController>().upLevel();
            FindObjectOfType<asteroidsController>().upSpeed();
        }
    }



}
