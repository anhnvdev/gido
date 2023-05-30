using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoSingleton<MainMenuManager>
{
    [SerializeField]Button btnLeft;
    [SerializeField]Button btnRight;
    [SerializeField] GameObject character;
    [SerializeField] RuntimeAnimatorController[] animatorController;
    int currentCharIndex;
    Animator animator;
    [SerializeField] PlayerData playerData;
    // Start is called before the first frame update
    void Start()
    {
        animator = character.GetComponent<Animator>();
        animator.Play("Run");
        btnLeft.onClick.AddListener(() => ChangeCharacter(currentCharIndex - 1));
        btnRight.onClick.AddListener(() => ChangeCharacter(currentCharIndex + 1));
    }
    void ChangeCharacter(int index)
    {
        if (index < 0) index = animatorController.Length - 1;
        if(index > animatorController.Length -1) index = 0;
        animator.runtimeAnimatorController = animatorController[index];
        currentCharIndex = index;
    }

    //Go to Gaame DataProvider
    void PlayerDataProvide()
    {
        playerData.fruit = 0;
        playerData.life = 3;
        playerData.controller = animatorController[currentCharIndex];
    }
    public void SetSceneData(string currentScene, string nextScene)
    {
        playerData.currentScene = currentScene;
        playerData.nextScene = nextScene;
    }
    public void OnClickStartGame()
    {
        PlayerDataProvide();
        SceneController.Instance.LoadScene("Level1");
    }
    public void OnClickSelectLevel()
    {
        PlayerDataProvide();
        SceneController.Instance.LoadScene("Level Select");
    }
    public void OnAppExitClick()
    {
        Application.Quit();
    }
}
