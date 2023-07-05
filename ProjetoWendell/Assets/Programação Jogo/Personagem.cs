using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Personagem : MonoBehaviour
{

    public Animator anim;
    public float Speed;
    Rigidbody2D rig;
    public float Forca;
    public bool Pulando;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Pulando = false;
    }

    // Update is called once per frame
    void Update()
    {
        //pegando input do teclado
        
        
        //imprimindo valores no console
        //Debug.Log("Horizontal: " + x); 
        //Debug.Log("Vertical: " + y);

        
        Vector3 movimento = new Vector3(Input.GetAxis("Horizontal"),0f, 0f);
        anim.SetFloat("Horizontal",movimento.x);
        //anim.SetFloat("Vertical",movimento.y);
        anim.SetFloat("Speed",movimento.magnitude);

        transform.position = transform.position + movimento * Speed * Time.deltaTime;
        
        if (Input.GetKeyUp(KeyCode.Space) && Pulando == false)
        {
            rig.AddForce(transform.up * Forca);
            Pulando = true;
            anim.SetBool("Pulando", true);
        }
    }

    void OnTriggerEnter2D(Collider2D colisor)
    {

        if (colisor.CompareTag("Chão"))
        {
            Pulando = false;
            anim.SetBool("Pulando",false );
        }
    }
}