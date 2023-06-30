using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiro : MonoBehaviour
{
    public float speed;
    public GameObject inimigo;
    private Rigidbody2D rig;
    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = Vector2.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D inimigo)
    {
        Destroy(inimigo.gameObject);
        Destroy(this.gameObject);
    }
}
