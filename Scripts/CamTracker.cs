using UnityEngine;
using System.Collections;

public class CamTracker : MonoBehaviour {
    /* Scripts Job:
    *  This script will essentially control everything that the Surv. Cam does in the game
    *  at the moment this will only cover the camera following the players movements when it is in the camera radius
    *  but other ideas such as alerting guards of suspicious activity etc can be put in at a later date.
    */

    public float smooth = 5.0f;
    public float tiltAngle = 50.0f;
    public bool inRange = false; // Public for debugging purposes
    void Start () {
	
	}

	void Update () {
        // Currently testing out some code to get a general concept of what is going to happen; weed out any potential problems.
        float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;


        while (inRange) {
            Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        }

    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            // Face Player
            inRange = true;
        }
        else {
            inRange = false;
        }
    }
}
