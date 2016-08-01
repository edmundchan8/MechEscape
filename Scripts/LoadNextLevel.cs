using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LoadNextLevel : MonoBehaviour {

    public bool ReadyForNextLevel;
    float LoadNextLevelTime;
    bool callOnceBool;

    //access to image button and text
    Image myNextLevel;
    Text myText;

	// Use this for initialization
	void Start () {
        LoadNextLevelTime = Time.timeSinceLevelLoad + 2;
        ReadyForNextLevel = false;
        callOnceBool = true;
        myNextLevel = GetComponent<Image>();
        myText = gameObject.transform.GetChild(0).GetComponent<Text>();

        myNextLevel.GetComponent<Image>().enabled = false;
        myText.GetComponent<Text>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        
        if (ReadyForNextLevel) {

            if (callOnceBool) {
                LoadNextLevelTime = Time.timeSinceLevelLoad + 2;
                callOnceBool = false;
            }
            
            if (Time.timeSinceLevelLoad > LoadNextLevelTime) {
                myNextLevel.GetComponent<Image>().enabled = true;
                myText.GetComponent<Text>().enabled = true;
            }
        }
	}
}
