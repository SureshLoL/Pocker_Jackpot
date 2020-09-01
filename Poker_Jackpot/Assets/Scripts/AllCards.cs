using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllCards : MonoBehaviour
{
    [SerializeField] Sprite[] Allcards;
    [SerializeField] Sprite Joker;
    [SerializeField] GameObject[] Card;
    [SerializeField] public Dictionary<int,Sprite> AllCArds;
    [SerializeField] GameObject PlayerCards;
    [SerializeField] GameObject DollyCars;
    public Sprite[] ShowAllRemingcards;
    public int[] SlecetdCardNumbers;

    void Start()
    {
        AllCArds = new Dictionary<int, Sprite>();
        for (int i = 0; i < Allcards.Length; i++)
        {
            AllCArds.Add(i, Allcards[i]);
        }
        settingcards();
        Invoke("PlaerCardsCreating", 1f);
        Invoke("DollyCardsCreating", 1f);
        SettingRemainingCards();
    }

    private void SettingRemainingCards()
    {
        for(int i=0;i<5;i++)
        {
            ShowAllRemingcards[i] = AllCArds[cardnumbers[i]];
        }
    }

    [SerializeField] List<int> cardnumbers = new List<int>();
    void settingcards()
    {
        for (int i = 0; i < 8; i++)
        {
            int index = UnityEngine.Random.Range(0, cardnumbers.Count);
            SlecetdCardNumbers[i] = cardnumbers[index];
            cardnumbers.RemoveAt(index);
        }

    }


    private void PlaerCardsCreating()
    {
        for (int i = 0; i < 4; i++)
        {
            int index = SlecetdCardNumbers[i];
            Card[i].GetComponent<SpriteRenderer>().sprite = Card[i].GetComponent<SpriteRenderer>().sprite = AllCArds[index]; 
            PlayerCards.GetComponent<PlayerCards>().Cards[i]= AllCArds[index];
            PlayerCards.GetComponent<PlayerCards>().Cardnumbers[i] = index;
        }
    }

    Sprite DontUsefulForDolly;
    void DollyCardsCreating()
    {
        for (int i = 0; i < 4; i++)
        {
            int index = SlecetdCardNumbers[4 + i];
            DontUsefulForDolly = AllCArds[index];
            DollyCars.GetComponent<DollyCards>().DollyCardNumbers[i] = index;
            
        }
    }

}
