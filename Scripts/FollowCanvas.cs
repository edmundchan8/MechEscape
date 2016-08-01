using UnityEngine;
using System.Collections;

public class FollowCanvas : MonoBehaviour {

    GameObject playerGO;
    Vector3 offset;

    //this value is to calculate how much higher the buttons should be in relation to the player
    public float buttonHeight;

	// Use this for initialization
	void Start () {
        playerGO = GameObject.Find("Player");
        offset = playerGO.transform.position - transform.position;

    }
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = new Vector3(transform.position.x, playerGO.transform.position.y + buttonHeight, transform.position.z);
	}
}
