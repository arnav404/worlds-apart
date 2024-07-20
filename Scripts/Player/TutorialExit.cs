using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialExit : MonoBehaviour
{

    public MenuInfo menuInfo;
    private FadeIn fadeIn;

    void Start() {
        fadeIn = GameObject.FindWithTag("Fade").GetComponent<FadeIn>();
    }

    public void OnExitTutorial(InputAction.CallbackContext ctx) {
        if(menuInfo.maxLevel != 0)
            fadeIn.StartOut("HubWorld");
    }
}
