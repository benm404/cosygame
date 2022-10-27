using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovementScript : MonoBehaviour
{

    public bool MovementActive = true;

    

    public float speed;

    void Start()
    {
        
    }

    
    void Update()
    {

        if (MovementActive)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.localPosition += Vector3.up * speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.localPosition += Vector3.up * -speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.localPosition += Vector3.right * -speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.localPosition += Vector3.right * speed * Time.deltaTime;
            }
        }

        
    }
}
