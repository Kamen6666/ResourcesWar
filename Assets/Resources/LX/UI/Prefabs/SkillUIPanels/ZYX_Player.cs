using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = System.Diagnostics.Debug;
using LitJson;

public class Person
{
    public string name="zhangsan";
    public int age=10;

   
}
public class ZYX_Player : MonoBehaviour
{
    private string json;
    /// <summary>
    /// 存储json
    /// </summary>
    public void SaveJson()
    {
        Person zhangsan=new Person();
        json = JsonMapper.ToJson(zhangsan);
        print(json);
    }

    public void ParseJson()
    {
        Person person = JsonMapper.ToObject<Person>(json);
        print("1    " + person.name +"|"+person.age);
    }

    public void ParseJson2()
    {
        JsonData jsonData = JsonMapper.ToObject(json);
        print("2     "+jsonData["name"]+"|"+jsonData["age"]);
    }



    public void Start()
    {
        SaveJson();
        ParseJson();
        ParseJson2();
    }









// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            int a = Random.Range(1, 16);
            KnapsackPanel.Instance.StoreItem(a);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
             KnapsackPanel.Instance.SaveAllPlayerInfo();
            //PlayerInfoPanel.Instance.RefeshPlayerItem(0);
            //  DataMrg.Instance.SavePlayerDataJson();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            PlayerInfoPanel.Instance.SaveAllPlayerInfo();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            InventoryManager.Instance.GetItemById(10);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            KnapsackPanel.Instance.LoadAllPlayerBagInfo();
        }
        
    }
}
