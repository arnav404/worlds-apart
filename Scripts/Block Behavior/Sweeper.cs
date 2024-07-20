using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sweeper : MonoBehaviour
{
    [SerializeField] private Vector3 direction;
    private Rigidbody rb;
    [SerializeField] private float sweepDistance = 10f;
    [SerializeField] private float sweepTime = 3f;

    private Vector3[] togglePoints = {Vector3.zero, Vector3.zero};

    public bool moves = false;

    void Start() {
        rb = GetComponent<Rigidbody>();
        togglePoints[0] = transform.position-direction*sweepDistance/2;
        togglePoints[1] = transform.position+direction * sweepDistance/2;
        StartCoroutine(Back());
    }

    IEnumerator Back() {
        print("BACK");
        while(true) {
            direction = - direction;
            rb.velocity=direction*sweepTime;
            yield return new WaitForSeconds(sweepTime);
        }
    }
}
