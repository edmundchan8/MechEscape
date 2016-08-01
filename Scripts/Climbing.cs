using UnityEngine;
using System.Collections;

public class Climbing : MonoBehaviour {

    //Access to player
    GameObject PlayerGO;
    Player myPlayer;
    //hardcoded to fix climbing speed
    public float speedHolder;

    //Access to IgnoreCollider
    IgnoreCollider myIgnoreCollider;

    public bool Up;

    //timer to say when can climb
    float canClimb;
    public float TimeToClimb;

    //bool to control animation for climbing
    public bool IsClimbing;

    //Animation to play climbing
    public Animator myAnimator;


    void Start() {
        PlayerGO = GameObject.FindGameObjectWithTag("Player");
        myPlayer = PlayerGO.GetComponent<Player>();
        myIgnoreCollider = PlayerGO.GetComponent<IgnoreCollider>();
        IsClimbing = false;

        myAnimator = transform.GetChild(0).GetComponent<Animator>();
    }

    void Update() {

    }

    void OnTriggerStay2D(Collider2D myCol)
    {

        if (Time.time > canClimb)
        {
            //if hit the ladder, climb up/down ladder
            if (myCol.name == "LadderBody")
            {
                ClimbingLadder();
            }
        }
    }

    //this is where, when player leaves the ladder, climbing is false and they start walking again
    void OnTriggerExit2D(Collider2D myCol)
    {
        //this causes issues
        if (myCol.name == "LadderBody")
        {
            myAnimator.SetBool("IsClimbing", false);
            myIgnoreCollider.IgnoreGroundCollider(false);
            myPlayer.MyRigidbody2D.gravityScale = myPlayer.GravityStore;
            myPlayer.Speed = myPlayer.SpeedStore;
            if (myPlayer.IsFacingRight) { myPlayer.PlayerMoveDirection = Vector2.right; }
            else { myPlayer.PlayerMoveDirection = Vector2.left; }
        }
    }

    void ClimbingLadder()
    {

        myAnimator.SetBool("IsClimbing", true);
        myIgnoreCollider.IgnoreGroundCollider(true); //so we can travel through the floor
        myPlayer.MyRigidbody2D.gravityScale = 0f;
        if (Up) { ClimbUp(); }
        else if (Up == false) { ClimbDown(); }
        //You could use the code below to set the speed of climbing
        //but you will need to set the climbing speed from the player script
        //myPlayer.Speed = myPlayer.ClimbingSpeed;
        
    }

    void SetCanClimbTime() {
        canClimb = Time.time + TimeToClimb;
    }

    void ClimbUp()
    {
        //hold current speed, especially if player 
        speedHolder = myPlayer.Speed;
        //this is hard coded, but in the changeWalkdirection, by using * -1 to change walking direction, 
        //it causes the player speed to be -3, and go down when it hits the ladder
        //temporarily, I will save the speed before the player moves up
        //and hard code the player speed so that they will go up by speed of 3
        myPlayer.Speed = 3; 
        myPlayer.PlayerMoveDirection = Vector2.up;
    }

    void ClimbDown()
    {
        //hold current speed, especially if player 
        speedHolder = myPlayer.Speed;
        //this is hard coded, but in the changeWalkdirection, by using * -1 to change walking direction, 
        //it causes the player speed to be -3, and go down when it hits the ladder
        //temporarily, I will save the speed before the player moves up
        //and hard code the player speed so that they will go up by speed of 3
        myPlayer.Speed = 3;
        myPlayer.PlayerMoveDirection = Vector2.down;
    }
}
