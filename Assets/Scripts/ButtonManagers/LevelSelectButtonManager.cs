using UnityEngine;

public class LevelSelectButtonManager : MonoBehaviour {
    public void SelectLevel(int levelNum) {
        LevelManager.Load(levelNum);
    }

    public void Back() {
        LevelManager.Load(LevelManager.Scene.MainMenu);
    }

    public void Play() {
        LevelManager.Load(1);
    }
}