using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovel : MonoBehaviour
{
    private Vector3 posA;

    private Vector3 posB;

    private Vector3 posC;

    private Vector3 nexPos;

    [SerializeField]

    private float speed;

    [SerializeField]
    private Transform childTransform;

    [SerializeField]
    public Transform transformB;
    public Transform transformC;
    public GameObject lazer;
    public GameObject StopLazer;
    public GameObject portao;
    [SerializeField]
    private float timer;
    public bool comeount;
    public bool nerfplaya;
    public int parou;
    public bool desativa;

    public float speedSoma;

    void Start()
    {
        posA = childTransform.localPosition;
        posB = transformB.localPosition;
        posC = transformC.localPosition;
        nexPos = posB;
        timer = 0;
        comeount = false;
        nerfplaya = false;
        desativa = false;
    }

  
    private void Update()
    {
        Move();
        if(parou >2)
        {
            speed = 0;
            lazer.SetActive(false);
            parou = 0;
            nerfplaya = false;
            portao.SetActive(false);
        }
        
        if (comeount)
        {
            lazer.SetActive(false);
            timer += Time.deltaTime;
            if (timer > 1)
            {
                lazer.SetActive(true);
                speed = speedSoma;
                timer = 0;
                comeount = false;
                nerfplaya = true;
            }
        }
    }


    private void Move()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nexPos, speed * Time.deltaTime);

        if (Vector3.Distance(childTransform.localPosition, nexPos) <= 0.1)
        {
            ChangeDestination();
            parou++; 
        }
    }

    private void ChangeDestination()
    {
        nexPos = nexPos != posC ? posC : posB;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && nerfplaya == false)
        {
            StopLazer.SetActive(false);
            comeount = true;
            portao.SetActive(true);
        }
        if (collision.gameObject.CompareTag("TiraLaser"))
        {
            StopLazer.SetActive(true);
            nerfplaya = false;
            desativa = true;
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("para"))
        {
            parou++;
        }
     

    }
}
