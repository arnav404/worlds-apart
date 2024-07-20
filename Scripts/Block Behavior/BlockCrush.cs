using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCrush : MonoBehaviour
{

    private Rigidbody rb;

    void Start() {
        rb = this.gameObject.transform.parent.gameObject.GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void OnTriggerEnter(Collider col) {
        if(col.gameObject.CompareTag("Player")) {
            if(rb.velocity.y < -0.1f)
                col.gameObject.GetComponent<PlayerMovement>().Die();
        }
    }
}
