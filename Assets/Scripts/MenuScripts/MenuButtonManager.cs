using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonManager : MonoBehaviour
{
    [SerializeField]
    public int level;

    public UnityEngine.UI.Button playButton;
    public UnityEngine.UI.Button exitButton;

    // Start is called before the first frame update
    void Start()
    {
        exitButton.onClick.AddListener(delegate { SwitchButtonHandler(0); });
        playButton.onClick.AddListener(delegate { SwitchButtonHandler(1); });
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
        }
    }
}
