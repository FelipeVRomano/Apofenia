using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choque : MonoBehaviour
{
     public int dano = 1;
    public float ChoqueCooldown;
    public float TempoChoque = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        ChoqueCooldown = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (ChoqueCooldown > 0)
        {

            ChoqueCooldown -= Time.deltaTime;
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (ChoqueCooldown <= 0)
            {
                Player vida = collider.gameObject.GetComponent<Player>();
                if (vida != null)
                {
                    vida.DanoPlayer(dano);
                    ChoqueCooldown = TempoChoque;
                }

            }

        }
    }
}
