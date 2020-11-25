using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LitJson;
using UnityEngine;
using UnityEngine.UI;
public class DataMrg : MonoBehaviour
{
    public static DataMrg Instance;

    private void Awake()
    {
        Instance = this;
    }
    
     private List<int> playerIdList;

    #region tmp

    
/*public void SavePlayerDataJson()
    {
        changePlayers = playerlistobj.GetComponentsInChildren<ChangePlayer>();

        //   PlayerList tmp=new PlayerList();
       // PlayerItemDataList ttt=new PlayerItemDataList(1,new PlayerItemData("12","121",3,3));
        //tmp.list.Add(ttt);
        PlayerItemDataList playerItemDataList;
        PlayerItemData playerItemData;
        
        for (int j = 0; j < changePlayers.Length; j++)
        {
            int id = changePlayers[j].id;
            playerItemData=new PlayerItemData(name.text ,pro.text,int.Parse(level.text),int.Parse(exp.text));
            for (int i = 0; i < playerItemList.Count; i++)
            {
                if (playerItemList[i].childCount>0)
                {
                    playerItemData.eqCom[i] = playerItemList[i].GetChild(0).GetComponent<ItemUI>().Item.ID;
                }
            }
            playerItemDataList=new PlayerItemDataList(id,playerItemData);
            Save(playerItemDataList);
        }
    }*/
 
    /*
    public void Save(PlayerItemDataList playerItemDataList)
    {
        playerList=new PlayerList();
        string filePath = Application.streamingAssetsPath + @"/PlayerInfoData.json";
        if (!File.Exists(filePath))
        {          
            playerList.list.Add(playerItemDataList);
        }
        else
        {
            //若没有信息则新建，有则 更新，，，
            bool bFind = false;
            //遍历列表
            for (int i = 0; i < playerList.list.Count; i++)
            {
                PlayerItemDataList dataList = playerList.list[i];
                for (int j= 0; j < playerList.list.Count; j++)
                {                
                    PlayerItemData savePlayer = dataList.list;
                    if (playerItemDataList.list.name == savePlayer.name)
                    {
                        savePlayer.sq = playerItemDataList.list.sq;
                        savePlayer.level = playerItemDataList.list.level;
                        savePlayer.exp = playerItemDataList.list.exp;
                        for (int k = 0; k < savePlayer.eqCom.Count; k++)
                        {
                            savePlayer.eqCom[i] = savePlayer.eqCom[i];
                        }
                        bFind = true;
                        break;
                    }
                }
            }
            
            if (!bFind)
            {
                playerList.list.Add(playerItemDataList);
            }
        }
        

        //找到当前路径
        FileInfo file = new FileInfo(filePath);
        //判断有没有文件，有则打开文件，，没有创建后打开文件
        StreamWriter sw = file.CreateText();
        //ToJson接口将你的列表类传进去，，并自动转换为string类型
        string json = JsonMapper.ToJson(playerList);
        //将转换好的字符串存进文件，
        sw.WriteLine(json);
        sw.Close();
        sw.Dispose();
    }
    */

    #endregion
    
    /// <summary>
    /// 保存玩家数据
    /// </summary>
    /// <param name="playerItemRam"></param>
    public void Save(SavePlayerItem  savePlayerItem)
    {
        
        string filePath = Application.streamingAssetsPath + @"/PlayerInfoData.json";

        //找到当前路径
        FileInfo file = new FileInfo(filePath);
        //判断有没有文件，有则打开文件，，没有创建后打开文件
        StreamWriter sw = file.CreateText();
        //ToJson接口将你的列表类传进去，，并自动转换为string类型
        string json = JsonMapper.ToJson(savePlayerItem);
        //将转换好的字符串存进文件，
        sw.WriteLine(json);
        sw.Close();
        sw.Dispose();
    }

    #region 解析玩家数据

    /// <summary>
    /// 解析json数据
    /// </summary>
    /// <returns></returns>
    public SavePlayerItem ParsePlayerItemJson()
    {
        string path = Application.streamingAssetsPath + @"/PlayerInfoData.json";
        string result = File.ReadAllText(path, Encoding.UTF8);
        SavePlayerItem obj = new SavePlayerItem();
        obj = JsonUtility.FromJson<SavePlayerItem>(result);
        return obj;
    }
    
    
    #endregion
}
