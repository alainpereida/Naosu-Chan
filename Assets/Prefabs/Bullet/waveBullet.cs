using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveBullet : MonoBehaviour
{
    public GameObject enemy;
    public float spawnTime;

    // Start is called before the first frame update
    void Awake()
    {
        InvokeRepeating("creacionBullet",0f,spawnTime);
    }

    // Update is called once per frame
    void creacionBullet()
    {
         Instantiate(enemy, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, transform.position.z), gameObject.transform.rotation);
        
    }
}
