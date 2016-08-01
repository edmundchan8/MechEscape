using UnityEngine;
using System.Collections;

public class RayDetectGameObjects : MonoBehaviour {
    
    RaycastHit2D hitInfo;

    //variables to hold reference to Button scripts
    GameObject ladderButtonGO, floorButtonGO;
    LadderButton myLadderButtonScript;
    FloorButton myFloorButtonScript;

    //access to instantiator script
    GameObject myInstantiatorGO;
    Instantiator myInstantiator;

    //check to see if we can instantiate or not
    public bool canInstantiate = false;


    // Use this for initialization
    void Start () {
        ladderButtonGO = GameObject.Find("LadderButton");
        floorButtonGO = GameObject.Find("FloorButton");
        myLadderButtonScript = ladderButtonGO.GetComponent<LadderButton>();
        myFloorButtonScript = floorButtonGO.GetComponent<FloorButton>();
        myInstantiatorGO = GameObject.Find("GameManager");
        myInstantiator = myInstantiatorGO.GetComponent<Instantiator>();

    }

    // Update is called once per frame
    void Update () {

        //test touching
        /*
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) { print("finger touching screen"); }  
        if (Input.touchCount == 0) { print("Finger off screen"); }
        */

        //If the leftmouse button is held down
        if (Input.GetMouseButtonDown(0))
        {
            //TODO change this to GetTouch
            //this is a ray fired from the camera
            Vector3 worldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition); //GetTouch(0).position);
            Vector2 mousePos2D = new Vector2(worldPos3D.x, worldPos3D.y);
            Vector2 direction = Vector2.zero; //this is needed to satisfy Physics2D.Raycast

            hitInfo = Physics2D.Raycast(mousePos2D, direction);
            {
                if (hitInfo) {
                    if (hitInfo.collider.name == "LadderButton") {
                        {
                            if (hitInfo.collider.name == "Ladder") { Debug.Log("Hitting Ladder gameobject"); }
                            canInstantiate = true;
                            myLadderButtonScript.SelectedLadderButton();
                        }
                    }
                }

                //if touching the floor
                if (hitInfo) {
                    if (hitInfo.collider.name == "FloorButton") {
                        {
                            canInstantiate = true;
                            myFloorButtonScript.SelectedFloorButton();
                        }
                    }
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

        }
        else if (Input.GetMouseButtonUp(0)) {
            myInstantiator.GrabbedObject = null;
        }
    }

    void FixedUpdate() {
        Vector3 worldPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition); //GetTouch(0).position);
        Vector2 mousePos2D = new Vector2(worldPos3D.x, worldPos3D.y);
        Vector2 direction = Vector2.zero; //this is needed to satisfy Physics2D.Raycast

        RaycastHit2D rayCastHitScene;

        rayCastHitScene = Physics2D.Raycast(mousePos2D, direction);

        if (rayCastHitScene) {
            if (rayCastHitScene.transform.tag == "Item")
            {
                canInstantiate = false;
            }
        }
    }
}
