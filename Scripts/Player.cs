using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float Speed;
    public float ClimbingSpeed;
    
    public bool IsFacingRight = true;
    public bool CanWalk = true;

    public bool Grounded;

    Collider2D playerCollider;
    public LayerMask groundLayer;

    public Rigidbody2D MyRigidbody2D;
    public float GravityStore;
    public float SpeedStore;

    public Vector2 PlayerMoveDirection;

    void Start()
    {

        PlayerMoveDirection = Vector2.right;

        MyRigidbody2D = GetComponent<Rigidbody2D>();
        GravityStore = MyRigidbody2D.gravityScale;
        SpeedStore = Speed;

        playerCollider = GetComponent<Collider2D>();
    }
	
	void Update () {
        
        if (CanWalk) {
            transform.Translate(PlayerMoveDirection * Speed * Time.deltaTime);
        }
        
        //TODO this is hardcoded into script, not good, something to fix later?
        //this makes player face right direction when walking
        if (IsFacingRight) { transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z); }
        if (!IsFacingRight) { transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z); }

        Grounded = Physics2D.IsTouchingLayers(playerCollider, groundLayer);
    }
}
