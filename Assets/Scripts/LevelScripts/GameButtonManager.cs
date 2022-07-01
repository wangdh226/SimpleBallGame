using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButtonManager : MonoBehaviour
{
    public GameObject frame;
    public GameObject player;
    public Canvas game;
    public Canvas options;
    public Canvas menu;
    [SerializeField]
    public int level;

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

    // Update is called once per frame
    void Update() { }

    void SwitchButtonHandler(int index)
    {
        switch (index)
        {
            case 0:
                (frame.GetComponent("Rigidbody") as Rigidbody).isKinematic = true;
                (frame.GetComponent("ConstantForce") as ConstantForce).enabled = false;
                break;
            case 1:
                (frame.GetComponent("Rigidbody") as Rigidbody).isKinematic = false;
                (frame.GetComponent("ConstantForce") as ConstantForce).enabled = true;
                (frame.GetComponent("ConstantForce") as ConstantForce).relativeTorque = new Vector3(0.0f, 0.0f, -10.0f);
                break;
            case 2:
                (frame.GetComponent("Rigidbody") as Rigidbody).isKinematic = false;
                (frame.GetComponent("ConstantForce") as ConstantForce).enabled = true;
                (frame.GetComponent("ConstantForce") as ConstantForce).relativeTorque = new Vector3(0.0f, 0.0f, 10.0f);
                break;
            case 3:
                OpenMenu();
                break;
            case 4:
                OpenOptions();
                break;
            case 5:
                ExitMenu();
                break;
            case 6:
                game.enabled = true;
                options.enabled = false;
                menu.enabled = false;
                LevelManager.LoadNextLevel(level);
                Debug.Log("Next level");
                break;
            case 7:
                LevelManager.Load(LevelManager.Scene.Scene0);
                Debug.Log("exit to Main Menu");
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
