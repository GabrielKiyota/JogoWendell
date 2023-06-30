using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class enimigo : MonoBehaviour
{
    public GameObject inimigo;
    public GameObject tiro;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void OnTriggerCollisionEnter2D(Collision2D inimigo)
    {
        Destroy(inimigo.gameObject);
        Destroy(this.gameObject);
    }
}
