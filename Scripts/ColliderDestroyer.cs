using UnityEngine;
using System.Collections;

public class ColliderDestroyer : MonoBehaviour {

    public LayerMask MyLayerMask;

    void Update() {

        //TODO sort out layermask naming
        Physics2D.OverlapCircle(transform.position, 2f, MyLayerMask);

    }
}
