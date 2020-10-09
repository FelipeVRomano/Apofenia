using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    [SerializeField]
    private int index;
    public float typingSpeed;
    public bool teste;
    public GameObject panelBox;
    [SerializeField]
    private int linhaAtual;
    public TextMeshProUGUI textoMensagem;
    public string[] texto;
    public int limitText;
    [SerializeField]
    private bool teste1 = false;
    public GameObject continueButton;

    [SerializeField]
    private int oi;
    public static bool estaFalando3 = false;
    [SerializeField]
    private bool sentenceOver = true;
    public Animator haha;
    private float bu = 0;
    private bool soma = false;
    public GameObject haha2;
    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        sentenceOver = true;
    }
    void Start()
    {
        textoMensagem.text = texto[linhaAtual].ToString();
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = " Escudos Desativados ";
            //textDisplay.text = "";
            //haha.SetBool("Escudo", true);
            //soma = true;
            //continueButton.SetActive(false);
            //teste = true;
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Player") && (PauseMenu.jogopausado == false))
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (sentenceOver)
                {
                    StartCoroutine(Type());
                }
            
                sentenceOver = false;
                
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
        if (teste)
        {
            Habilitar();
            if (Input.GetKeyDown(KeyCode.Z) && (PauseMenu.jogopausado == false))
            {
                linhaAtual++;
                textoMensagem.text = texto[linhaAtual].ToString();
                if (linhaAtual >= limitText)
                {
                    linhaAtual = 0;
                    Desabilitar();
                    teste = false;
                    SceneManager.LoadScene(oi);

                }
            }
        }
        if(index>0)
        {
            teste = true;
            continueButton.SetActive(false);
            sentenceOver = false;
            haha.SetBool("Escudo", true);
            soma = true;
        }
        teste1 = estaFalando3;
        if(soma)
        {
            bu += Time.deltaTime;
        }
        if (bu>2)
        {
            haha2.SetActive(false);
        }
    }
    void Habilitar()
    {
        panelBox.SetActive(true);
        Player.vel = 0f;
        estaFalando3 = true;
        //linhaAtual++;
    }
    void Desabilitar()
    {
        panelBox.SetActive(false);
    }
}