using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    GameManager gm;
    void Start()
    {
        gm = DontDestroyOnLoadManager.GetGameManager();
    }
    public void OnStartClick()
    {
        gm.LoadGame();
    }
    public void OnExitClick()
    {
        gm.ExitGame();
    }
}
