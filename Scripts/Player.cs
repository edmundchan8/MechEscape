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

    //Access to stage clear
    GameObject stageClearGO;
    StageClear myStageClear;

    void Start()
    {

        PlayerMoveDirection = Vector2.right;

        MyRigidbody2D = GetComponent<Rigidbody2D>();
        GravityStore = MyRigidbody2D.gravityScale;

        playerCollider = GetComponent<Collider2D>();

        stageClearGO = GameObject.Find("StageClear");
        myStageClear = stageClearGO.GetComponent<StageClear>();
    }
	
	void Update () {
        //value of ClimbingSpeed can control how fast we climb up ladder
        //if you want to use it.
        //it is being accessed from the Climbing script

        if (CanWalk) {
        SpeedStore = Speed;
            transform.Translate(PlayerMoveDirection * Speed * Time.deltaTime);
        }
        
        //TODO this is hardcoded into script, not good, something to fix later?
        //this makes player face right direction when walking
        if (IsFacingRight) { transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z); }
        if (!IsFacingRight) { transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z); }

        Grounded = Physics2D.IsTouchingLayers(playerCollider, groundLayer);

        //Player moves depending of if they haven't cleared stage
         if (myStageClear.ShowText) { Speed = 0; }
    }
}
