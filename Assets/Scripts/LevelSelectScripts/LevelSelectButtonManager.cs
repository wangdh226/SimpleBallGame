using UnityEngine;

public class LevelSelectButtonManager : MonoBehaviour
{
    public void SelectLevel(int levelNum)
    {
        LevelManager.Load(levelNum);
    }
}