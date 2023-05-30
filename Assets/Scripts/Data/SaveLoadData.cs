
using UnityEngine;

public class SaveLoadData : MonoSingleton<SaveLoadData>
{
    int life;
    int fruit;
    int sceneIndex;
    [SerializeField] PlayerData playerData;

    public int Life { get => life;}
    public int Fruit { get => fruit;}

    //string sceneName;
    public void GetData()
    {
        life = PlayerInventory.Instance.PlayerLife;
        fruit = PlayerInventory.Instance.Fruit;
    }
    private void PushData()
    {
        PlayerInventory.Instance.SetPlayerLife(life);
        PlayerInventory.Instance.SetFruit(fruit);
    }
    public void LoadData()
    {
        GetData();
        this.life = playerData.life;
        this.fruit = playerData.fruit;

    }
    public void SaveData()
    {
        playerData.life = this.life;
        playerData.fruit = this.fruit;
        PushData();
    }
}
