using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DollyChat : MonoBehaviour
{
    [SerializeField] GameObject PlayerNameText;
    void Start()
    {
        gameObject.GetComponent<Text>().text = "...";
        Invoke("SettingPlayerName", 1f);
    }

    private void SettingPlayerName()
    {
        gameObject.GetComponent<Text>().text = "Hey " + PlayerNameText.GetComponent<Text>().text + "!...I'm Dolly,Everyone call me as texas Dolly...";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
