using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoSingleton<GameController>
{
    [SerializeField] Transform beginCheckpoint;
    [SerializeField] Vector2 lastCheckPoint;
    [SerializeField] GameObject player;
    [SerializeField] PlayerData playerData;

    void Start()
    {
    }
    public void Save()
    {
        SaveLoadData.Instance.SaveData();
    }
    public void Load()
    {
        SaveLoadData.Instance.LoadData();
    }
    public void StartLevelCharacterSpawn()
    {
        Load();
        beginCheckpoint = GameObject.FindGameObjectWithTag("CheckPointStart").transform;
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "MainMenu" || currentScene == "Level Select") return;
        lastCheckPoint = beginCheckpoint.transform.position;
        CharacterInstantiate();
        if (player == null)
        {
            Debug.LogError("Can't get player or there are no player in this scene");
            return;
        }
        CameraHandle.Instance.SetTarget(player.transform);
    }
    public void CharacterInstantiate()
    {
        player = Instantiate(player, lastCheckPoint, Quaternion.identity);
        Animator animator= player.GetComponent<Animator>();
        animator.runtimeAnimatorController = playerData.controller;
    }
    public void OnPlayerLevelCompleted()
    {
        Save();
        UIManager.Instance.NextLevelUI();
    }
    public void OnPlayerRespawn()
    {
        if(PlayerInventory.Instance.PlayerLife <= 0)
        {
            UIManager.Instance.GameOverUI();
            return;
        }
        PlayerInventory.Instance.PlayerLifeChange(-1);
        player.transform.position = PlayerInventory.Instance.PlayerLastCheckPoint;
    }
    public void OnCharacterRestart()
    {
        player.transform.position = PlayerInventory.Instance.PlayerLastCheckPoint;
    }
}
