using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform player;
    [SerializeField] private string p;
    private Animator anim;
    private float speed = 3f;
    private float attackRadius = 4f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find(p).transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null) {
            if((player.position - transform.position).magnitude < attackRadius) {
                transform.position -= Vector3.Normalize(transform.position - player.position) * Time.deltaTime * speed;
                transform.LookAt(player);
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
                anim.SetFloat("Speed", 1);
            } else {
                anim.SetFloat("Speed", 0);
            }
        }
    }
}
