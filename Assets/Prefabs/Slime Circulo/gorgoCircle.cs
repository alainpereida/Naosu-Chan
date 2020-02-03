using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gorgoCircle : MonoBehaviour
{
    CharacterController characterController;
    public float speed = 5.0f;
    private Vector3 moveDirection = Vector3.zero;
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
    private GameObject msObject; 
    private GameObject spawn;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        //Se busca el gameObject con el nombre de Naosu
        loliHUD = GameObject.Find("naosu");
        stockObject = GameObject.Find("HealthUI");
        msObject = GameObject.Find("MainScripts");
        defeatedObject = GameObject.Find("DefeatedCanvas");
        defeatedCanvas = defeatedObject.GetComponent<Canvas>();
        anim = loliHUD.GetComponent<Animator>();
        stockScript = stockObject.GetComponent<DestroyHeart>();
        spawn = GameObject.Find("spawnPoint");
    }

    void Update()
    {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
            moveDirection *= speed;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
        transform.Rotate(0,0,1);
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag("Enemy Bullet")){
             if(collisionEnabled){
                 Destroy(other.gameObject);
            //Cuando el gorgonita detecta colision con la bala, la bala se destruye
                //y cambia la imagen del HUD de Naosu
                anim.SetBool("isDamaged",true);
                stockScript.stocks -=1;
                if(stockScript.stocks == 0){
                    collisionEnabled = false;
                    anim.SetBool("isDamaged",false);
                    anim.SetBool("isDefeated",true); 
                    defeatedCanvas.enabled=true;
                    Destroy(this.gameObject);
                }else{
                    StartCoroutine(Invulnerability());
                }
             }
        }else if(other.gameObject.CompareTag("Circulo")){
            Destroy(other.gameObject);
            //Revisa cuantos hoyos le quedan 
            ScoreScript scoreScript = msObject.GetComponent<ScoreScript>();
            scoreScript.holeCount -=1;
            if(scoreScript.holeCount>0){
                anim.SetBool("hasScored",true);
                StartCoroutine(playScoreAnim());
            }else{
                Destroy(this.gameObject);
            }
        }
    }

    IEnumerator playScoreAnim(){
        this.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(2f);
        anim.SetBool("hasScored",false);
        Destroy(this.gameObject);
    }
    IEnumerator Invulnerability(){
        collisionEnabled = false;
        this.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("isDamaged",false);
        yield return new WaitForSeconds(1f);
        
        this.GetComponent<Renderer>().enabled = true;
        Instantiate(this.gameObject, new Vector3(spawn.transform.position.x, spawn.transform.position.y, spawn.transform.position.z), gameObject.transform.rotation);
        collisionEnabled = true;
        Destroy(this.gameObject);
    } 
}
