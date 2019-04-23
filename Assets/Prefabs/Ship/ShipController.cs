using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public Transform shootPrefab = null;
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
            enabled = false;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

    }
}
