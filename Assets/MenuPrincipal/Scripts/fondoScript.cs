using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fondoScript : MonoBehaviour
{
    public float Speed = .00006f;
    Vector2 FondPos;
    // Start is called before the first frame update
    void Start()
    {  
    }

    // Update is called once per frame
    void Update()
    {
        MoveFondo();
    }

    void MoveFondo()
    {
        FondPos += new Vector2(Speed, 0);

        GetComponent<Renderer>().material.mainTextureOffset = FondPos;
    }
}