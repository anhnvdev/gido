using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SceneButton : MonoBehaviour,IPointerDownHandler
{
    int id;
    public int Id { get => id; set => id = value; }
    bool isEnabled = true;
    [SerializeField] TextMeshProUGUI txtSceneName;
    [SerializeField] Image imgLock;
    [SerializeField] PlayerData playerData;
    public void SetSceneName()
    {
        txtSceneName.text = id.ToString();
        this.gameObject.SetActive(true);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        playerData.life = 3;
        playerData.fruit = 0;
        if(!isEnabled) return;
        if(id ==1)
        {
            SceneController.Instance.LoadMenuScene("Level1");
            return;
        }
        if (id > 1)
        {
            playerData.nextScene = "Level" + (id);
            SceneController.Instance.LoadScene("TempScene");
        }
    }
    public void SetStatus(bool active)
    {
        if(!active)
        {
            imgLock.enabled = true;
            Button btn = GetComponent<Button>();
            btn.interactable = false;
            isEnabled = false;
        }
        else
        {
            imgLock.enabled = false;
            Button btn = GetComponent<Button>();
            btn.interactable = true;
            isEnabled = true;
        }
    }
}
