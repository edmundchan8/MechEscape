using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {
    GameObject GameManager;
    ClearOrFail myClearOrFail;

    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        myClearOrFail = GameManager.GetComponent<ClearOrFail>();
    }

    void OnTriggerEnter2D(Collider2D myCol)
    {
        if (myCol.gameObject.name == "Player")
        {
            myClearOrFail.Win();
        }
    }
}
