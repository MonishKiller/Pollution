using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("Theme");
    }


    public void Mainmenu()
    {
        FindObjectOfType<LevelLoader>().MainUi();


    }

    public void LoadNext() {
        FindObjectOfType<LevelLoader>().LoadNextLevel();
    }
    public void Restart() {
        FindObjectOfType<LevelLoader>().ResetLevel();
    }

}
