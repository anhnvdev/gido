using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    [SerializeField] RectTransform btnResume;
    [SerializeField] RectTransform btnRestart;
    [SerializeField] RectTransform btnLevelSelect;
    [SerializeField] RectTransform btnMainMenu;
    [SerializeField] RectTransform btnNextLevel;
    [SerializeField] TextMeshProUGUI txtPause;
    [SerializeField] private States state;

    public States State { get => state; set => state = value; }

    public enum States
    {
        Pause, NextLevel, GameOver
    }
    private void Awake()
    {
        State= States.Pause;
    }
    public void OnStateChange(States st)
    {
        state = st;
        switch(state)
        {
            case States.Pause:
            {
                    txtPause.text = "Game Paused";
                    btnResume.gameObject.SetActive(true);
                    btnRestart.gameObject.SetActive(true);
                    btnLevelSelect.gameObject.SetActive(true);
                    btnResume.anchoredPosition = new Vector3(-215f, -40f, 0);
                    btnRestart.anchoredPosition = new Vector3(0, -40f, 0);
                    btnLevelSelect.anchoredPosition = new Vector3(215f, -40f, 0);
                    btnNextLevel.gameObject.SetActive(false);
                    break;
            }
            case States.NextLevel:
            {
                    btnResume.gameObject.SetActive(false);
                    btnLevelSelect.gameObject.SetActive(true);
                    btnNextLevel.gameObject.SetActive(true);
                    btnRestart.gameObject.SetActive(true);
                    btnRestart.anchoredPosition = new Vector3(-215f, -40f, 0);
                    btnLevelSelect.anchoredPosition = new Vector3(0, -40f, 0);
                    btnNextLevel.anchoredPosition = new Vector3(215f, -40f, 0);
                    txtPause.text = "Level Completed!";
                    break;
            }
            case States.GameOver:
            {
                    txtPause.text = "Game Over";
                    btnResume.gameObject.SetActive(false);
                    btnLevelSelect.gameObject.SetActive(true);
                    btnNextLevel.gameObject.SetActive(false);
                    btnRestart.gameObject.SetActive(true);
                    btnRestart.anchoredPosition = new Vector3(-120f, -40f, 0);
                    btnLevelSelect.anchoredPosition = new Vector3(120, -40f, 0);
                    break;
            }
        }
    }
}
