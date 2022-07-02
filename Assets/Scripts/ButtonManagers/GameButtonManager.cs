using UnityEngine;

public class GameButtonManager : MonoBehaviour
{
    public GameObject frame;
    public GameObject player;

    public Canvas game;
    public Canvas options;
    public Canvas menu;
    public Canvas win;
    
    // Start is called before the first frame update
    void Start()
    {
        game.enabled = true;
        options.enabled = false;
        menu.enabled = false;
        win.enabled = false;
    }

    public void Freeze()
    {
        (frame.GetComponent("Rigidbody") as Rigidbody).isKinematic = true;
        (frame.GetComponent("ConstantForce") as ConstantForce).enabled = false;
    }

    public void RotateCW()
    {
        (frame.GetComponent("Rigidbody") as Rigidbody).isKinematic = false;
        (frame.GetComponent("ConstantForce") as ConstantForce).enabled = true;
        (frame.GetComponent("ConstantForce") as ConstantForce).relativeTorque = new Vector3(0.0f, 0.0f, -10.0f);
    }

    public void RotateCCW()
    {
        (frame.GetComponent("Rigidbody") as Rigidbody).isKinematic = false;
        (frame.GetComponent("ConstantForce") as ConstantForce).enabled = true;
        (frame.GetComponent("ConstantForce") as ConstantForce).relativeTorque = new Vector3(0.0f, 0.0f, 10.0f);
    }


    public void OpenMenu()
    {
        (frame.GetComponent("Rigidbody") as Rigidbody).isKinematic = true;
        (frame.GetComponent("ConstantForce") as ConstantForce).enabled = false;
        (player.GetComponent("Rigidbody") as Rigidbody).isKinematic = true;
        game.enabled = false;
        menu.enabled = true;
        options.enabled = false;
    }

    public void OpenOptions()
    {
        (frame.GetComponent("Rigidbody") as Rigidbody).isKinematic = true;
        (frame.GetComponent("ConstantForce") as ConstantForce).enabled = false;
        (player.GetComponent("Rigidbody") as Rigidbody).isKinematic = true;
        game.enabled = false;
        menu.enabled = false;
        options.enabled = true;
    }

    public void ExitMenu()
    {
        (frame.GetComponent("Rigidbody") as Rigidbody).isKinematic = false;
        (frame.GetComponent("ConstantForce") as ConstantForce).enabled = true;
        (player.GetComponent("Rigidbody") as Rigidbody).isKinematic = false;
        game.enabled = true;
        menu.enabled = false;
        options.enabled = false;
    }


    public void LoadNextLevel()
    {
        LevelManager.LoadNextLevel();
        options.enabled = false;
        menu.enabled = false;
        win.enabled = false;
        game.enabled = true;
    }

    public void LoadMainMenu()
    {
        LevelManager.currentLevel = 0;
        LevelManager.Load(LevelManager.Scene.MainMenu);
    }

    public void LoadLevelSelect()
    {
        LevelManager.currentLevel = 0;
        LevelManager.Load(LevelManager.Scene.LevelSelect);
    }

    public void SetAudioLevel(int level)
    {
        Debug.Log(level);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
