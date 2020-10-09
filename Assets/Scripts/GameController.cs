using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private bool podePassar;
    [SerializeField]
    private int oi;
    //[SerializeField]
   // private int fleip;
    //public GameObject playa;
    void Start()
    {
        podePassar = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            
            if (Input.GetKeyDown(KeyCode.Z))
            {
                podePassar = true;
            }
        }

    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
         
            if (Input.GetKeyDown(KeyCode.Z))
            {
                podePassar = true;
            }
        }

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && podePassar)
        {
            PlayerPrefs.SetInt("HP", Player.HP);
            SceneManager.LoadScene(oi);
        }

    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && podePassar)
        {
            PlayerPrefs.SetInt("HP", Player.HP);
            SceneManager.LoadScene(oi);

        }

    }
}
