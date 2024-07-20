using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial1 : MonoBehaviour
{
    private TutorialLevel levelUI;
    public MenuInfo menuInfo;
    public GameObject[] pillars;
    public GameObject bigPillar;

    public int proceed = 0;
    // Start is called before the first frame update
    void Start()
    {
        levelUI = FindObjectsOfType<TutorialLevel>()[0];
        levelUI.ChangeTop("Welcome to Worlds Apart!");
        StartCoroutine(Scroll());

    }

    IEnumerator Scroll() {
        float timer = 0;
        while(timer < 2f) {
            timer+= Time.deltaTime;
            yield return null;
        }
        timer = 0;
        if(PlayerPrefs.HasKey("TutorialDone")) {
            levelUI.ShowControls("Press START to exit tutorial", "Press M to exit tutorial");
        }
        levelUI.ChangeTop("The two of you are stuck in different worlds, unable to interact with each other.");
        while(timer < 5f) {
            timer+= Time.deltaTime;
            yield return null;
        }
        timer = 0;
        levelUI.ChangeTop("Don't worry! You will still be able to affect your friend's world from your own.");
        while(timer < 5f) {
            timer+= Time.deltaTime;
            yield return null;
        }
        timer = 0;
        levelUI.ChangeTop("Now, you must work together to traverse through a world of puzzles");
        while(timer < 5f) {
            timer+= Time.deltaTime;
            yield return null;
        }
        timer = 0;
        levelUI.ChangeTop("and perhaps reunite!");
        while(timer < 2f) {
            timer+= Time.deltaTime;
            yield return null;
        }
        timer = 0;
        levelUI.ChangeTop("Although your worlds seem the same, there are small differences.");
        while(timer < 5f) {
            timer+= Time.deltaTime;
            yield return null;
        }
        timer = 0;
        StartCoroutine(MovePillars());
        levelUI.ShowControls("Press B to jump", "Press SPACE to jump");
        levelUI.ChangeTop("Get to the large pillar.");
        while(proceed != 2) {
            yield return null;
        }
        levelUI.ChangeTop("Your worlds are entangled, meaning a change in one will change the other.");
        while(timer < 5f) {
            timer+= Time.deltaTime;
            yield return null;
        }
        timer = 0;
        levelUI.ChangeTop("These blocks exist in both worlds.");
        while(timer < 5f) {
            timer+= Time.deltaTime;
            yield return null;
        }
        timer = 0;
        levelUI.ChangeTop("However, you can only move the block of your color.");
        while(timer < 5f) {
            timer+= Time.deltaTime;
            yield return null;
        }
        timer = 0;
        StartCoroutine(MoveBig());
        levelUI.ChangeTop("Use the blocks to get to the Warp Zone.");
        levelUI.ShowControls("Press L-Trigger to pick up block", "Press L-Shift to pick up block");
    }

    // Update is called once per frame
    IEnumerator MovePillars() {
        while(pillars[0].transform.position.y < 2) {
            pillars[0].transform.position = pillars[0].transform.position + Vector3.up * Time.deltaTime;
            pillars[1].transform.position = pillars[1].transform.position + Vector3.up * Time.deltaTime;
            yield return null;
        }
        yield return null;
    }

    // Update is called once per frame
    IEnumerator MoveBig() {
        while(bigPillar.transform.position.y > 7) {
            bigPillar.transform.position = bigPillar.transform.position - Vector3.up * Time.deltaTime;
            yield return null;
        }
        yield return null;
    }
}
