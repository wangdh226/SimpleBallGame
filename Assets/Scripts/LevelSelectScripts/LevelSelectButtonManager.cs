using UnityEngine;

public class LevelSelectButtonManager : MonoBehaviour
{
    public void SelectLevel(int levelNum)
    {
        LevelManager.Load(levelNum);
    }

    public void back()
    {
        LevelManager.Load(LevelManager.Scene.MainMenu);
    }

    public void play()
    {
        LevelManager.Load(1);
    }
}