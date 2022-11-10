using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    GhostScript GhostScript;
    void Start()
    {
        GhostScript = GameObject.Find("GhostRacer").GetComponent<GhostScript>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GhostScript.StartRaceBool && !GhostScript.RaceOver)
        {
            if (collision.CompareTag("Player"))
            {
                GhostScript.PlayerWin = true;
                GhostScript.RaceOver = true;
            }

            if (collision.CompareTag("Ghost"))
            {
                GhostScript.GhostWin = true;
                GhostScript.RaceOver = true;
            }
        }
    }

}
