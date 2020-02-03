using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public int holeCount = 1; 
    private Animator anim; 
    private Canvas wonCanvas; 

    // Start is called before the first frame update
    void Start()
    {
        wonCanvas = GameObject.Find("winCanvas").GetComponent<Canvas>();
        anim = GameObject.Find("naosu").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(holeCount<=0){
            anim.SetBool("hasWon",true);
            wonCanvas.enabled = true;
        }
    }
}
