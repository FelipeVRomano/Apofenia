using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogo : MonoBehaviour
{
    public GameObject panelBox;
    public bool podeFalar = false;
    [SerializeField]
    private int linhaAtual;
    public TextMeshProUGUI textoMensagem;
    public string[] texto;
    public int limitText;
    //public float timer = 0;
    public static bool estaFalando = false;
    [SerializeField]
    private bool teste = false;
    [SerializeField]
    private bool jaComecaFalando;
    [SerializeField]
    // private bool[] Mike = 
    public GameObject img;
    public GameObject[] imgs;
    public int conta;
    //[SerializeField]
    //private bool[] ray;
    public bool rodaCut = false;
    void Start()
    {
        textoMensagem.text = texto[linhaAtual].ToString();
        img = imgs[linhaAtual];
        conta = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (podeFalar)
        {
            //img.SetActive(false);
            //img = imgs[linhaAtual];
            estaFalando = true;
            if (img != imgs[linhaAtual])
            {
                
                img.SetActive(false);
                img = imgs[linhaAtual];
                if(img == imgs[linhaAtual])
                {
                    img.SetActive(true);
                }
            }
            
            if (Input.GetKeyDown(KeyCode.Z) && (PauseMenu.jogopausado == false))
            {
                //img.SetActive(false);
                linhaAtual++;               
                textoMensagem.text = texto[linhaAtual].ToString();
               // img.SetActive(true);
                if (linhaAtual >= limitText)
                {
                    linhaAtual = 0;
                    Desabilitar();
                    podeFalar = false;
                    if(rodaCut)
                    {
                        Cutscene.mudaCam = true;
                    }
                }
            }
        }
        teste = estaFalando;

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && (PauseMenu.jogopausado == false))
        {
            if (jaComecaFalando)
            {
                podeFalar = true;
                Habilitar();
            }
            else if (!jaComecaFalando && Input.GetKeyDown(KeyCode.Z))
            {
               
             podeFalar = true;
             Habilitar();
  
            }   
        }

    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && (PauseMenu.jogopausado == false))
        {
            if (jaComecaFalando)
            {
                podeFalar = true;
                Habilitar();
            }
            else if (!jaComecaFalando && Input.GetKeyDown(KeyCode.Z))
            {

                podeFalar = true;
                Habilitar();

            }
        }
    }
 
    void Habilitar()
    {
        panelBox.SetActive(true);
        Player.vel = 0f;
        //estaFalando = true;
        img.SetActive(true);
    }
    void Desabilitar()
    {
        panelBox.SetActive(false);
        Player.vel = 5.5f;
        estaFalando = false;
        Destroy(gameObject);
    }
    public void ativaSprite()
    {
      
    }
}
