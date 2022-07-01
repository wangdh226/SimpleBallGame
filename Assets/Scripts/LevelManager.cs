using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelManager 
{
    public static int currentLevel = 0;

    public enum Scene
    {
       LevelSelect, MainMenu
    }

    // Used for selecting a specific 'special' scene
    public static void Load(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    // Used for selecting a specific level
    public static void Load(int levelNum)
    {
        currentLevel = levelNum;
        string nextScene = "Scene" + (currentLevel);
        Debug.Log("Next level = " + nextScene);
        SceneManager.LoadScene(nextScene);
    }

    // Used for loading the next level based on current level
    public static void LoadNextLevel()
    {
        currentLevel++;
        string nextScene = "Scene" + (currentLevel);
        Debug.Log("Next level = " + nextScene);
        SceneManager.LoadScene(nextScene);
    }

}
