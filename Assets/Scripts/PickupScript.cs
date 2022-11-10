using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    Transform Transform;
    public Vector3 Child;
    private Transform HeldItem;
    public int Timer;

    // Start is called before the first frame update
    void Start()
    {
        Transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HeldItem != null)
        {
            Vector3 HeldItemPos = new Vector3(Transform.position.x + 1, transform.position.y, transform.position.z);
            HeldItem.position = HeldItemPos;
        }
        if (Timer >= 0)
        {
            Timer -= 1;
        }

        
            if (Input.GetKeyDown(KeyCode.E) && Timer <= 0)
            {
                HeldItem = null;
            }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (collision.CompareTag("Litter"))
            {
                Timer = 100;
                HeldItem = collision.transform;
            }
        }
    }
}
