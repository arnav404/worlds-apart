using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldJumpPowerup : MonoBehaviour
{

    public AudioSource ding;

    void OnTriggerEnter(Collider col) {
        print("COL");
        if(col.gameObject.name == this.gameObject.name.Substring(0, 2)) {
            ding.Play();
            this.gameObject.GetComponent<ParticleSystem>().Stop();
            this.gameObject.GetComponent<Collider>().enabled = false;
            StartCoroutine(WJ(col));
        }
    }

    IEnumerator WJ(Collider col) {
        yield return new WaitForSeconds(1f);
        WorldJump wj = col.gameObject.GetComponent<WorldJump>();
        wj.powerupGained();
        Destroy(this.gameObject);
    }
}
