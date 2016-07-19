using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float TimeTillLoadTitle;
    int currentLevel;
	void Start () {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
	}
	
	void Update () {
        if (currentLevel == 0) { Invoke("LoadTitleScene", TimeTillLoadTitle); }
	}

    void LoadTitleScene() { SceneManager.LoadScene(1); }
    
}
