using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiscaChoque : MonoBehaviour
{
    public GameObject[] choques;
    public int limitaChoque;
    public bool contaChoque;
    public float timer;
    public int roda;
    public int programaChoque;
    public int cooldown;

    public void Start()
    {
        contaChoque = true;
        timer = 0;
        roda = choques.Length;
        limitaChoque = 0;
        
    }
    public void Update()
    {
        if(contaChoque)
        {
            timer += Time.deltaTime;
        }
        if((roda-1) * cooldown <= timer)
        {
            choques[programaChoque].SetActive(false);
            timer = 0;
            limitaChoque = 0;
            programaChoque = 0;
        }
        if (timer> limitaChoque)
        {
            if(programaChoque > 0)
            {
                choques[programaChoque].SetActive(false);
            }
            programaChoque++;
            choques[programaChoque].SetActive(true);
            limitaChoque += cooldown;
        }

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
