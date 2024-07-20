using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{

    private float dropTime = 0.5f;
    [SerializeField] private string name;
    private Rigidbody rb;

    void Start() {
        rb = this.gameObject.transform.parent.gameObject.GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider col) {
        if(col.gameObject.CompareTag("Player")) {
            if(col.gameObject.name == name)
                StartCoroutine(Drop());
        }
    }

    IEnumerator Drop() {
        yield return new WaitForSeconds(dropTime);
        rb.useGravity = true;
    }
}
