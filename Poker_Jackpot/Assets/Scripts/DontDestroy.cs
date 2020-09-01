using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DontDestroy : MonoBehaviour
{
    public string Name; 
    public bool PlayerNameBoll = false;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") && !PlayerNameBoll)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Text>().text = Name;
            PlayerNameBoll = true;
        }
    }

}
