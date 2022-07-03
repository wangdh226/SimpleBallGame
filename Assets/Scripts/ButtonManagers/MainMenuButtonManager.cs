using UnityEngine;

public class MainMenuButtonManager : MonoBehaviour {
    public Canvas mainMenu;
    public Canvas options;

    // Start is called before the first frame update
    void Start() {
        LevelManager.currentLevel = 0;
        mainMenu.enabled = true;
        options.enabled = false;
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void OpenOptions() {
        mainMenu.enabled = false;
        options.enabled = true;
    }

    public void ExitMenu() {
        mainMenu.enabled = true;
        options.enabled = false;
    }

    public void LoadFirstLevel() {
        LevelManager.Load(1);
    }

    public void LoadLevelSelector() {
        LevelManager.Load(LevelManager.Scene.LevelSelect);
    }

    public void SetAudioLevel(int level) {
        Debug.Log(level);
    }
}
