using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StageClear : MonoBehaviour {

    Text myText;
    Color textColor;
    public bool ShowText;

    public GameObject NextLevel;
    LoadNextLevel myLoadNextLevel;

	// Use this for initialization
	void Start () {
        NextLevel = GameObject.Find("NextLevel");
        myLoadNextLevel = NextLevel.GetComponent<LoadNextLevel>();
        myText = GetComponent<Text>();
        textColor.a = 0;
        myText.color = textColor;
        ShowText = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (ShowText) {
            float alpha = 255;
            textColor.a = alpha;
            myText.color = textColor;
            myLoadNextLevel.ReadyForNextLevel = true;
        }
	}
}
