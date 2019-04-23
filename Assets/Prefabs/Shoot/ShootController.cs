using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public float speed = 1f;

    public float direction = 1f;

    float limit = 50f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0f, speed * direction * Time.deltaTime, 0f));

        //When shoot out of screen
        if(transform.position.y > limit || transform.position.y <= -limit)
        {
            Destroy(gameObject);
        }
    }
}
