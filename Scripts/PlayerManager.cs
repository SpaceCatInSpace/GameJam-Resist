using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    /* ** Variables ** */
    public bool facingRight = true;
    public bool isBlending = false;
    public float MAX_WALK_SPEED, MAX_RUN_SPEED, JUMP_HEIGHT;
    float MAX_SPEED;

    public Transform groundCheck;

    bool isGround = false;
    Vector3 PlayerVelocity;
    /* ** ** *** ** ** */

    void Awake(){

    }

    // Use this for initialization
    void Start(){
        PlayerVelocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update(){

        isGround = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        /* ** Horizontal Inputs ** */

        // Cache the Horizontal Input
        float HorCa = Input.GetAxis("Horizontal");

        // Is the Player running or walking?
        if( (Input.GetKey(KeyCode.LeftShift) && (isGround)) ) {
            MAX_SPEED = MAX_RUN_SPEED;
        }else {
            MAX_SPEED = MAX_WALK_SPEED;
        }

        // Player Velocity on X Axis
        PlayerVelocity.x = Input.GetAxis("Horizontal") * MAX_SPEED * Time.deltaTime;

        if(HorCa > 0 && !facingRight) {
            Flip();
        }
        else if(HorCa < 0 && facingRight) {
            Flip();
        }

        /* ********************** */
        




        /* ** Vertical Input ** */

        if (Input.GetKey(KeyCode.W) && (isGround)) {
            PlayerVelocity.y = JUMP_HEIGHT;
            isGround = false;
        }
        else {
            PlayerVelocity.y = GetComponent<Rigidbody2D>().velocity.y;
        }

        /* ******************** */
    }

    void FixedUpdate() {
        GetComponent<Rigidbody2D>().velocity = PlayerVelocity;
    }

    /* ** Flipping player transform ** */
    void Flip() { 
        facingRight = !facingRight;

        // Multiply players x local scale by -1
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
