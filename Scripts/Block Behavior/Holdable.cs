using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Holdable : MonoBehaviour
{
    private bool holding;
    private GameObject player;
    private Rigidbody rb;
    private Rigidbody playerRB;
    private float grabDistance = 1.5f;
    public string name;
    // Start is called before the first frame update
    void Start()
    {
        holding = false;
        player = GameObject.Find(name);
        playerRB = player.GetComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();
    }

    public void Hold() {
        print(holding);
        if(player != null) {
            if(holding == true) {
                this.rb.isKinematic = false;
                this.rb.velocity = playerRB.velocity;
                this.gameObject.transform.SetParent(null);
                rb.AddForce((player.transform.forward + Vector3.up) * 4f, ForceMode.Impulse);
                holding = false;
            }
            else if((player.transform.position-transform.position).magnitude < grabDistance) {
                if(holding == false) {
                    this.gameObject.transform.SetParent(player.transform);
                    holding = true;
                    this.rb.isKinematic = true;
                    transform.localPosition = Vector3.up * 2.2f;
                }
            }
        }

    }
}
