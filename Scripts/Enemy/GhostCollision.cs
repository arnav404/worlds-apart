using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision) {
        print(collision.gameObject.tag);
        if(collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<PlayerMovement>().Die();
        }
    }
}
