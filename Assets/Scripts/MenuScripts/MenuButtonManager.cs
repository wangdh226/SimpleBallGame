using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonManager : MonoBehaviour
{
    public Canvas mainMenu;
    public Canvas options;
    [SerializeField]
    public int level;

    public UnityEngine.UI.Button playButton;
    public UnityEngine.UI.Button exitButton;
    public UnityEngine.UI.Button optionButton;
    public UnityEngine.UI.Button exitMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.enabled = true;
        options.enabled = false;
        exitButton.onClick.AddListener(delegate { SwitchButtonHandler(0); });
        playButton.onClick.AddListener(delegate { SwitchButtonHandler(1); });
        optionButton.onClick.AddListener(delegate { SwitchButtonHandler(2); });
        exitMenuButton.onClick.AddListener(delegate { SwitchButtonHandler(3); });
    }

    // Update is called once per frame
    void Update() { }

    void SwitchButtonHandler(int index)
    {
        switch (index)
        {
            case 0:
                Application.Quit();
                break;
            case 1:
                LevelManager.Load(LevelManager.Scene.Scene1);
                Debug.Log("Loading first level");
                break;
            case 2:
                OpenOptions();
                break;
            case 3:
                mainMenu.enabled = true;
                options.enabled = false;
                break;
        }
    }

    private void OpenOptions()
    {
        mainMenu.enabled = false;
        options.enabled = true;
    }

    private void ExitMenu()
    {
        mainMenu.enabled = true;
        options.enabled = false;
    }
}