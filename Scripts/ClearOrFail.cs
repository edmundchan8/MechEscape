using UnityEngine;
using System.Collections;

public class ClearOrFail : MonoBehaviour {

    GameObject StageClear, StageFail;
    StageClear myStageClear;
    StageFail myStageFail;

	// Use this for initialization
	void Start () {
        StageClear = GameObject.Find("StageClear");
        StageFail = GameObject.Find("StageFail");
        myStageClear = StageClear.GetComponent<StageClear>();
        myStageFail = StageFail.GetComponent<StageFail>();
    }

    public void Win() {
        myStageClear.ShowText = true;
    }

    public void Lose() {
        myStageFail.ShowText = true;
    }
}
