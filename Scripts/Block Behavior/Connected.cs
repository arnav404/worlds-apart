using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connected : MonoBehaviour
{
    public GameObject connectedBlock;
    private Rigidbody connectedRB;
    private Rigidbody rb;
    public int channel = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        connectedRB = connectedBlock.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(channel == 0) {
            connectedRB.isKinematic = rb.isKinematic;
            connectedRB.velocity = rb.velocity;
        }
        else
        {
            rb.isKinematic = connectedRB.isKinematic;
            rb.velocity = connectedRB.velocity;
        }
    }
}
