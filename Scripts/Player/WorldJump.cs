using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class WorldJump : MonoBehaviour
{

    [SerializeField] GameObject effect;
    [SerializeField] GameObject missile;

    private GameObject other;
    private CinemachineFreeLook cam;
    private FreeLookAddOn look;
    private Transform otherCam;
    private Transform thisCam;
    private PlayerMovement pm;
    private Rigidbody rb;

    private Vector3 oldPos;
    private Vector3 newPos;

    private int otherLayer;
    private int thisLayer;

    public bool canWorldJump = false;
    public GameObject worldJumpPortal;

    public static bool jumped = false;

    public void powerupGained() {
        canWorldJump = true;
        worldJumpPortal.GetComponent<ParticleSystem>().Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        pm = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody>();
        jumped = false;
        worldJumpPortal.GetComponent<ParticleSystem>().Stop();
        if(this.gameObject.name == "P1") {
            otherLayer = LayerMask.NameToLayer("P2");
            thisLayer = LayerMask.NameToLayer("P1");

            other = GameObject.Find("P2");
            cam = GameObject.Find("CamP1").GetComponent<CinemachineFreeLook>();
            otherCam = GameObject.Find("MCP2").transform;
            thisCam = GameObject.Find("MCP1").transform;
        } else {
            otherLayer = LayerMask.NameToLayer("P1");
            thisLayer = LayerMask.NameToLayer("P2");
            other = GameObject.Find("P1");
            cam = GameObject.Find("CamP2").GetComponent<CinemachineFreeLook>();
            otherCam = GameObject.Find("MCP1").transform;
            thisCam = GameObject.Find("MCP2").transform;
        }
        look = cam.GetComponent<FreeLookAddOn>();
    }

    public void OnJump(InputAction.CallbackContext ctx) {
        if(jumped == false && canWorldJump) {
            canWorldJump = false;
            worldJumpPortal.GetComponent<ParticleSystem>().Stop();
            StartCoroutine(Back());
        }
    }

    IEnumerator Back() {
        GameObject m = Instantiate(missile, transform.position + Vector3.up * 0.5f, Quaternion.identity);
        cam.Follow = m.transform;
        cam.LookAt = m.transform;
        this.gameObject.layer = otherLayer;
        LayerMask thisGround = pm.groundLayer;
        pm.groundLayer = other.GetComponent<PlayerMovement>().groundLayer;
        foreach (Transform child in transform)
         {
            child.gameObject.layer = otherLayer;
         }
        look.moveable = false;
        oldPos = transform.position;
        transform.position = other.transform.position;
        newPos = transform.position;
        Instantiate(effect, transform.position, Quaternion.identity);
        pm.cam = otherCam;
        float time = Random.Range(3f, 10f);
        jumped = true;
        yield return new WaitForSeconds(time);
        transform.position = oldPos - (newPos-transform.position);
        jumped = false;
        cam.Follow = transform;
        cam.LookAt = transform;
        this.gameObject.layer = thisLayer;
        pm.groundLayer = thisGround;
        foreach (Transform child in transform)
         {
            child.gameObject.layer = thisLayer;
         }
        look.moveable = true;
        pm.cam = thisCam;
        this.gameObject.transform.SetParent(null);
        rb.isKinematic = false;
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(m);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
