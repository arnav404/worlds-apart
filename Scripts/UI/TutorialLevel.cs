using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialLevel : MonoBehaviour
{
    private GameObject TopBox;
    private GameObject P1Box;
    private GameObject P2Box;

    public TextMeshProUGUI TopText;
    public TextMeshProUGUI P1Text;
    public TextMeshProUGUI P2Text;

    void Start() {
        TopBox = GameObject.FindWithTag("TopText");
        P1Box = GameObject.FindWithTag("P1Text");
        P2Box = GameObject.FindWithTag("P2Text");
    }

    public void ChangeTop(string s) {
        TopText.text = s;
    }

    public void ShowControls(string p1, string p2) {
        P1Box.transform.localScale = new Vector3(1f,1f,1f);
        P2Box.transform.localScale = new Vector3(1f,1f,1f);
        P1Text.text = p1;
        P2Text.text = p2;
    }

    public void HideControls() {
        P1Box.transform.localScale = new Vector3(0,0,0);
        P2Box.transform.localScale = new Vector3(0,0,0);
    }

}
