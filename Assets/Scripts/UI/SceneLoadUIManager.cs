using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoadUIManager : MonoBehaviour
{
    int sceneCount;
    [SerializeField] Button sceneButton;
    [SerializeField] Transform panel;
    // Start is called before the first frame update
    void Start()
    {
        sceneCount = SceneManager.sceneCountInBuildSettings;
        for(int i = 2; i < sceneCount; i++)
        {
            SceneButton sb = Instantiate(sceneButton, panel.transform, true).GetComponent<SceneButton>();
            sb.Id = i - 1;
            sb.SetSceneName();
            if(sb.Id < 4)
            {
                sb.SetStatus(true);
            }
            else
            {
                sb.SetStatus(false);
            }
        }
    }
}
