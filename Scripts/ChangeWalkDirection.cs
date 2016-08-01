using UnityEngine;
using System.Collections;

public class ChangeWalkDirection : MonoBehaviour {

    //Access to player
    public GameObject PlayerGO;
    Player myPlayer;

    void Start()
    {
        PlayerGO = GameObject.Find("Player");
        myPlayer = PlayerGO.GetComponent<Player>();
    }


    void OnCollisionEnter2D(Collision2D myCol)
    {
        //if hit the wall, change walking direction
        if (myCol.gameObject.tag == "Wall")
        {
            Debug.Log("Hitwall");
            //reverse player speed (by multiplying by -1) to go in other direction
            myPlayer.Speed *= -1;
            myPlayer.IsFacingRight = !myPlayer.IsFacingRight;
        }
    }
}
