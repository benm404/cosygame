using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class GameManager : MonoBehaviour
{
    MovementScript MovementScript;

    public GameObject TextBox;
    
    public GameObject Litter;
    public GameObject Race;
    public GameObject RockKey;
    public GameObject FinalKey;
    private GameObject LitterContainer;

    public int Time;
    [SerializeField]private int Timer;
    public bool LitterCollected = false;
    public bool RaceWon = false;
    public bool RockKeyCollected = false;
    public bool PhotoViewed = false;
    public bool FinalKeyCollected = false;

    private bool StartTimer = false;
    private bool LitterText = true;
    private bool RaceText = true;
    private bool RockText = true;
    private bool KeyText = true;

    private bool Options = false;
    private int OTimer;
    private int OTime = 10;
    public GameObject PauseMenu;

    private void Start()
    {
        MovementScript = GameObject.Find("PlayerContainer").GetComponent<MovementScript>();
        LitterContainer = GameObject.Find("Litter");
        Timer = Time;
    }

    private void Update()
    {
        if(Timer <= 0)
        {
            StartTimer = false;
        }

        if(LitterContainer.transform.childCount <= 0)
        {
            LitterCollected = true;
        }
        if (LitterCollected)
        {
            if (Timer >= 0 && LitterText)
            {
                LitterText = false;
                DisplayText(Litter);
            }
            if (Timer <= 0)
            {
                HideText(Litter);
                HideText(Race);
                HideText(RockKey);
                HideText(FinalKey);
            }
        }

        if (RaceWon && RaceText && Timer >= 0)
        {

            RaceText = false;
            DisplayText(Race);
        }
        if(RaceWon && !RaceText && Timer <= 0)
        {
           // HideText(Race);
        }

        if(RockKeyCollected && RockText && Timer >= 0)
        {
            RockText = false;
            DisplayText(RockKey);
        }

        if(RockKeyCollected && !RockText && Timer <= 0)
        {
            //HideText(RockKey);
        }

        if(FinalKeyCollected && KeyText && Timer >= 0)
        {
            KeyText = false;
            DisplayText(FinalKey);
        }

        if(FinalKeyCollected && !KeyText && Timer <= 0)
        {
           // HideText(FinalKey);
        }

        if(Input.GetKey(KeyCode.Escape) && OTimer <= 0)
        {
            OTimer = OTime;
            if (!Options)
            {
                OptionsMenu();
            } else { HideOptions(); }
        }
    }

    private void FixedUpdate()
    {
        if (Timer >= 0 && StartTimer)
        {
            Timer -= 1;
        }
        if(OTimer >= 0)
        {
            OTimer -= 1;
        }
    }

    private void DisplayText(GameObject text)
    {
        StartTimer = true;
        text.SetActive(true);
        TextBox.SetActive(true);
    }

    private void HideText(GameObject text)
    {
        text.SetActive(false);
        StartTimer = false;
        Timer = Time;
        
        TextBox.SetActive(false);
    }

    private void OptionsMenu() 
    {
        Options = true;
        MovementScript.MovementActive = false;
        PauseMenu.SetActive(true);
    }

    private void HideOptions()
    {
        Options = false;
        MovementScript.MovementActive = true;
        PauseMenu.SetActive(false);
    }
}
