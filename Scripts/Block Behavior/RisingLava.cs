using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingLava : MonoBehaviour
{

    [SerializeField] private float rate = 0.05f;

    void OnTriggerEnter(Collider collision) {
        if(collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<PlayerMovement>().Die();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(0, rate*Time.deltaTime, 0);
    }
}
