using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerPlayer : MonoBehaviour
{
    public float f_speed;

    UIController uiController;
    Rigidbody2D rb;
    SpawnerController spawnerCont;
    public GameObject explosionFx;
    AudioSource audioData;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        uiController = FindObjectOfType<UIController>();
        spawnerCont = FindObjectOfType<SpawnerController>();
        audioData = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();   
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(f_speed, rb.velocity.y);
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("asteroide"))
        {
            audioData.Play();
            //mise à jour du score dans l'UI 
            uiController.setScore(1);

            Instantiate(explosionFx, this.transform.position, Quaternion.identity);

            spawnerCont.SupAsteroide();
            audioData.Play();
            //destruction de l'objet
            Destroy(collider.gameObject);
        }

        this.GetComponent<BoxCollider2D>().enabled = false;
        
        spriteRenderer.enabled = false;
        Destroy(this.gameObject,6f);
    }

}
