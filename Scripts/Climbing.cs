using UnityEngine;
using System.Collections;

public class Climbing : MonoBehaviour {

    //Access to player
    GameObject PlayerGO;
    Player myPlayer;

    //Access to IgnoreCollider
    IgnoreCollider myIgnoreCollider;

    public bool Up;

    //timer to say when can climb
    float canClimb;
    public float TimeToClimb;

    void Start() {
        PlayerGO = GameObject.FindGameObjectWithTag("Player");
        myPlayer = PlayerGO.GetComponent<Player>();
        myIgnoreCollider = PlayerGO.GetComponent<IgnoreCollider>();

    }

    void Update() {
    }

    void OnCollisionEnter2D(Collision2D myCol)
    {
        //if hit the wall, change walking direction
        if (myCol.gameObject.tag == "Wall")
        {
            myPlayer.Speed *= -1; myPlayer.IsFacingRight = !myPlayer.IsFacingRight;
        }
    }

    void OnTriggerEnter2D(Collider2D myCol)
    {

        if (Time.time > canClimb)
        {
            //if hit the ladder, climb up/down ladder
            if (myCol.name == "LadderBody")
            {
                ClimbingLadder();
                SetCanClimbTime();
            }
        }
    }

    void OnTriggerExit2D(Collider2D myCol)
    {
        
        if (myCol.name == "LadderBody")
        {
            myIgnoreCollider.IgnoreGroundCollider(false);
            myPlayer.MyRigidbody2D.gravityScale = myPlayer.GravityStore;
            myPlayer.Speed = myPlayer.SpeedStore;
            if (myPlayer.IsFacingRight) { myPlayer.PlayerMoveDirection = Vector2.right; }
            else { myPlayer.PlayerMoveDirection = Vector2.left; }
        }
    }

    void ClimbingLadder()
    {
        myIgnoreCollider.IgnoreGroundCollider(true);
        myPlayer.MyRigidbody2D.gravityScale = 0f;
        if (Up) { myPlayer.PlayerMoveDirection = Vector2.up; }
        else if (Up == false) { myPlayer.PlayerMoveDirection = Vector2.down; }
        myPlayer.Speed = myPlayer.ClimbingSpeed;
    }

    void SetCanClimbTime() {
        canClimb = Time.time + TimeToClimb;
    }
}
