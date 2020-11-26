using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LitJson;
using UnityEngine;
using UnityEngine.UI;
using Debug = System.Diagnostics.Debug;

public class DataMrg : MonoBehaviour
{
    public static DataMrg Instance;

    private void Awake()
    {
        Instance = this;
    }

    private List<int> playerIdList;


    /// <summary>
    /// 保存玩家数据
    /// </summary>
    /// <param name="playerItemRam"></param>
    public void Save(SavePlayerItem savePlayerItem)
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

    /// <summary>
    /// 保存玩家信息
    /// </summary>
    public void SavePlayerItem(ItemsData items)
    {
        string filePath = Application.streamingAssetsPath + @"/PlayerItemData.json";

        //找到当前路径
        FileInfo file = new FileInfo(filePath);
        //判断有没有文件，有则打开文件，，没有创建后打开文件
        StreamWriter sw = file.CreateText();
        //ToJson接口将你的列表类传进去，，并自动转换为string类型
        string json = JsonMapper.ToJson(items);
        //将转换好的字符串存进文件，
        sw.WriteLine(json);
        sw.Close();
        sw.Dispose();
    }

    public string SavePlayerIte<T>(T t)
    {
        return JsonMapper.ToJson(t);
    }

    /// <summary>
    /// 加载玩家信息
    /// </summary>
    public void LoadPlayerItem()
    {

    }

    #region 解析玩家数据

    /// <summary>
    /// 解析json数据
    /// </summary>
    /// <returns></returns>
    public SavePlayerItem ParsePlayerItemJson()
    {
        string path = Application.streamingAssetsPath + "/PlayerInfoData.json";
        string result = File.ReadAllText(path, Encoding.UTF8);
        SavePlayerItem obj = JsonMapper.ToObject<SavePlayerItem>(result);
        return obj;
    }

    
    public ItemsData ParsePlayerItemBag()
    {
        string path = Application.streamingAssetsPath + "/PlayerItemData.json";
        string result = File.ReadAllText(path, Encoding.UTF8);
        ItemsData obj = JsonMapper.ToObject<ItemsData>(result);
        return obj;
    }
    
    public Object ParseData(string path)
    {
        string result = File.ReadAllText(path, Encoding.UTF8); 
        return JsonMapper.ToObject<Object>(result);
        
    }

    #endregion
}
