using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard_1 : MonoBehaviour {

    /// <summary>
    /// This pretty much covers the basic guard AI, obviously later it will actually interact with the player I.e. Imprison them etc.
    /// The Guard slows down when getting close to the player, which can be improved upon later - however this is currently a little 
    /// script to base further ventures on - a foundation.
    /// </summary>

    public BoxCollider2D sightCollider, interactCollider;
    public Transform target;
    Vector3 GuardVelocity;

    public float MAX_ColliderSizeX, MAX_ColliderSizeY, MAX_OffsetX;  // Improves flexibility instead of being "hard-coded"
    public float G_Speed;
    float OG_LocX, OG_LocY;

    bool isPlayerSpotted = false;

    void Start(){
        GuardVelocity = Vector2.zero;
        OG_LocX = transform.position.x;
        OG_LocY = transform.position.y;
    }

    void Update(){

        if (isPlayerSpotted) {
            sightCollider.size = new Vector2(MAX_ColliderSizeX, MAX_ColliderSizeY);
            sightCollider.offset = new Vector2(MAX_OffsetX, 0);

            GuardVelocity = new Vector2((transform.position.x - target.position.x) * G_Speed, (transform.position.y - target.position.y) * G_Speed);
            GetComponent<Rigidbody2D>().velocity = -GuardVelocity;
        }
        else {
            sightCollider.size = new Vector2(.8f, .16f);
            sightCollider.offset = new Vector2(.32f, 0);
            GuardVelocity = new Vector2((transform.position.x - OG_LocX) * G_Speed, (transform.position.y - OG_LocY) * G_Speed);
            GetComponent<Rigidbody2D>().velocity = -GuardVelocity;
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Player")) {
            isPlayerSpotted = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.CompareTag("Player")) {
            isPlayerSpotted = false;
        }
    }
}