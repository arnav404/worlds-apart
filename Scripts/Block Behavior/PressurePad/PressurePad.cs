using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{
    public Material On;
    public Material Off;

    private string name;
    public GameObject pad;


    public VanishingBlock[] blocks;

    public void turnOn() {
        pad.GetComponent<MeshRenderer>().material = On;
        for(int i = 0; i < blocks.Length; i++) {
            blocks[i].turnOn();
        }
    }

    public void turnOff() {
        pad.GetComponent<MeshRenderer>().material = Off;
        for(int i = 0; i < blocks.Length; i++) {
            blocks[i].turnOff();
        }
    }
}
