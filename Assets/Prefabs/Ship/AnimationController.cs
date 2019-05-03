using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator = null;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("ToRight", true); 
        }
        if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetBool("ToRight", false); 
        } 

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("ToLeft", true); 
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetBool("ToLeft", false); 
        } 
    }
}
