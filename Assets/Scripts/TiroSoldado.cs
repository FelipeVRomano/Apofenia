using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroSoldado : MonoBehaviour
{
    public int dano = 1;
    public float TempoDestr = 2f;
    public int destruir;
    public string objectTag;
    public Vector2 speed = new Vector2(5, 5);
    private Vector2 movement;
    public Vector2 direction = new Vector2(1, 0);
    public float vel = 10f;
    public bool Frente;
    public GameObject playa;
    
    public GameObject p;
    public static bool frente;
    

    void Start()
    {

        playa = GameObject.FindGameObjectWithTag("Player");
        Destroy(gameObject, TempoDestr); // 10 segundos
        /*if (InimigoControle.veriFlip)
        {
           Frente = true;
       }
        else if (!InimigoControle.veriFlip)
        {
            Frente = false;
        }
        */
    }
    void Update()
    {
       
       // if (Frente)
       if(frente)
        {
            movement = new Vector2(
          direction.x * speed.x,
           direction.y * speed.y);
        }
        //else if (!Frente)
        else if (!frente)
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
    
    private WaitForSeconds tempo = new WaitForSeconds(1);
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            
            Player vida = collider.gameObject.GetComponent<Player>();
            if (vida != null)
            {
                vida.DanoPlayer(dano);
                Destroy(gameObject);

            }

            MudaCor2();
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

    }
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Cenario")
        {
            Destroy(gameObject);
        }
       
    }
    void MudaCor2()
    {

        iTween.ColorTo(playa, iTween.Hash("g", 0, "b", 0, "time", 0.05f, "looptype", iTween.LoopType.pingPong, "oncomplete", "ParaEfeito"));
    }
    void VoltaCor2()
    {
        iTween.ColorTo(playa, iTween.Hash("color", Color.white, "time", 0.1f));
    }
    IEnumerator ParaEfeito()
    {
        yield return tempo;
        iTween.Stop(playa, true);
        VoltaCor2();
    }



}