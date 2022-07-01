using UnityEngine;

public class EndScreenButtonManager : MonoBehaviour
{
    public void exit()
    {
        Application.Quit();
    }

    public void mainMenu()
    {
        LevelManager.Load(LevelManager.Scene.MainMenu);
    }
}
