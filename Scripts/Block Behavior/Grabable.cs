using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabable : MonoBehaviour
{
    private Transform p1;
    public string name;

    // Start is called before the first frame update
    void Start()
    {
        p1 = GameObject.Find(name).transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(p1 != null) {
            if((p1.position-transform.position).magnitude < 1.5f) {
                if(Input.GetKey(KeyCode.LeftShift)) {
                    transform.parent = p1.transform;
                } else {
                    transform.parent = null;
                }
            } else {
                transform.parent = null;
            }
        }
    }
}
