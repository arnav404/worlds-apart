using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{

    public GameObject deathEffect;
    public GameObject connected;
    
    public GameObject ghostBlockPrefab;
    public GameObject otherGhostPrefab;

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.name == "BlockP1" || collision.gameObject.name == "BlockP2") {
            if(collision.contacts[0].point.y > transform.position.y + 0.9f) {
                if(collision.gameObject.CompareTag("Player"))
                    collision.gameObject.GetComponent<PlayerMovement>().DoJump(1f);
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                GameObject theBlock = Instantiate(ghostBlockPrefab, transform.position+Vector3.up*0.5f, Quaternion.identity);
                GameObject otherGhost = Instantiate(otherGhostPrefab, connected.transform.position, Quaternion.identity);
                
                otherGhost.GetComponent<EnemyCollision>().connected = theBlock;

                Destroy(connected);
                Destroy(this.gameObject);
            } else {
                collision.gameObject.GetComponent<PlayerMovement>().Die();
            }
        }
    }
}
