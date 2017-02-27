using UnityEngine;
using System.Collections;

public class CamTracker : MonoBehaviour {
    /* Scripts Job:
    *  This script will essentially control everything that the Surv. Cam does in the game
    *  at the moment this will only cover the camera following the players movements when it is in the camera radius
    *  but other ideas such as alerting guards of suspicious activity etc can be put in at a later date.
    */
	
    public bool inRange = false; // Public for debugging purposes
    public Transform target;
	
    void Start () {
	}

	void Update () {
        // Currently testing out some code to get a general concept of what is going to happen; weed out any potential problems.
        if(inRange) {
            transform.right = target.position - transform.position;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            inRange = true;
        }else {
            inRange = false; // Ensure that this is set to false.
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.CompareTag("Player")) {
            inRange = false;
        }
    }
}
