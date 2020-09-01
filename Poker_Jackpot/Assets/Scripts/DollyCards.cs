using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollyCards : MonoBehaviour
{
    public int[] DollyCardNumbers;

    public bool[] CardCanChangable;

    private void Start()
    {
        Invoke("SettingCardinDecesdingOrder", 1f);

        Invoke("DollyAi", 1.5f);
    }

    void SettingCardinDecesdingOrder()
    {
        int temp;
        for (int i = 0; i < DollyCardNumbers.Length; i++)
        {
            for (int j = i + 1; j < DollyCardNumbers.Length; j++)
            {
                if (DollyCardNumbers[i] < DollyCardNumbers[j])
                {
                    temp = DollyCardNumbers[i];
                    DollyCardNumbers[i] = DollyCardNumbers[j];
                    DollyCardNumbers[j] = temp;
                }
            }
        }
    }

    private void Update()
    {
        SettingCardinDecesdingOrder();
        DollyAi();
    }

    void DollyAi()
    {
        NoCardSet();
        TwoCardSet();
        ThreeCardSet();
    }

    private void NoCardSet()
    {
        for(int i=0;i<4;i++)
        {
            CardCanChangable[i] = true;
        }
    }

    private void TwoCardSet()
    {
        if (DollyCardNumbers[0] == DollyCardNumbers[1] + 1)
        {
            CardCanChangable[0] = false;
            CardCanChangable[1] = false;
            CardCanChangable[2] = true;
            CardCanChangable[3] = true;
        }
        else if(DollyCardNumbers[1] == DollyCardNumbers[2] + 1)
        {
            CardCanChangable[0] = true;
            CardCanChangable[1] = false;
            CardCanChangable[2] = false;
            CardCanChangable[3] = true;
        }
        else if(DollyCardNumbers[2] == DollyCardNumbers[3] + 1)
        {
            CardCanChangable[0] = true;
            CardCanChangable[1] = true;
            CardCanChangable[2] = false;
            CardCanChangable[3] = false;
        }
    }

    private void ThreeCardSet()
    {
        if ((DollyCardNumbers[0] == DollyCardNumbers[1] + 1) && (DollyCardNumbers[0] == DollyCardNumbers[2] + 2))
        {
            DollyWon();
        }
        else if ((DollyCardNumbers[3] == DollyCardNumbers[2] - 1) && (DollyCardNumbers[3] == DollyCardNumbers[1] - 2))
        {
            DollyWon();
        }
    }

    private void DollyWon()
    {
        print("Dolly_WonTheGame");
    }
}
