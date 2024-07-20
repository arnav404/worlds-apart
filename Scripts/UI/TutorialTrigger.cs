using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    private string[] objects;
    private Tutorial1 tutorial;

    void Start() {
        tutorial = GameObject.FindWithTag("GameManager").GetComponent<Tutorial1>();
    }

    void OnTriggerEnter(Collider col) {
        if(col.gameObject.name == "P1" || col.gameObject.name == "P2") {
            tutorial.proceed+=1;
        }
    }
    void OnTriggerExit(Collider col) {
        if(col.gameObject.name == "P1" || col.gameObject.name == "P2") {
            tutorial.proceed-=1;
        }
    }
}
