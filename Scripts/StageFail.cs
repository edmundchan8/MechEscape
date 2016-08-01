using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class StageFail : MonoBehaviour {

    Text myText;
    Color textColor;
    public bool ShowText;

    // Use this for initialization
    void Start()
    {
        myText = GetComponent<Text>();
        textColor.a = 0;
        myText.color = textColor;
        ShowText = false;
    }

    

    // Update is called once per frame
    void Update()
    {
        if (ShowText)
        {
            float alpha = 255;
            textColor.a = alpha;
            myText.color = textColor;
        }
    }
}
