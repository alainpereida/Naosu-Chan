using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{ 
    private Canvas canvas; 
    //Bandera de pausa
    private bool pauseEnabled;
    // Start is called before the first frame update
    void Start()
    {
        pauseEnabled = false; 
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape")){
            if(pauseEnabled == true){
                resumeGame();
            }else{
                if(pauseEnabled == false){
                    pauseGame();
                }
            }
        }
    }
    public void resumeGame(){
        canvas.enabled = false; 
        //Se resume el juego 
        Time.timeScale = 1;
        pauseEnabled = false;
    }
    public void pauseGame(){
        Time.timeScale = 0;
        canvas.enabled = true;
        pauseEnabled = true;
    }
}
