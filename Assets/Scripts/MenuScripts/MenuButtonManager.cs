using UnityEngine;

public class MenuButtonManager : MonoBehaviour
{
    public Canvas mainMenu;
    public Canvas options;

    public UnityEngine.UI.Button playButton;
    public UnityEngine.UI.Button exitButton;
    public UnityEngine.UI.Button optionButton;
    public UnityEngine.UI.Button exitMenuButton;
    public UnityEngine.UI.Button levelSelectButton;

    // Start is called before the first frame update
    void Start()
    {
        LevelManager.currentLevel = 0;
        mainMenu.enabled = true;
        options.enabled = false;
        exitButton.onClick.AddListener(delegate { SwitchButtonHandler(0); });
        playButton.onClick.AddListener(delegate { SwitchButtonHandler(1); });
        optionButton.onClick.AddListener(delegate { SwitchButtonHandler(2); });
        exitMenuButton.onClick.AddListener(delegate { SwitchButtonHandler(3); });
        levelSelectButton.onClick.AddListener(delegate { SwitchButtonHandler(4); });
    }

    void SwitchButtonHandler(int index)
    {
        switch (index)
        {
            case 0:
                //Debug.log("Quit application");
                Application.Quit();
                break;
            case 1:
                //Debug.Log("Load first level");
                LevelManager.Load(1);
                break;
            case 2:
                //Debug.log("Open Options");
                OpenOptions();
                break;
            case 3:
                //Debug.log("Exit Menu");
                ExitMenu();
                break;
            case 4:
                //Debug.log("Load Level Select");
                LevelManager.Load(LevelManager.Scene.LevelSelect);
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
