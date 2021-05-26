using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;


public class spacialShipController : MonoBehaviour
{
    public Rigidbody2D rb2;
    public float f_speed = 8;
    public GameObject[] lazers;

    Vector2 playerPos;
    GameObject lazerCanon;
    float f_limity = 4.5f;
    float f_life = 1.0f;
    AudioSource audioMissile;


    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        playerPos.x = transform.position.x;
        lazerCanon = GameObject.Find("LazerCanon");
        audioMissile = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerShoot();
        PlayerMove();
        
    }

    //mouvement du joueur 
    void PlayerMove()
    {
        if(Input.GetAxis("Horizontal") != 0)
            playerPos.y += -Input.GetAxis("Horizontal") * f_speed * Time.deltaTime;
        else if (Input.GetAxis("Vertical") != 0)
            playerPos.y += Input.GetAxis("Vertical") * f_speed * Time.deltaTime;
        playerPos.y = Mathf.Clamp(playerPos.y, -f_limity, f_limity);
        transform.position = playerPos;
    }

    //tire du joueur 
    void PlayerShoot()
    {
        int i = UnityEngine.Random.Range(0, lazers.Length);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(lazers[i], lazerCanon.transform.position, Quaternion.Euler(0,0,-90));
            audioMissile.Play();
        }
    }

    public void looseLife()
    {
        f_life -= 0.3f;
        Debug.Log(f_life);
        if (f_life < 0.2f)
        {
            //création du fichier de sérialization
            string path = Directory.GetCurrentDirectory() + @"\scores.txt";
            File.AppendAllText(path, $"{FindObjectOfType<UIController>().getScore()} - { DateTime.Now.ToShortDateString()} \n");
            Debug.Log(path);
            SceneManager.LoadScene(sceneName: "end");
            
        }
    }

    public float getLife()
    {
        return f_life;
    }

}
