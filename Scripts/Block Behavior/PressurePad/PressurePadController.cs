using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePadController : MonoBehaviour
{

    public string name;
    public PressurePad pad;
    private int numOfTriggers = 0;
    
    void OnTriggerEnter(Collider col) {
        if(col.gameObject.name == name || col.gameObject.name == "Block"+name) {
            numOfTriggers += 1;
            
            if(numOfTriggers == 1) {
                pad.turnOn();
            }
        }
    }

    void OnTriggerExit(Collider col) {
        if(col.gameObject.name == name || col.gameObject.name == "Block"+name) {
            numOfTriggers -= 1;
            
            if(numOfTriggers == 0) {
                pad.turnOff();
            }
        }
    }

}
