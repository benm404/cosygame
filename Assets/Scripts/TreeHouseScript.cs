using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TreeHouseScript : MonoBehaviour
{
    GameManager GameManager;
    MovementScript MovementScript;
    public GameObject Image;
    private bool StartTimer = false;
    private int Timer = 200;
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        MovementScript = GameObject.Find("PlayerContainer").GetComponent<MovementScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer <= 0)
        {
            HideImage();
            MovementScript.MovementActive = true;
        }
    }

    private void FixedUpdate()
    {
        if (StartTimer)
        {
            Timer -= 1;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(GameManager.RockKeyCollected && Input.GetKey(KeyCode.E) && collision.CompareTag("TreeHouse"))
        {
            if (!Image.activeInHierarchy)
            {
                DisplayImage();
                StartTimer = true;
                MovementScript.MovementActive = false;
                GameManager.PhotoViewed = true;
            }
            
        }
    }

    private void DisplayImage()
    {
        Image.SetActive(true);
    }

    private void HideImage()
    {
        Image.SetActive(false);
    }
}
