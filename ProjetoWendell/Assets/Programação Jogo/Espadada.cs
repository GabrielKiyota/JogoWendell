using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espadada : MonoBehaviour
{
    public Rigidbody2D rig;

    public GameObject isso;
    // Start is called before the first frame update
    void Start()
    {
        isso = GetComponent<GameObject>();
        rig = GetComponent<Rigidbody2D>();
        //Destroy(isso , 1f);
        Destroy(gameObject,1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            transform.eulerAngles = new Vector2(0, 180f);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            transform.eulerAngles = new Vector2(0, 0f);
        }
    }
    private void OnTriggerEnter2D(Collider2D dano)
    {
        Inimigo vidaInimigo = dano.GetComponent<Inimigo>();
        if (vidaInimigo != null)
        {
            // Aplica o dano ao inimigo
            vidaInimigo.DanoTomado();
        }
    }

}
