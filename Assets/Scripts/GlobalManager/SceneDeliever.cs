using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDeliever : MonoBehaviour
{
    string nextScene;
    private void Start()
    {
        nextScene = PlayerInventory.Instance.PlayerData.nextScene;
        SceneController.Instance.LoadSceneWithObjects(nextScene);
    }
}
