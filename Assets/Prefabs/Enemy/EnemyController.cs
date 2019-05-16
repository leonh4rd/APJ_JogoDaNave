using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform shootPrefab = null;
    public Transform explosionPrefab = null;
    float shootRateMin = 2; 
    float shootRateMax = 10; 
    float shootRate = 1f;
    float shootSpeed = 1f;
    int maxEnemyShoot = 7;
    public Color shootColor;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        shootRate -= Time.deltaTime;
        if(shootRate <= 0f)
        {
            GameObject[] enemyShoots = GameObject.FindGameObjectsWithTag("EnemyShoot");
            if(enemyShoots.Length < maxEnemyShoot)
            {
                Transform newShoot = Instantiate<Transform>(shootPrefab);
                newShoot.position = transform.position;
                newShoot.GetComponent<ShootController>().direction = -1;
                newShoot.tag = "EnemyShoot";
                newShoot.GetComponent<ShootController>().speed *= shootSpeed;
                newShoot.GetComponent<MeshRenderer>().material.color = shootColor;
            }
            shootRate = Random.Range(2f, shootRateMax);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "ShipShoot")
        {
            GameObject.FindObjectOfType<ScoreController>().Score += 10;
            if(GameObject.FindObjectOfType<ScoreController>().Score % 200 == 0)
            {
                GameObject.FindObjectOfType<LifeController>().Lifes++;
            }
            
            enabled = false;
            Transform explosion = Instantiate<Transform>(explosionPrefab);
            explosion.position = transform.position;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

    }

    public float LevelDifficulty
    {
        set
        {
            shootSpeed = value * 0.7f;
            maxEnemyShoot *= (int)value;
            shootRate = Random.Range(shootRateMin / value, shootRateMax / value);
        }
    }
}
