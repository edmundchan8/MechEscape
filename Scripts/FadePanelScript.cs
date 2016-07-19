using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadePanelScript : MonoBehaviour {

    Image myPanel;
    Color panelColor;
    public float FadeInTime;

	void Start () {
        myPanel = GetComponent<Image>();
        panelColor = Color.white;
        myPanel.color = panelColor;
	}
	
	void Update () {
        
        if (Time.timeSinceLevelLoad < FadeInTime)
        {
            float alphaChange;
            alphaChange = Time.deltaTime / FadeInTime;
            panelColor.a -= alphaChange;
            myPanel.color = panelColor;
        }
        else {
            gameObject.SetActive(false);
        }

	}
}
