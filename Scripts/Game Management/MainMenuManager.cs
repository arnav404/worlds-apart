using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public MenuInfo menu;
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(Screen.width, Screen.width/2, true);
        GameObject S = GameObject.Find("S");
        GameObject C = GameObject.Find("C");
        if(!PlayerPrefs.HasKey("TutorialDone")) {
            C.transform.localScale = Vector3.zero;
        } else {
            S.transform.localScale = Vector3.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
