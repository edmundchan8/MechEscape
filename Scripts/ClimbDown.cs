using UnityEngine;
using System.Collections;

public class ClimbDown : MonoBehaviour {

    public bool Up;

    //Access to player
    GameObject PlayerGO;
    Player myPlayer;

    //Access to climbing
    Climbing myClimbing;

    void Start() {
        PlayerGO = GameObject.FindGameObjectWithTag("Player");
        myPlayer = PlayerGO.GetComponent<Player>();
        myClimbing = PlayerGO.GetComponent<Climbing>();
    }

    void OnTriggerEnter2D(Collider2D mycol)
    { if (mycol.gameObject.tag == "Player" && myPlayer.Grounded) { myClimbing.Up = false; } }

}
