using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using LitJson;
public class InventoryManager : MonoBehaviour
{
    #region 单例

    public static InventoryManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion
    /// <summary>
    /// 物品列表
    /// </summary>
    public List<Item> itemList;
    
    
    private void Start()
    {
        ParseItemJson();
        Show(10);
    }

    #region 解析json数据

       private void ParseItemJson()
    {
       itemList=new List<Item>();

       string path = Application.streamingAssetsPath + "/ItemJson.json";
       StreamReader tmpReader = File.OpenText(path);
       string result = tmpReader.ReadToEnd();
       JsonData itemdata=JsonMapper.ToObject(result);

       for (int i = 0; i < itemdata.Count; i++)
       {
//           Debug.Log("i======"+i);
           int id = (int) itemdata[i]["id"];
           string name = itemdata[i]["name"].ToString();
           string typeStr = itemdata[i]["type"].ToString();
           Item.ItemType itemType = (Item.ItemType) System.Enum.Parse(typeof(Item.ItemType), typeStr);
           string qualityStr = itemdata[i]["quality"].ToString();
           Item.Quality quality = (Item.Quality) System.Enum.Parse(typeof(Item.Quality), qualityStr);
           string description = itemdata[i]["description"].ToString();
           int buyPrice = (int)itemdata[i]["buyPrice"];
           int sellPrice = (int) itemdata[i]["sellPrice"];
           string sprite = itemdata[i]["sprite"].ToString();

           Item item = null;
           switch (itemType)
           {
               //消耗品
               case Item.ItemType.Consumable:
                   int hp = (int) itemdata[i]["hp"];
                   int mp = (int) itemdata[i]["mp"];
                   item=new Consumable(id,name,itemType,quality,description,buyPrice,sellPrice,sprite,hp,mp);
                   break;
               //装备
               case Item.ItemType.Equipment:
                   int physical_Defence = (int) itemdata[i]["physical_Defence"];
                   int magical_Defence=(int)itemdata[i]["magical_Defence"];
                   item=new Equipment(id,name,itemType,quality,description,buyPrice,sellPrice,sprite,physical_Defence,magical_Defence);
                   break;
               //武器
               case Item.ItemType.Weapon:
                   int physical_Damage = (int) itemdata[i]["physical_Damage"];
                   int magical_Damage = (int) itemdata[i]["magical_Damage"];
                   string weaponTypeStr = itemdata[i]["weaponType"].ToString();
                   Weapon.WeaponType weaponType = (Weapon.WeaponType) System.Enum.Parse(typeof(Weapon.WeaponType),weaponTypeStr);
                   string professionalTypeStr = itemdata[i]["professionalType"].ToString();
                   Weapon.ProfessionalType professionalType =
                       (Weapon.ProfessionalType) System.Enum.Parse(typeof(Weapon.ProfessionalType),
                           professionalTypeStr);
                   if (professionalType==Weapon.ProfessionalType.Hunter)
                   {
                       int attackRange =(int) itemdata[i]["attackRange"];
                       item=new Weapon(id,name,itemType,quality,description,buyPrice,sellPrice,sprite,physical_Damage,magical_Damage,weaponType,
                           professionalType,attackRange);
                   }
                   else
                   {
                       item=new Weapon(id,name,itemType,quality,description,buyPrice,sellPrice,sprite,physical_Damage,magical_Damage,weaponType,
                           professionalType);
                   }
                   break;
               case Item.ItemType.Materail:
                   break;
           }
           itemList.Add(item);

       }
    }

    #endregion

    private void Show(int id)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (i==id)
            {
                Debug.Log(itemList[i].ID+"|"+itemList[i].Name+"|"+itemList[i].itemType+"|"+itemList[i].quality
                +"|"+itemList[i].Description+"|"+itemList[i].BuyPrice+"|"+itemList[i].SellPrice+"|"+itemList[i].Sprite);
            }
           
        }
    }
    
}
