using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Controle : MonoBehaviour
{
    // Start is called before the first frame update
    // public Sprite[] CoraçoesSprite;
    // public Image Vida1
    public Image Vida1;
    public Image Vida2;
    public Image Vida3;


    private Player hpp;

    void Start()
    {
        hpp = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.HP == 3)
        {
            Vida1.enabled = true;
            Vida2.enabled = true;
            Vida3.enabled = true;
        }

        if (Player.HP == 2)
        {
            Vida1.enabled = true;
            Vida2.enabled = true;
            Vida3.enabled = false;
        }

        if (Player.HP == 1)
        {
            Vida1.enabled = true;
            Vida2.enabled = false;
            Vida3.enabled = false;
        }
        if (Player.HP == 0)
        {
            Vida1.enabled = false;
            Vida2.enabled = false;
            Vida3.enabled = false;
        }
    }
}
