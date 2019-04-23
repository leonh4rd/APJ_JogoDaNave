using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform shootPrefab = null;
    float shootTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        shootTime = Random.Range(2f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        shootTime -= Time.deltaTime;
        if(shootTime <= 0f)
        {
            GameObject[] enemyShoots = GameObject.FindGameObjectsWithTag("EnemyShoot");
            if(enemyShoots.Length < 7)
            {
                Transform newShoot = Instantiate<Transform>(shootPrefab);
                newShoot.position = transform.position;
                newShoot.GetComponent<ShootController>().direction = -1;
                newShoot.tag = "EnemyShoot";
            }
            shootTime = Random.Range(2f, 10f);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "ShipShoot")
        {
            enabled = false;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

    }
}
