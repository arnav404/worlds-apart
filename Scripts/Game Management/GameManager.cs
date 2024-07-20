using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool dead = false;
    private bool done = false;
    private FinishLevel warpZoneP1;
    private FinishLevel warpZoneP2;
    public CheckpointSystem checkpoint;
    public MenuInfo menuInfo;
    private FadeIn fadeIn;

    // Start is called before the first frame update
    void Start()
    {
        warpZoneP1 = GameObject.FindWithTag("FinishP1").GetComponent<FinishLevel>();
        warpZoneP2 = GameObject.FindWithTag("FinishP2").GetComponent<FinishLevel>();
        fadeIn = GameObject.FindWithTag("Fade").GetComponent<FadeIn>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dead) {
            StartCoroutine(Die());
            dead = false;
        }
        if(warpZoneP1.done && warpZoneP2.done && done == false) {
            done = true;
            checkpoint.spawnPoint = new Vector3(0,0.5f,0);
            Scene scene = SceneManager.GetActiveScene();
            if(scene.name == "Tutorial") {
                if(!PlayerPrefs.HasKey("TutorialDone")) {
                    PlayerPrefs.SetFloat("TutorialDone", 1f);
                }
                fadeIn.StartOut("HubWorld");
            }
            int name = int.Parse(scene.name.Substring(1, scene.name.Length-1));
            if(menuInfo.completed[name-1] == false) {
                menuInfo.completed[name-1] = true;
                menuInfo.maxLevel += 1;
            }

            if(name == 14) {
                fadeIn.StartOut("World 2");
            }
            else if(name % 10 != 0) {
                fadeIn.StartOut("L"+(name+1));
            } else {
                fadeIn.StartOut("World "+(name/10+1));
            }
        }
    }

    IEnumerator Die() {
        yield return new WaitForSeconds(0.05f);
        fadeIn.StartOut(SceneManager.GetActiveScene().name);
    }
}
