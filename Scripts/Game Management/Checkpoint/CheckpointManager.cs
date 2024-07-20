using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    //State of checkpoint
    private int isOn = 0;
    private Vector3 cpPosition;
    private Checkpoint checkpoint;
    public CheckpointSystem cm;

    void Start() {
        checkpoint = GetComponent<Checkpoint>();
        cpPosition = this.gameObject.transform.parent.transform.position;
        if(cm.spawnPoint == cpPosition) {
            checkpoint.turnOn("P1");
            checkpoint.turnOn("P2");
        }
    }
    
    void OnTriggerEnter(Collider col) {
        if(col.gameObject.CompareTag("Player") && cm.spawnPoint != cpPosition) {
            isOn+=1;
            checkpoint.turnOn(col.gameObject.name);
            if(isOn == 2) {
                cm.spawnPoint = cpPosition;
            }
        }
    }

    void OnTriggerExit(Collider col) {
        if(col.gameObject.CompareTag("Player") && cm.spawnPoint != cpPosition) {
            isOn-=1;
            checkpoint.turnOff(col.gameObject.name);
        }
    }
}
