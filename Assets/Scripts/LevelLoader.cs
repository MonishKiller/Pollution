using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;

    public float transitionTime = 1f;
    public void ResetLevel()
    {
        Debug.Log("sd");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainUi()
    {
        SceneManager.LoadScene(0);

    }
    public void HTP()
    {
        SceneManager.LoadScene(3);

    }




    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);


    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }


}
