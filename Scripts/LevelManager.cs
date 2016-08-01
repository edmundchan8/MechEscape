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

    public void LoadLevelName(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void RestartScene() {
        int level = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(level);
    }
}
