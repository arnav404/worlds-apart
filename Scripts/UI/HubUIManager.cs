using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HubUIManager : MonoBehaviour
{
    private GameObject TopBox;
    private GameObject P1Box;
    private GameObject P2Box;

    public TextMeshProUGUI TopText;

    // Start is called before the first frame update
    void Start()
    {
        TopBox = GameObject.FindWithTag("TopText");
        P1Box = GameObject.FindWithTag("P1Text");
        P2Box = GameObject.FindWithTag("P2Text");
    }

    public void Show(string name) {
        TopText.text = "Enter "+name;
        TopBox.transform.localScale = new Vector3(1f,1f,1f);
        P1Box.transform.localScale = new Vector3(1f,1f,1f);
        P2Box.transform.localScale = new Vector3(1f,1f,1f);
    }

    public void Hide() {
        TopBox.transform.localScale = new Vector3(0,0,0);
        P1Box.transform.localScale = new Vector3(0,0,0);
        P2Box.transform.localScale = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
