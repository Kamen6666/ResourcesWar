using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public PlayerItemRAM playerItemRam;

    private Text playerName;

    private void Start()
    {
        playerName = transform.GetChild(0).GetComponent<Text>();
        playerName.text = playerItemRam.playerRamItemData.name;

    }
    // Start is called before the first frame update
}
