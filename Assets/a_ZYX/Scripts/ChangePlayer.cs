using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using Debug = System.Diagnostics.Debug;

[System.Serializable]
public class PlayerRAMItemData
{
    //人物姓名
    public string name;
    //角色职业
    public Weapon.ProfessionalType sq;
    //角色等级
    public int level;
    //角色经验
    public int exp;
    //角色物品栏 存储的道具编号
    public int[] itemid = new[] {0, 0, 0, 0, 0, 0, 0, 0};
}
[System.Serializable]
public class PlayerItemRAM
{ 
    //角色  id
    public int playerid;
    //角色信息
    public PlayerRAMItemData playerRamItemData=new PlayerRAMItemData();
}
[System.Serializable]
public class SavePlayerItem
{
    public List<PlayerItemRAM> list = new List<PlayerItemRAM>();
}


public class ChangePlayer : MonoBehaviour
{
    public int id;
    public CreatePlayerList playerList;
    private Button changebtn;
    private Text playerName;

    void Awake()
    {
        playerList = PlayerInfoPanel.Instance.LoadPlayerDataById(id, playerList);
    }
    
    void Start()
    {
        playerName = transform.GetChild(0).GetComponent<Text>();
        playerName.text = playerList.playerItemRam.playerRamItemData.name;
        changebtn = GetComponent<Button>();
        changebtn.onClick.AddListener(()=>
        {
            PlayerInfoPanel.Instance.SetChanegPlayer(this);
            PlayerInfoPanel.Instance.LoadPlayerRAMById(playerList.playerItemRam.playerid);
        });
    }

     private void CleanData()
     {
         playerList.playerItemRam.playerRamItemData.exp = 0;
         playerList.playerItemRam.playerRamItemData.level = 0;
         playerList.playerItemRam.playerRamItemData.name = null;
         playerList.playerItemRam.playerRamItemData.sq= 0;
         for (int i = 0; i < 8; i++)
         {
             playerList.playerItemRam.playerRamItemData.itemid[i] = 0;
         }
     }
     void OnApplicationQuit()
     {
         CleanData();
     }


}
