using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostRotate : MonoBehaviour
{

    private Transform cam;
    public string name;

    void Start() {
        cam = GameObject.Find(name).transform;
        this.transform.position = this.transform.position+Vector3.up*0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(cam.position + Vector3.up*10f);
    }
}
