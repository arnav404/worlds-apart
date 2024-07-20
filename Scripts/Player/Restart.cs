using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public CheckpointSystem checkpoint;
    public GameObject player;
    private FadeIn fadeIn;
    private string menuName;
    public MenuInfo menuInfo;
    // Start is called before the first frame update
    void Start()
    {
        fadeIn = GameObject.FindWithTag("Fade").GetComponent<FadeIn>();
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "Tutorial" && PlayerPrefs.HasKey("TutorialDone")) {
            menuName = "HubWorld";
        } else if(scene.name != "Tutorial") {
            int name = int.Parse(scene.name.Substring(1, scene.name.Length-1));
            int world = (name-1)/10+1;
            menuName = "World "+world;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTP(InputAction.CallbackContext ctx) {
        if(ctx.performed) {
            if(player.name == "P1") {
                player.transform.position = checkpoint.spawnPoint;
            } else {
                player.transform.position = checkpoint.spawnPoint;
            }
        }
    }

    public void OnRestart(InputAction.CallbackContext ctx) {
        fadeIn.StartOut(SceneManager.GetActiveScene().name);
    }

    public void OnMenu(InputAction.CallbackContext ctx) {
        if(menuName != null) {
            fadeIn.StartOut(menuName);
        }
    }
    
}
