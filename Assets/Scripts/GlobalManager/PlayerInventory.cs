using UnityEngine;

public class PlayerInventory : MonoSingleton<PlayerInventory>
{
    private int playerLife;
    private int fruit;
    private Vector2 playerLastCheckPoint;
    private RuntimeAnimatorController animController;
    [SerializeField] PlayerData playerData;

    public int PlayerLife { get => playerLife; }
    public int Fruit { get => fruit; }
    public Vector2 PlayerLastCheckPoint { get => playerLastCheckPoint;}
    public RuntimeAnimatorController AnimController { get => animController;}
    public PlayerData PlayerData { get => playerData; set => playerData = value; }

    public void FruitChange(int fruit)
    {
        this.fruit += fruit;
        if(this.fruit < 0) this.fruit = 0;
        UIManager.Instance.UpdateUI();
    }
    public void PlayerLifeChange(int playerLife)
    {
        this.playerLife += playerLife;
        if (this.playerLife < 0) this.playerLife = 0;
        UIManager.Instance.UpdateUI();
    }
    public void SetCheckPoint(Vector2 checkPoint)
    {
        this.playerLastCheckPoint = checkPoint;
    }
    public void SetPlayerLife(int playerLife)
    {
        this.playerLife = playerLife;
        UIManager.Instance.UpdateUI();
    }
    public void SetFruit(int fruit)
    {
        this.fruit = fruit;
        UIManager.Instance.UpdateUI();
    }
    public void SetCharacter(RuntimeAnimatorController refAnimController)
    {
        animController = refAnimController;
    }
}
