using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewShipController : MonoBehaviour
{
    public Transform shipPrefab = null;  
    float delayRespawn = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(delayRespawn <= 0f)
        {
            if(GameObject.FindObjectsOfType<ShipController>().Length == 0)
            {
                //Destroy shoots on scene
                ShootController[] shoots = GameObject.FindObjectsOfType<ShootController>();
                foreach(ShootController shoot in shoots)
                {
                    Destroy(shoot.gameObject);
                }

                //Pause enemy ships until new ship respawn
                GameObject.FindObjectOfType<EnemiesController>().enabled = false; 
                EnemyController[] enemies = GameObject.FindObjectsOfType<EnemyController>();
                foreach (EnemyController enemy in enemies)
                {
                    enemy.enabled = false;
                }   

                //Reset delay
                delayRespawn = 1f;
            }
        }else
        {
            delayRespawn -= Time.deltaTime;
            if(delayRespawn <= 0f)
            {
                //Activate enemy ships
                GameObject.FindObjectOfType<EnemiesController>().enabled = true; 
                EnemyController[] enemies = GameObject.FindObjectsOfType<EnemyController>();
                foreach (EnemyController enemy in enemies)
                {
                    enemy.enabled = true;
                }   

                //Spawn player ship
                Transform newShip = Instantiate<Transform>(shipPrefab);
                newShip.position = transform.position;
            }
        }
       
    }
}
