﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipController : MonoBehaviour
{
    public Transform shootPrefab = null;
    public Transform explosionPrefab = null;
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get input
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        //Move ship
        transform.Translate(new Vector3(horizontal, 0f, 0f));

        //Shooting
        if(Input.GetButtonDown("Fire1"))
        {
            //Create new shoot object
            Transform newShoot = Instantiate<Transform>(shootPrefab);

            //Position shoot object
            newShoot.position = transform.position;

            //Set shoot speed
            newShoot.GetComponent<ShootController>().speed = 30.0f;

            newShoot.tag = "ShipShoot";
        }
    }

     private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "EnemyShoot")
        {
            GameObject.FindObjectOfType<LifeController>().Lifes--;
            if(GameObject.FindObjectOfType<LifeController>().Lifes < 0)
            {
                GameObject.FindObjectOfType<LifeController>().Lifes = 0;
                SceneManager.LoadScene("GameOverScene");
            }else
            {
                enabled = false;
                Transform explosion = Instantiate<Transform>(explosionPrefab);
                explosion.position = transform.position;
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }

    }
}
