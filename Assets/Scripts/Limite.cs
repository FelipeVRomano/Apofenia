using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limite : MonoBehaviour
{
    public GameObject limiteAtivar;
    public GameObject limiteDesativar;
 

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            limiteAtivar.SetActive(true);
            limiteDesativar.SetActive(false);
        }
    }
}




