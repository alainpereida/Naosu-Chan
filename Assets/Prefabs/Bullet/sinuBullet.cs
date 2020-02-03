using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sinuBullet : MonoBehaviour
{
    public GameObject enemy;
    public float spawnTime;
    private float degree = 0;
    private float degreeBase = 0;
    private bool aumento = true;

    void Awake()
    {
        InvokeRepeating("creacionBullet",0f,spawnTime);
        degreeBase = transform.rotation.z;
        degree = transform.rotation.z;
    }

    void creacionBullet()
    {

         Instantiate(enemy, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, transform.position.z), gameObject.transform.rotation);
         enemy.transform.Rotate(0,0,180);
    }

    void Update(){
         if(degree >= (degreeBase + 30)){
             aumento = false;
         }else if (degree <= degreeBase){
             aumento = true;
         }
         
         if(aumento == true){
             transform.Rotate(0, 0, 1);
             degree = degree + 1;
         }else{
             transform.Rotate(0, 0, -1);
             degree = degree - 1;
         }
    }
}
