using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    public Transform enemyPrefab = null;
    public float direction = 1f;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        CreateGame();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(speed * direction, 0f, 0f) * Time.deltaTime);
        if(transform.position.x >= 9f || transform.position.x <= -9f)
        {
            direction = -direction;
        }
        if(transform.childCount == 0)
        {
            CreateGame();
        }
    }

    public void CreateGame()
    {
        for(int x = 0; x < 11; x++)
        {
            for(int y = 0; y < 5; y++)
            {
                //Create object
                Transform newEnemy = Instantiate<Transform>(enemyPrefab);

                //Set parent
                newEnemy.SetParent(transform);

                //Set position of new enemy
                newEnemy.localPosition = new Vector3(-15f + x * 3f, y * 3f, 0f);
            }
        }
    }
}
