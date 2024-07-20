using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player")
            other.transform.SetParent(transform.parent);
    }

    void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player")
            other.transform.SetParent(null);
    }
}
