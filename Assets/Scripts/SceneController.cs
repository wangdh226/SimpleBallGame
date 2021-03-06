using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour {

    private Animator transition;
    public float transitionTime = 1f;

    private void Awake() {
        transition = GameObject.Find("Crossfade").GetComponent<Animator>();
    }

    private void trigger() {
        StartCoroutine(triggerSceneFade());
    }

    IEnumerator triggerSceneFade() {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
    }

    // Methods to load levels with SceneFade
    public void LoadFirstLevel() {
        trigger();
        LevelManager.Load(1);
    }

    public void LoadLevel(int levelNum) {
        trigger();
        LevelManager.Load(levelNum);
    }

    public void ReloadLevel() {
        trigger();
        LevelManager.Load(LevelManager.currentLevel);
    }

    public void LoadNextLevel() {
        trigger();
        LevelManager.LoadNextLevel();
    }

    public void LoadLevelSelector() {
        trigger();
        LevelManager.currentLevel = 0;
        LevelManager.Load(LevelManager.Scene.LevelSelect);
    }

    public void LoadMainMenu() {
        trigger();
        LevelManager.currentLevel = 0;
        LevelManager.Load(LevelManager.Scene.MainMenu);
    }

    public void ExitGame() {
        Application.Quit();
    }
}
