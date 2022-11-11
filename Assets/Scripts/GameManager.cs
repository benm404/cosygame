using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class GameManager : MonoBehaviour
{
    public GameObject TextBox;
    
    public TextMeshProUGUI Litter;
    public TextMeshProUGUI Race;
    public TextMeshProUGUI RockKey;
    private GameObject LitterContainer;

    public int Time;
    [SerializeField]private int Timer;
    public bool LitterCollected = false;
    public bool RaceWon = false;
    public bool RockKeyCollected = false;

    private bool StartTimer = false;
    private bool LitterText = true;
    private bool RaceText = true;
    private bool RockText = true;

    private void Start()
    {
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
            }
        }

        if (RaceWon && RaceText && Timer >= 0)
        {

            RaceText = false;
            DisplayText(Race);
        }
        if(RaceWon && !RaceText && Timer <= 0)
        {
            HideText(Race);
        }

        if(RockKeyCollected && RockText && Timer >= 0)
        {
            RockText = false;
            DisplayText(RockKey);
        }

        if(RockKeyCollected && !RockText && Timer <= 0)
        {
            HideText(RockKey);
        }
    }

    private void FixedUpdate()
    {
        if (Timer >= 0 && StartTimer)
        {
            Timer -= 1;
        }
        
    }

    private void DisplayText(TextMeshProUGUI text)
    {
        StartTimer = true;
        text.gameObject.SetActive(true);
        TextBox.SetActive(true);
    }

    private void HideText(TextMeshProUGUI text)
    {
        StartTimer = false;
        Timer = Time;
        text.gameObject.SetActive(false);
        TextBox.SetActive(false);
    }
}
