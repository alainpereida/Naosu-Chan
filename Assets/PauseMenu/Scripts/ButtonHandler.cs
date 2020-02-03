using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public void resumeGame(){
        GameObject pauseCanvas = GameObject.Find("PauseCanvas");
        PauseScript pauseScript = pauseCanvas.GetComponent<PauseScript>();
        Debug.Log("Button clicked = ");
        pauseScript.resumeGame();
    }

    public void returnMainMenu(){
        
        Time.timeScale = 1;
        SceneManager.LoadScene("menu",LoadSceneMode.Single);
    }
}
