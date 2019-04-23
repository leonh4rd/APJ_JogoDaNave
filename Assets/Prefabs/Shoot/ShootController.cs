using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0f, speed * Time.deltaTime, 0f));

        //When shoot out of screen
        if(transform.position.y > 100f || transform.position.y <= -100f)
        {
            Destroy(gameObject);
        }
    }
}
