using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectedBlock : MonoBehaviour
{
    
    public GameObject connectedBlock;
    private Vector3 originalPos;
    private Vector3 connectedOriginalPos;
    private Vector3 originalRot;
    private Vector3 connectedOriginalRot;
    private Rigidbody rb;
    private Rigidbody connectedRb;

    // Start is called before the first frame update
    void Start()
    {
        originalRot = transform.eulerAngles;
        connectedOriginalRot = connectedBlock.transform.eulerAngles;
        rb = GetComponent<Rigidbody>();
        connectedRb = connectedBlock.GetComponent<Rigidbody>();
        connectedOriginalPos = connectedRb.position;
        originalPos = rb.position;
    }

    // Update is called once per frame
    void Update()
    {
        connectedBlock.transform.position = transform.position;
        connectedBlock.transform.eulerAngles = connectedOriginalRot+(transform.eulerAngles-originalRot);
    }
}
