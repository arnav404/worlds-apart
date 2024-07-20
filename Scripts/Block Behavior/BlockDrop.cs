using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDrop : MonoBehaviour
{
    private Transform t;
    private Vector3 pos;
    private Vector3 dropPos;
    private Rigidbody rb;

    public Connected connection;
    private bool dropping = false;
    // Start is called before the first frame update
    void Start()
    {
        t = this.gameObject.transform.parent.gameObject.transform;
        rb = t.gameObject.GetComponent<Rigidbody>();
        pos = rb.position;
        dropPos = rb.position - Vector3.up*0.05f;
        connection = t.gameObject.GetComponent<Connected>();
        if(connection != null) {
            connection.connectedBlock.GetComponentInChildren<BlockDrop>().connection = connection;
        }
    }


    IEnumerator Drop() {
        rb.isKinematic = false;
        dropping = true;
        while(rb.position.y > dropPos.y) {
            rb.velocity -= Vector3.up * 0.02f;
            yield return new WaitForSeconds(0.01f);
        }
        while(rb.position.y < pos.y) {
            rb.velocity += Vector3.up * 0.1f;
            yield return new WaitForSeconds(0.01f);
        }
        dropping = false;
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;
    }

    void OnTriggerEnter(Collider col) {
        print("ENTER");
        if(col.gameObject.CompareTag("Player")) {
            if(col.gameObject.name == "P1") {
                connection.channel = 0;
            } else {
                connection.channel = 1;
            }
            if(!dropping)
                StartCoroutine(Drop());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
