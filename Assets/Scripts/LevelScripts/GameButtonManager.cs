using UnityEngine;

public class GameButtonManager : MonoBehaviour
{
    public GameObject frame;
    public GameObject player;
    public Canvas game;
    public Canvas options;
    public Canvas menu;
    public Canvas win;

    public UnityEngine.UI.Button CCWButton;
    public UnityEngine.UI.Button CWButton;
    public UnityEngine.UI.Button freezeButton;

    public UnityEngine.UI.Button menuButton;
    public UnityEngine.UI.Button exitMenuButton;
    public UnityEngine.UI.Button optionButton;
    public UnityEngine.UI.Button exitOptionButton;

    public UnityEngine.UI.Button nextLevelButton;
    public UnityEngine.UI.Button exitToMainMenuButton;
    
    // Start is called before the first frame update
    void Start()
    {
        game.enabled = true;
        options.enabled = false;
        menu.enabled = false;

        freezeButton.onClick.AddListener(delegate { SwitchButtonHandler(0); });
        CWButton.onClick.AddListener(delegate { SwitchButtonHandler(1); });
        CCWButton.onClick.AddListener(delegate { SwitchButtonHandler(2); });

        menuButton.onClick.AddListener(delegate { SwitchButtonHandler(3); });
        optionButton.onClick.AddListener(delegate { SwitchButtonHandler(4); });
        exitMenuButton.onClick.AddListener(delegate { SwitchButtonHandler(5); });
        exitOptionButton.onClick.AddListener(delegate { SwitchButtonHandler(5); });

        nextLevelButton.onClick.AddListener(delegate { SwitchButtonHandler(6); });
        exitToMainMenuButton.onClick.AddListener(delegate { SwitchButtonHandler(7); });
    }

    void SwitchButtonHandler(int index)
    {
        switch (index)
        {
            case 0:
                //Debug.Log("Freeze");
                (frame.GetComponent("Rigidbody") as Rigidbody).isKinematic = true;
                (frame.GetComponent("ConstantForce") as ConstantForce).enabled = false;
                break;
            case 1:
                //Debug.Log("Rotate CW");
                (frame.GetComponent("Rigidbody") as Rigidbody).isKinematic = false;
                (frame.GetComponent("ConstantForce") as ConstantForce).enabled = true;
                (frame.GetComponent("ConstantForce") as ConstantForce).relativeTorque = new Vector3(0.0f, 0.0f, -10.0f);
                break;
            case 2:
                //Debug.Log("Rotate CCW");
                (frame.GetComponent("Rigidbody") as Rigidbody).isKinematic = false;
                (frame.GetComponent("ConstantForce") as ConstantForce).enabled = true;
                (frame.GetComponent("ConstantForce") as ConstantForce).relativeTorque = new Vector3(0.0f, 0.0f, 10.0f);
                break;
            case 3:
                //Debug.Log("Open Menu");
                OpenMenu();
                break;
            case 4:
                //Debug.Log("Open Options");
                OpenOptions();
                break;
            case 5:
                //Debug.Log("Exit Menu/Options");
                ExitMenu();
                break;
            case 6:
                //Debug.Log("Next level");
                LevelManager.LoadNextLevel();
                options.enabled = false;
                menu.enabled = false;
                win.enabled = false;
                game.enabled = true;
                break;
            case 7:
                //Debug.Log("exit to Main Menu");
                LevelManager.currentLevel = 0;
                LevelManager.Load(LevelManager.Scene.MainMenu);
                break;
        }
    }

    private void OpenMenu()
    {
        (frame.GetComponent("Rigidbody") as Rigidbody).isKinematic = true;
        (frame.GetComponent("ConstantForce") as ConstantForce).enabled = false;
        (player.GetComponent("Rigidbody") as Rigidbody).isKinematic = true;
        game.enabled = false;
        menu.enabled = true;
        options.enabled = false;
    }

    private void OpenOptions()
    {
        (frame.GetComponent("Rigidbody") as Rigidbody).isKinematic = true;
        (frame.GetComponent("ConstantForce") as ConstantForce).enabled = false;
        (player.GetComponent("Rigidbody") as Rigidbody).isKinematic = true;
        game.enabled = false;
        menu.enabled = false;
        options.enabled = true;
    }

    private void ExitMenu()
    {
        (frame.GetComponent("Rigidbody") as Rigidbody).isKinematic = false;
        (frame.GetComponent("ConstantForce") as ConstantForce).enabled = true;
        (player.GetComponent("Rigidbody") as Rigidbody).isKinematic = false;
        game.enabled = true;
        menu.enabled = false;
        options.enabled = false;
    }

}
