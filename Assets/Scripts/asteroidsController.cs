using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidsController : MonoBehaviour
{
    Rigidbody2D rb;
    float f_speed;
    public float f_damage;
    SpawnerController spawnerCont;
    public GameObject explosionFx;
    float rotationSpeed = 30f;
    AudioSource audioOnDestroy;

    Collider2D collider;
    SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        spawnerCont = FindObjectOfType<SpawnerController>();
        rb = GetComponent<Rigidbody2D>();
        f_speed = 2;
        audioOnDestroy = GetComponent<AudioSource>();

        collider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-1 * f_speed, rb.velocity.y);
        this.transform.Rotate(Vector3.forward * (rotationSpeed * Time.deltaTime));
    }

    public void upSpeed()
    {
        f_speed += 0.5f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("base"))
        {
            other.GetComponent<baseController>().takeDamage(f_damage);
            Instantiate(explosionFx, this.transform.position, Quaternion.identity);
            audioOnDestroy.Play();
            spawnerCont.SupAsteroide();

            collider.enabled = false;
            spriteRenderer.enabled = false;
            Destroy(this.gameObject,6f);
        }
    }



}
