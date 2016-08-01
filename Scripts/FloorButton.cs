using UnityEngine;
using System.Collections;

public class FloorButton : MonoBehaviour
{
    //Selectors on buttons
    public GameObject FloorSelectorQuad, LadderSelectorQuad;
    
    //access to instantiator
    private GameObject myInstantiateGO;
    private Instantiator instantiateScript;

    PrefabHolder myPrefabHolder;
    void Start()
    {
        LadderSelectorQuad = GameObject.Find("LadderSelector");
        FloorSelectorQuad = GameObject.Find("FloorSelector");
        myInstantiateGO = GameObject.FindGameObjectWithTag("GameManager");
        myPrefabHolder = myInstantiateGO.GetComponent<PrefabHolder>();
        instantiateScript = myInstantiateGO.GetComponent<Instantiator>();
        FloorSelectorQuad.GetComponent<MeshRenderer>().enabled = false;
    }

    public void SelectedFloorButton()
    {
        FloorSelectorQuad.GetComponent<MeshRenderer>().enabled = true;
        LadderSelectorQuad.GetComponent<MeshRenderer>().enabled = false;
        Instantiator.SelectedAfterImage = myPrefabHolder.FloorTemplateGO;
        Instantiator.SelectedGO = myPrefabHolder.FloorGO;
        instantiateScript.InstantiateGameObject();
    }


}

