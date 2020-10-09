using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Quit()
        {
        print("saindo");
        Application.Quit();
    }

    public void Menu()
    {
        Application.LoadLevel("Menu");

    }
    public void Jogar()
    {
        Application.LoadLevel("Fase1");

    }
    public void Creditos()
    {
        Application.LoadLevel("Creditos");

    }
    public void Tutorial()
    {
        Application.LoadLevel("FaseTutorial");

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
