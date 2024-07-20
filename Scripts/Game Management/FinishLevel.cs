using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{

    public bool done = false;

    void OnTriggerEnter(Collider col) {
        if(col.gameObject.name == "P1" || col.gameObject.name == "P2") {
            done = true;
        }
    }

    void OnTriggerExit(Collider col) {
        if(col.gameObject.name == "P1" || col.gameObject.name == "P2") {
            done = false;
        }
    }
}
