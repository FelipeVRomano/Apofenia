using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{

    public int dano = 1;
    public int destruir;
    public string objectTag;
    public Vector2 speed = new Vector2(5, 5);
    private Vector2 movement;
    public Vector2 direction = new Vector2(1, 0);
    public float vel = 0.8f;
    public bool Frente ;
    

    void Start()
    {
       Destroy(gameObject, 1f); // 10 segundos
        if (Player.move >= 0 && Player.adivinhaFace == false)
        {
            Frente = true;
        }
        else if (Player.move <= 0 && Player.adivinhaFace == true)
       {
           Frente = false;

       }

    }
    void Update()
    {
       
        if (Frente == true )
        {
            movement = new Vector2(
          direction.x * speed.x,
           direction.y * speed.y);
        }
        else if (Frente == false)
        {
            movement = new Vector2(
          direction.x * -speed.x,
           direction.y * speed.y);
        }
       
        
    }
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
       if (collider.gameObject.tag == "Inimigo")
        {
            Vida vida = collider.gameObject.GetComponent<Vida>();
            if (vida != null)
            {
                vida.Dano(dano);
            }
            

        }
        if (collider.gameObject.tag == "Cenario")
        {
            Destroy(gameObject);
        }
       
        if (collider.gameObject.CompareTag("esteiraNeg"))
        {
            Destroy(gameObject);
        }
        if (collider.gameObject.CompareTag("esteiraPos"))
        {
            Destroy(gameObject);
        }
        if (collider.gameObject.CompareTag("parede"))
        {
            Destroy(gameObject);
        }
        if (collider.gameObject.CompareTag("chao"))
        {
            Destroy(gameObject);
        }
       

    }



}