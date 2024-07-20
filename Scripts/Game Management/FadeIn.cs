using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeIn : MonoBehaviour
{
    private GameObject Fade;
    private Color FadeColor;
    private AudioSource music;

    private bool fading = false;

    // Start is called before the first frame update
    void Start()
    {
        Fade = GameObject.FindWithTag("Fade");
        music = GameObject.FindWithTag("MainCamera").GetComponent<AudioSource>();
        FadeColor = Fade.GetComponent<RawImage>().color;
        StartCoroutine(In());
    }

    public void StartIn() {
        StartCoroutine(In());
    }

    public void StartOut(string name) {
        if(!fading) {
            StartCoroutine(Out(name));
        }
    }

    IEnumerator In() {
        float fadeAmount = 1f;
        while(fadeAmount > -0.2f) {
            music.volume = 1.0f - fadeAmount;
            Color newColor = new Color(FadeColor.r, FadeColor.g, FadeColor.b, fadeAmount);
            Fade.GetComponent<RawImage>().color = newColor;
            fadeAmount -= 1.5f * Time.deltaTime;
            yield return null;
        }
        Fade.transform.localScale = new Vector3(0,0,0);
    }

    IEnumerator Out(string name) {
        fading = true;
        Fade.transform.localScale = new Vector3(1f,1f,1f);
        float fadeAmount = 0f;
        while(fadeAmount < 1.2f) {
            music.volume = 1.0f - fadeAmount;
            fadeAmount += 1.5f * Time.deltaTime;
            Color newColor = new Color(FadeColor.r, FadeColor.g, FadeColor.b, fadeAmount);
            Fade.GetComponent<RawImage>().color = newColor;
            yield return null;
        }
        SceneManager.LoadScene(name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
