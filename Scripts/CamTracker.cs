using UnityEngine;
using System.Collections;

public class CamTracker : MonoBehaviour {
    /* Scripts Job:
    *  This script will essentially control everything that the Surveillance Cam does in the game
    *  at the moment this will only cover the camera following the players movements when it is in the camera radius
    *  and alerting/spawning guards at a designated spawn point(s).
    */
    
    public bool inRange = false; // Public for debugging purposes

    public Transform target, guardSpawn;
    public GameObject guardFab;

    public int MAX_GUARD_SPAWN;

    private int spawnedCount = 0;

  //  private Animator animator; Setting this up for adding in a ! above the camera



    void Start() {
    //    animator = GetComponent<Animator>();
    }

    void Update () {

        if(inRange) {
            transform.right = target.position - transform.position;

            if(spawnedCount != MAX_GUARD_SPAWN){
                spawnedCount++; 
                Instantiate(guardFab, guardSpawn.position, Quaternion.identity);
            }

        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            inRange = true;
          //animator.SetTrigger("isSpotted");
        }else {
            inRange = false; // Ensure that this is set to false.
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.CompareTag("Player")) {
            inRange = false;
        //  animator.SetTrigger("notSpotted");
        }
    }
}