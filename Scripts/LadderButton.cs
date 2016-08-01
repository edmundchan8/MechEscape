using UnityEngine;
using System.Collections;

public class LadderButton : MonoBehaviour {

    //Selectors on buttons
    public GameObject LadderSelectorQuad, FloorSelectorQuad;

    //access to instantiator
    private GameObject myInstantiateGO;
    private Instantiator instantiateScript;

    //hold prefabs that can be instantiated
    PrefabHolder myPrefabHolder;

    void Start() {
        LadderSelectorQuad = GameObject.Find("LadderSelector");
        FloorSelectorQuad = GameObject.Find("FloorSelector");
        myInstantiateGO = GameObject.FindGameObjectWithTag("GameManager");
        myPrefabHolder = myInstantiateGO.GetComponent<PrefabHolder>();
        instantiateScript = myInstantiateGO.GetComponent<Instantiator>();
        LadderSelectorQuad.GetComponent<MeshRenderer>().enabled = false;
    }

    public void SelectedLadderButton() {
        LadderSelectorQuad.GetComponent<MeshRenderer>().enabled = true;
        FloorSelectorQuad.GetComponent<MeshRenderer>().enabled = false;
        Instantiator.SelectedAfterImage = myPrefabHolder.LadderTemplateGO;
        Instantiator.SelectedGO = myPrefabHolder.LadderGO;
        instantiateScript.InstantiateGameObject();
    }

        
}
