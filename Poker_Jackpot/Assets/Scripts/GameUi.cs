using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUi : MonoBehaviour
{
    [SerializeField] GameObject GameCanvas;
    [SerializeField] GameObject AllCards;
    
    void Start()
    {
        Invoke("GameCanvasFunction", 0.5f);
    }

    void GameCanvasFunction()
    {
        GameCanvas.SetActive(true);
        AllCards.SetActive(true);
        
    }
}
