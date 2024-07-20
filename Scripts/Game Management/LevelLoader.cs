using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public string name;
    private string player;
    public bool inRadius;

    private FadeIn fadeIn;
    private HubUIManager UIM;
    private bool active = false;

    public LevelLoader connectedLevelLoader;

    private P1Input controls;

    void Start() {
        controls = new P1Input();
        controls.Player.Continue.Enable();
        controls.Player.Continue.performed += _ => OnHold();

        player = this.gameObject.name.Substring(0, 2);

        fadeIn = GameObject.FindWithTag("Fade").GetComponent<FadeIn>();

        UIM = GameObject.FindWithTag("GameManager").GetComponent<HubUIManager>();
    }

    void OnDisable() {
        controls.Player.Hold.Disable();
    }

    void OnTriggerEnter(Collider col) {
        if(col.gameObject.name == player)
            inRadius = true;
    }

    void OnTriggerExit(Collider col) {
        if(col.gameObject.name == player)
            inRadius = false;
    }

    public void OnHold() {
        if(inRadius && connectedLevelLoader.inRadius) {
            fadeIn.StartOut(name);
        }
    }

    void Update() {
        if(inRadius && connectedLevelLoader.inRadius) {
            active = true;
            UIM.Show(name);
        } else if(active == true) {
            active = false;
            UIM.Hide();
        }
    }

}
