using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyBullet : MonoBehaviour
{
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        //Vector2 temp = new Vector2 (-speed, 0);
        // Make the bullet move upward
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = transform.up * speed;
         if(!GetComponent<Renderer>().isVisible){
         Destroy(gameObject);
     }
        
    }
}
