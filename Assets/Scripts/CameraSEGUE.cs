using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSEGUE : MonoBehaviour
{
    public GameObject player;
    public float camVel = 0.25f;
    public bool segueHeroi;
    public Vector3 ultimaAlvoPos;
    public Vector3 velAtual;
    [Range(0, 5)]
    public float ajusteCamX = 1;
    [Range(0, 5)]
    public float ajusteCamY = 1;
    // Start is called before the first frame update
    void Start()
    {
        segueHeroi = true;
        ultimaAlvoPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if(segueHeroi)
        {
            if(player.transform.position.x >= transform.position.x)
            {
                Vector3 novaCamPos = Vector3.SmoothDamp(transform.position, player.transform.position, ref velAtual, camVel);
                transform.position = new Vector3(novaCamPos.x + ajusteCamX, novaCamPos.y + ajusteCamY, transform.position.z);
                ultimaAlvoPos = player.transform.position;
            }
            else if (player.transform.position.x <= transform.position.x)
            {
                Vector3 novaCamPos = Vector3.SmoothDamp(transform.position, player.transform.position, ref velAtual, camVel);
                transform.position = new Vector3(novaCamPos.x + ajusteCamX, novaCamPos.y + ajusteCamY, transform.position.z);
                ultimaAlvoPos = player.transform.position;
            }
        }
    }

}
