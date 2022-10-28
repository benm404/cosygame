using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShopUI : MonoBehaviour
{
    public GameObject WitchHat;
    public GameObject Pumpkin;

    public bool WitchSelected = false;
    public bool PumpkinSelected = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (WitchSelected)
        {
            PumpkinSelected = false;
            
            if (!Pumpkin.activeInHierarchy)
            {
                WitchHat.SetActive(true);
            }
            
            
        } else { WitchHat.SetActive(false); }

        if (PumpkinSelected)
        {
            WitchSelected = false;
            if (!WitchHat.activeInHierarchy)
            {
                Pumpkin.SetActive(true);
            }
            
          
        } else { Pumpkin.SetActive(false); }


    }

    public void WitchDisplay()
    {
        if (!WitchHat.activeInHierarchy)
        {
            WitchSelected = true;
            
        }

        if (WitchHat.activeInHierarchy)
        {
            WitchSelected = false;
            
        }
    }

    public void PumpkinDisplay()
    {
        if (!Pumpkin.activeInHierarchy)
        {
            PumpkinSelected = true;
            
        }

        if (Pumpkin.activeInHierarchy)
        {
            PumpkinSelected = false;
            
        }
    }
}

