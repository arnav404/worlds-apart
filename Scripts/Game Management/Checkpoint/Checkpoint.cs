using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Material def;
    public Material glowRed;
    public Material glowBlue;
    public GameObject blueGlowPlatform;
    public GameObject redGlowPlatform;

    public void turnOn(string player) {
        if(player == "P1") {
            blueGlowPlatform.GetComponent<MeshRenderer>().material = glowBlue;
        } else {
            redGlowPlatform.GetComponent<MeshRenderer>().material = glowRed;
        }
    }

    public void turnOff(string player) {
        if(player == "P1") {
            blueGlowPlatform.GetComponent<MeshRenderer>().material = def;
        } else {
            redGlowPlatform.GetComponent<MeshRenderer>().material = def;
        }
    }
}
