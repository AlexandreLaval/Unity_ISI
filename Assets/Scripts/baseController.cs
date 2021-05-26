using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseController : MonoBehaviour
{
    // Start is called before the first frame update

    public float f_baseLife { get; set; }
    //public float f_baseLife { get { return f_baseLife; } set { f_baseLife = value; } }
    spacialShipController spacialSC;
    public GameObject explosionFx;

    AudioSource audioOnDestroy;
    void Start()
    {
        this.f_baseLife = 100.0f;
        spacialSC = FindObjectOfType<spacialShipController>();
        audioOnDestroy = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        baseDestruction();
    }

    public void takeDamage(float value)
    {
        this.f_baseLife -= value;
    }

    void baseDestruction()
    {
        if (f_baseLife <= 0)
        {
            spacialSC.looseLife();
            Instantiate(explosionFx, this.transform.position, Quaternion.identity);
            audioOnDestroy.Play();
            this.gameObject.SetActive(false);
            Destroy(this.gameObject,6f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("asteroide"))
        {
            f_baseLife -= other.GetComponent<asteroidsController>().f_damage;                      
        }
    }

}
