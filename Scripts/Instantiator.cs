using UnityEngine;
using System.Collections;

public class Instantiator : MonoBehaviour {
    
    public static GameObject SelectedAfterImage;
    public static GameObject SelectedGO;

    //Access to Camera
    public Camera MyCamera;
    RayDetectGameObjects myRayCheckScript;
    
    //somewhere to hold the duplication of ladders
    GameObject parentHolder;

    //bool to confirm we are grabbing this gameobject
    public GameObject GrabbedObject;

    //min and max x values for instantiating objects
    public float MinX, MaxX;

    void Start() {
        parentHolder = GameObject.Find("parentHolder");
        if (parentHolder == null) {
            parentHolder = new GameObject("parentHolder");
        }
        
        MyCamera = Camera.main;
        myRayCheckScript = MyCamera.GetComponent<RayDetectGameObjects>();
    }

    void Update() {
    }
   
    public void InstantiateGameObject()
    {
        {
            //bool canInstantiate = false;
            /*Vector2 rawPos = CalculateWorldPointFromMousePos();
            Vector2 roundedPos = SnapToGridPosition(rawPos);
            roundedPos = new Vector2((Mathf.Clamp(roundedPos.x, MinX, MaxX)), (Mathf.Clamp(roundedPos.y, MinY, MaxY)));
            if (roundedPos.x % 2 == 0) { canInstantiate = true; }
            if (roundedPos.y % 8 == 0) { canInstantiate = true; }
            */
            GameObject selectorGO = SelectedAfterImage;
            Quaternion zeroRotation = Quaternion.identity; //needed for instantiation
            //if (canInstantiate) { }
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(worldPos.x, worldPos.y);
            GameObject newSelector = Instantiate(selectorGO, mousePos2D, zeroRotation) as GameObject;
            SelectedAfterImage = newSelector;
            SelectedAfterImage.transform.parent = parentHolder.transform;
            GrabbedObject = SelectedAfterImage;
        }
    }
    
    //calculates world coordinates
    /*
    Vector2 CalculateWorldPointFromMousePos()
    {
        //ladder should move in x direction by 2 units
        //ladder should move in y direction by 4 units

        //pull the mouse positions into independent floats
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;

        // value doesn't really matter but part of code
        float distanceFromCamera = 10f;

        //method needs a vector3
        //weird because of our z coodrdinate
        Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 rawWorldPosition = MyCamera.ScreenToWorldPoint(weirdTriplet);

        return rawWorldPosition;
    }*/

        /*
    Vector2 SnapToGridPosition(Vector2 rawWorldPosition) {

        int newRoundedXPos = Mathf.RoundToInt(rawWorldPosition.x);
        int newRoundedYPos = Mathf.RoundToInt(rawWorldPosition.y);

        return new Vector2(newRoundedXPos, newRoundedYPos);
    }*/

    void FixedUpdate() {

        float fixedYPos;
        float fixedXPos;

        if (GrabbedObject != null)
        {//if we are holding something (the instantiated gameobject)
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            fixedXPos = Mathf.Clamp(worldPos.x, MinX, MaxX);
            Vector2 mousePos2D = new Vector2(fixedXPos, worldPos.y);
            SelectedAfterImage.transform.position = mousePos2D;

            //if canInstantiate = true, ladderafterimage mesh = true, else its false
            if (!myRayCheckScript.canInstantiate) {
                SelectedAfterImage.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            } else SelectedAfterImage.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        }

        if (GrabbedObject == null && Input.GetMouseButtonUp(0))
        {
            GameObject[] destroyThisGO = GameObject.FindGameObjectsWithTag("AfterImage");
            foreach (GameObject thisGO in destroyThisGO)
            {
                Destroy(thisGO);
            }
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //to fix position of ladder instantiation
            fixedYPos = worldPos.y;

            if (fixedYPos < 0) { fixedYPos = -2f; }
            else if (fixedYPos > 0 && fixedYPos < 4) { fixedYPos = 2f; }
            else if (fixedYPos > 4 && fixedYPos < 8) { fixedYPos = 6f; }

            Vector2 mousePos2D = new Vector2(worldPos.x, fixedYPos); 
            if (myRayCheckScript.canInstantiate) {
                GameObject newGO = Instantiate(SelectedGO, mousePos2D, SelectedGO.transform.rotation) as GameObject;
                newGO.transform.parent = parentHolder.transform;
                myRayCheckScript.canInstantiate = false;
            }
            
        }
    }
    
}