using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHeart : MonoBehaviour
{
    public GameObject h1;
    public GameObject h2;
    public GameObject h3;
    public int stocks=3; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(stocks == 3){
            h1.SetActive(true);
            h2.SetActive(true);
            h3.SetActive(true);
        }else{
            if(stocks == 2){
                h1.SetActive(true);
                h2.SetActive(true);
                h3.SetActive(false);
            }else{
                if(stocks == 1){
                    h1.SetActive(true);
                    h2.SetActive(false);
                    h3.SetActive(false);
                }else{
                    if(stocks == 0){
                        h1.SetActive(false);
                        h2.SetActive(false);
                        h3.SetActive(false);
                    }
                }
            }
        }
    }
}
