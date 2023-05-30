using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoSingleton<SceneController>
{
    IEnumerator LoadAsyncScene(string sceneName)
    {
        int sceneIndex = SceneUtility.GetBuildIndexByScenePath("Scenes/" + sceneName);
        if (sceneIndex <0)
        {
            LoadMenuScene("MainMenu");
            yield break;
        }
        Scene currentScene = SceneManager.GetActiveScene();
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        for (int i = 0; i < Object.FindObjectsOfType<DontDestroy>().Length; i++)
        {
            if (Object.FindObjectsOfType<DontDestroy>()[i] != this)
            {
                SceneManager.MoveGameObjectToScene(Object.FindObjectsOfType<DontDestroy>()[i].gameObject, SceneManager.GetSceneByName(sceneName));
            }
            SceneManager.MoveGameObjectToScene(Object.FindObjectsOfType<DontDestroy>()[i].gameObject, SceneManager.GetSceneByName(sceneName));
        }
        SceneManager.UnloadSceneAsync(currentScene);
    }
    public void LoadSceneWithObjects(string sceneName)
    {
        StartCoroutine(LoadAsyncScene(sceneName));
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void LoadScene(int sceneBuildID)
    {
        SceneManager.LoadScene(sceneBuildID);
    }
    public void LoadMenuScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void NextScene()
    {
        int sceneIndex;
        string currentScene = SceneManager.GetActiveScene().name;
        string newScene = currentScene[^1..];
        int.TryParse(newScene, out sceneIndex);
        sceneIndex++;
        newScene = currentScene.Substring(0, currentScene.Length - 1) + sceneIndex;
        PlayerInventory.Instance.PlayerData.nextScene = newScene;
        LoadScene("TempScene");
    }
}
