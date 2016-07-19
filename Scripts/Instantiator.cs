using UnityEngine;
using System.Collections;

public class Instantiator : MonoBehaviour {

    Ray myRay;
    RaycastHit hitInfo;

    //Selectors on buttons
    public GameObject LadderSelectorQuad;
    public GameObject FloorSelectorQuad;

    public GameObject LadderAfterImage;
    public GameObject FloorAfterImage;

    public GameObject LadderGO;
    public GameObject FloorGO;

    private static GameObject SelectedGO;

    //Access to Camera
    public Camera MyCamera;

    //limit where we can instantiate the gameobject
    public float MinX, MaxX, MinY, MaxY;

    //somewhere to hold the duplication of ladders
    GameObject parentHolder;

    void Start() {
        parentHolder = GameObject.Find("parentHolder");
        if (parentHolder == null) {
            parentHolder = new GameObject("parentHolder");
        }
    }

    void Update() {

        //test touching
        /*
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) { print("finger touching screen"); }  
        if (Input.touchCount == 0) { print("Finger off screen"); }
        */
        

        //TODO change this to GetTouch
        myRay = Camera.main.ScreenPointToRay(Input.mousePosition); //GetTouch(0).position);

        if (Physics.Raycast(myRay, out hitInfo)) {
            //TODO
            //click ladder option, make UI clear that ladder option is selected,

            //TODO - save for anki app. 
            //If you want to detect child gameobject in a parent, find a child component in a gameobject
            
                        
            //if touching the ladder
            if (hitInfo.collider.name == "LadderButton")
            {   LadderSelectorQuad.SetActive(true);
                FloorSelectorQuad.SetActive(false);
                SelectedGO = LadderGO;
            }

            //if touching the floor
            if (hitInfo.collider.name == "FloorButton")
            {   FloorSelectorQuad.SetActive(true);
                LadderSelectorQuad.SetActive(false);
                SelectedGO = FloorGO;
            }

            //TODO Change this to input.getTouch(0) and
            //if Input.TouchCount = 1 and selected gameObject is true
            //if (LadderSelectorQuad.activeInHierarchy) { };


            //Then, need a way to make a sprite of the option we chose to be where mouse/touch position is
            //this locks into certain positions of the game mathf.round
            //maybe could fix the width and height of the game board
            //maybe make the sprite.a appear lighter
            


            //Once you have a place to leave the gameobject, when touch mytouch.phase = touchphase.end
            //instantiates a gameobject where your mouse was last at


            /*if(hitInfo.collider.tag == the button that you pressed) {
                Select gameobject corresponding to this button
                use Input.GetTouch(0).phase == TouchPhase.Stationary = holding finger on screen
                once let go, = Input.GetTouch(0).phase == TouchPhase.End = let go of finger, final transform position of player, this
                is where we will instantiate the player 
            }*/
        }

        //if (posX%2 == 0 && posY %3 == 0) { }


        //TODO
        //if you click on a particular position in the game
        //and the ladder selector is true and selected Gameobject is the ladderprefab
        //Instantiate the gameobject

        if (LadderSelectorQuad.activeInHierarchy == true && SelectedGO == LadderGO && Input.GetMouseButtonDown(0))
        {
            InstantiateGameObject();
        }
    }
   
    void InstantiateGameObject()
    {
        {
            bool canInstantiate = false;
            Vector2 rawPos = CalculateWorldPointFromMousePos();
            Vector2 roundedPos = SnapToGridPosition(rawPos);
            roundedPos = new Vector2((Mathf.Clamp(roundedPos.x, MinX, MaxX)), (Mathf.Clamp(roundedPos.y, MinY, MaxY)));
            if (roundedPos.x % 2 == 0) { canInstantiate = true; }
            if (roundedPos.y % 8 == 0) { canInstantiate = true; }
            GameObject selectorGO = SelectedGO;
            Quaternion zeroRotation = Quaternion.identity;
            if (canInstantiate) {
                GameObject newSelector = Instantiate(selectorGO, roundedPos, zeroRotation) as GameObject;
                newSelector.transform.parent = parentHolder.transform;
            }
            
        }
    }


    //calculates world coordinates
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
    }

    Vector2 SnapToGridPosition(Vector2 rawWorldPosition) {

        int newRoundedXPos = Mathf.RoundToInt(rawWorldPosition.x);
        int newRoundedYPos = Mathf.RoundToInt(rawWorldPosition.y);

        return new Vector2(newRoundedXPos, newRoundedYPos);
    }




}
