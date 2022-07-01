using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelManager 
{

    public enum Scene
    {
       Scene0, Scene1, Scene2

    }


    public static void Load(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public static void LoadNextLevel(int currentScene)
    {
        string nextScene = "Scene" + (currentScene + 1);
        Debug.Log("Next level = " + nextScene);
        SceneManager.LoadScene(nextScene);
    }

}
