using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishingBlock : MonoBehaviour
{

    private Material mat;
    private Collider col;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        col = GetComponent<Collider>();
        turnOff();
    }

    public void turnOn() {
        col.enabled = true;
        Color color = mat.color;
        color.a = 1;
        mat.color = color;
    }

    public void turnOff() {
        print(mat.name);
        col.enabled = false;
        Color color = mat.color;
        color.a = 0.6f;
        mat.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
