using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool jogopausado = false;
    public GameObject pauseMenuUI;
    public GameObject controlesUI;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (jogopausado)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        jogopausado = false;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        jogopausado = true;
    }

    public void loadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void voltaJogo()
    {
        //Application.Quit();
        Resume();
    }
    public void controles()
    {
        pauseMenuUI.SetActive(false);
        controlesUI.SetActive(true);
    }
    public void voltaDosControles()
    {
        pauseMenuUI.SetActive(true);
        controlesUI.SetActive(false);
    }
}
