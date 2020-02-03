using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SSDamage : MonoBehaviour
{
    private GameObject loliHUD;
    private GameObject stockObject; 
    private GameObject defeatedObject;
    private Canvas defeatedCanvas;
    private DestroyHeart stockScript; 
    private Animator anim;
    private bool damageReceived; 
    private int currentTime;
    private int collisionTime;
    private int transitionTime = 50; 
    private bool collisionEnabled = true; 
    

    void Start()
    {
        //Se busca el gameObject con el nombre de Naosu
        loliHUD = GameObject.Find("naosu");
        stockObject = GameObject.Find("HealthUI");
        defeatedObject = GameObject.Find("DefeatedCanvas");
        defeatedCanvas = defeatedObject.GetComponent<Canvas>();
        anim = loliHUD.GetComponent<Animator>();
        stockScript = stockObject.GetComponent<DestroyHeart>();
    }

    void Update()
    {
    }

  
    void OnTriggerEnter2D(Collider2D collObject){
        if(collObject.name == "bullet"){
            if(collisionEnabled){
                //Cuando el gorgonita detecta colision con la bala, la bala se destruye
                //y cambia la imagen del HUD de Naosu
                Destroy(collObject.gameObject);
                anim.SetBool("isDamaged",true);
                stockScript.stocks -=1;
                if(stockScript.stocks == 0){
                    collisionEnabled = false;
                    anim.SetBool("isDamaged",false);
                    anim.SetBool("isDefeated",true); 
                    defeatedCanvas.enabled=true;
                }else{
                    StartCoroutine(Invulnerability());
                }
            }
        }
    }
    IEnumerator Invulnerability(){
        collisionEnabled = false; 
        yield return new WaitForSeconds(0.5f);
        collisionEnabled = true;
        anim.SetBool("isDamaged",false);
    }
}
