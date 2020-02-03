using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class startScript : MonoBehaviour
{
    public void startGame(){
        SceneManager.LoadScene("level1",LoadSceneMode.Single);
    }
}
