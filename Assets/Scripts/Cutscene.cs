using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Cutscene : MonoBehaviour
{
    public PlayableDirector rd;
    public static bool mudaCam;
    private bool isCutScenePlaying = false;
    
    public IEnumerator EndCutScene()
    {
        yield return new WaitForSeconds(7);
        //playerController.enabled = true;
        mudaCam = false;
        isCutScenePlaying = false;
    }
    
    void Update()
    {
        if(mudaCam)
        {
            rd.Play();
            isCutScenePlaying = true;
            StartCoroutine(EndCutScene());
        }
    }
}
