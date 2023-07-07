using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform Player;

    public float Suaves;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame


    void LateUpdate()
    {
        if (Player.position.x >= -6.2 && Player.position.x <= 104)
        {
            Vector3 Following = new Vector3(Player.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, Following, Suaves * Time.deltaTime);
        }

    }
}
