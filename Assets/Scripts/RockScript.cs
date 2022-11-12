using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour
{
    GameManager GameManager;
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
            if (Input.GetKey(KeyCode.E))
            {
                if (collision.CompareTag("RockKey") && GameManager.RaceWon)
                {
                GameManager.RockKeyCollected = true;
                }
            }
    }
}
