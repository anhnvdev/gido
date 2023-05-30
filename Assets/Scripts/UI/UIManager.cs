
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] TextMeshProUGUI txtLife;
    [SerializeField] TextMeshProUGUI txtFruit;
    [SerializeField] GameObject pauseUI;
    PauseUI pauseScripts;
    int moveAxis;
    bool jumpButtonDown = false;
    bool fireButtonDown = false;

    public int MoveAxis { get => moveAxis; }
    public bool JumpButtonDown { get => jumpButtonDown;}
    public bool FireButtonDown { get => fireButtonDown;}

    private void Start()
    {
       pauseScripts = pauseUI.GetComponent<PauseUI>();
       pauseUI.SetActive(false);
       UpdateUI();
    }
    public void GameOverUI()
    {
        Time.timeScale = 0.0f;
        pauseScripts.OnStateChange(PauseUI.States.GameOver);
        pauseUI.SetActive(true);
    }
    public void NextLevelUI()
    {
        Time.timeScale = 0.0f;
        pauseScripts.OnStateChange(PauseUI.States.NextLevel);
        pauseUI.SetActive(true);
    }
    public void OnPauseUI()
    {
        Time.timeScale = 0.0f;
        pauseScripts.OnStateChange(PauseUI.States.Pause);
        pauseUI.SetActive(true);
    }
    public void OffPauseUI()
    {
        Time.timeScale = 1.0f;
        pauseUI.SetActive(false);
    }
    public void Restart()
    {
        GameController.Instance.OnCharacterRestart();
        OffPauseUI();
    }
    public void NextLevel()
    {
        OffPauseUI();
        SceneController.Instance.NextScene();
    }
    public void GoToMainMenu() {
        SceneController.Instance.LoadMenuScene("MainMenu");
        OffPauseUI();
    }
    public void LevelSelectUI()
    {
        SceneController.Instance.LoadMenuScene("Level Select");
        OffPauseUI();
    }

    public void UpdateUI()
    {
        txtLife.text = "X" + PlayerInventory.Instance.PlayerLife.ToString();
        txtFruit.text = PlayerInventory.Instance.Fruit.ToString();
    }
    public void ButtonLeftHolding(bool holding)
    {
        if (holding)
        {
            moveAxis = -1;
            return;
        }
        moveAxis = 0;
    }
    public void ButtonRightHolding(bool holding) 
    {
        if (holding)
        {
            moveAxis = 1;
            return;
        }
        moveAxis = 0;
    }
    public void ButtonJumpHolding(bool holding)
    {
        jumpButtonDown = holding;
    }
    public void ButtonFireHolding(bool holding)
    {
        fireButtonDown = holding;
    }
}
