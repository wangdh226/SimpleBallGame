using UnityEngine;

public class MainMenuButtonManager : MonoBehaviour {
    public Canvas mainMenu;
    public Canvas options;

    void Start() {
        LevelManager.currentLevel = 0;
        mainMenu.enabled = true;
        options.enabled = false;
    }

    public void OpenOptions() {
        mainMenu.enabled = false;
        options.enabled = true;
    }

    public void ExitMenu() {
        mainMenu.enabled = true;
        options.enabled = false;
    }
}
