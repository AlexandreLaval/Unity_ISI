using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class borderController : MonoBehaviour
{
    SpawnerController spawnerCont;

    // Start is called before the first frame update
    void Start()
    {
        spawnerCont = FindObjectOfType<SpawnerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //suppression automatique du lazer 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("lazerPlayer") || other.gameObject.CompareTag("asteroide"))
        {
            if (other.gameObject.CompareTag("asteroide"))
                spawnerCont.SupAsteroide();

            Destroy(other.gameObject);
        }
    }
}
