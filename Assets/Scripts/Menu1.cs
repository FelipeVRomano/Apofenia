using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu1 : MonoBehaviour
{
    public GameObject menu;
    public GameObject lettering;
    public GameObject Dialogo;
    public GameObject PassaFase;
    public GameObject controles;
    public GameObject carrin;
    public GameObject cidade;
    public GameObject escudo;

    public void loadMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void loadcreditos()
    {
        SceneManager.LoadScene(7);
    }
    public void loadFaseTut()
    {
        PlayerPrefs.SetInt("HP", 3);
        SceneManager.LoadScene(1);
    }
    public void Sair()
    {
        Application.Quit();
    }
    public void loadLettering ()
    {
        menu.SetActive(false);
        cidade.SetActive(true);
        carrin.SetActive(true);
        escudo.SetActive(true);
        lettering.SetActive(true);
        Dialogo.SetActive(true);
        PassaFase.SetActive(true);
    }
    public void controle()
    {
        controles.SetActive(true);
        menu.SetActive(false);

    }
    public void voltaMenu()
    {
        controles.SetActive(false);
        menu.SetActive(true);
    }
}
