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
    public bool pulo2;
    public bool pulo;
    public GameObject Espadada;
    public Transform spawnAtaque;
    public int vida;
    public bool vivo;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Pulando = false;
        vivo = true;
        GameController.controle.vidaTexto(vida);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movimento = new Vector3(Input.GetAxis("Horizontal"),0f, 0f);
        anim.SetFloat("Horizontal",movimento.x);
        //anim.SetFloat("Vertical",movimento.y);
        anim.SetFloat("Speed",movimento.magnitude);

        transform.position = transform.position + movimento * Speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && Pulando == false && vivo == true)
        {
            rig.AddForce(transform.up * Forca);
            Pulando = true;
            anim.SetBool("Pulando", true);
            
        }

        if (Input.GetKeyUp(KeyCode.Space) && Pulando == true && pulo == false&& vivo == true)
        {
            pulo2 = false;
            pulo = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && pulo2 == false && pulo  == true && vivo == true)
        {
            rig.AddForce((transform.up * Forca));
            pulo2 = true;
        }
        if (Input.GetKeyDown(KeyCode.S) && pulo == false && vivo == true)
        {
            anim.SetTrigger("Ataque");
            Instantiate(Espadada, spawnAtaque.position, spawnAtaque.rotation);
            Speed = 0;
        }
        if (Input.GetKeyUp(KeyCode.S) && pulo == false&& vivo == true)
        {
            Speed = 5;
        }

        if (vida <= 0)
        {
            anim.SetTrigger("morto");
            vivo = false;
            Speed = 0;
        }
        if (vida > 3)
        {
            vida = 3;
            GameController.controle.vidaTexto(vida);
        }
    }

    void OnTriggerEnter2D(Collider2D colisor)
    {

        if (colisor.CompareTag("Chão"))
        {
            pulo = false;
            Pulando = false;
            anim.SetBool("Pulando", false);
            
        }
        if (colisor.CompareTag("Vida"))
        {
            vida = vida + 1;
            GameController.controle.vidaTexto(vida);
        }
    }

    private void OnCollisionEnter2D(Collision2D dano)
    {
        if (dano.gameObject.tag == "inimigo")
        {
            vida = vida - 1;
            GameController.controle.vidaTexto(vida);
        }

    }
}