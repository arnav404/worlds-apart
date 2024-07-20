using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSelect : MonoBehaviour
{
    private FadeIn fadeIn;
    private GameObject Fade;

    // Start is called before the first frame update
    void Start()
    {
        Fade = GameObject.FindWithTag("Fade");
        fadeIn = Fade.GetComponent<FadeIn>();
    }

    public void OnSelect(string name) {
        fadeIn.StartOut(name);
    }

}
