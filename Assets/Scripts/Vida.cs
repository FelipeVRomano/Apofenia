using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    // Start is called before the first frame update
   

    public int hp = 1;
    public int GanhaPontos = 0;
    public int pontos = 0;
    

    public void Dano(int damageCount)
    {
        hp -= damageCount;

        if (hp <= 0)
        {
            gameObject.SetActive(false);
            /*  if (GanhaPontos == 1)
        {
            Pontos.score += pontos;

        }
        */
        }

    }
    
}