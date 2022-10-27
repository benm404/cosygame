using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsMoving : MonoBehaviour
{
    // Start is called before the first frame update
    bool Moving = false;

    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            Moving = true;
            anim.SetBool("Moving", true);
        } else { Moving = false; anim.SetBool("Moving", false); }

        if (Moving)
        {
            
        } else {  }
    }
}
