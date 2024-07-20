using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{

    private GameObject connectedBlock;
    private Vector3 originalPos;
    private Vector3 connectedOriginalPos;
    // Start is called before the first frame update
    void Start()
    {
        if(this.gameObject.name == "MissileBlue(Clone)") {
            connectedBlock = GameObject.Find("P1");
        } else {
            connectedBlock = GameObject.Find("P2");
        }
        originalPos = transform.position;
        connectedOriginalPos = connectedBlock.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = originalPos+(connectedBlock.transform.position-connectedOriginalPos);
    }
}
