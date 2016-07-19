using UnityEngine;
using System.Collections;

public class IgnoreCollider : MonoBehaviour {

    public GameObject[] Grounds;

    void Start()
    {
        Grounds = GameObject.FindGameObjectsWithTag("Ground");
    }

    public void IgnoreGroundCollider(bool ignore)
    {
        foreach (GameObject ground in Grounds)
        {
            Physics2D.IgnoreCollision(ground.GetComponent<Collider2D>(), transform.GetComponent<Collider2D>(), ignore);
        }
    }
}
