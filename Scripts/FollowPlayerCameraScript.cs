using UnityEngine;
using System.Collections;

public class FollowPlayerCameraScript : MonoBehaviour {

    public GameObject MyPlayer;
    public float CameraCentre;
    Vector3 offset;
    Vector3 holder;
    public float MinX, MaxX;

    //affect the y position of camera
    public float YPosAdd;

    void Start()
    {
        MyPlayer = GameObject.Find("Player");
        offset = transform.position - MyPlayer.transform.position;
        holder.x = offset.x + CameraCentre;
        offset += holder;

    }


    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = MyPlayer.transform.position + offset;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinX, MaxX), transform.position.y + YPosAdd, transform.position.z);
    }
}
