using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using Debug = System.Diagnostics.Debug;

public class KnapsackPanel : Inventory
{
    private Button sort;
    
    public static KnapsackPanel Instance;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            KnapsackPanel.Instance.Hide();
        }
    }
    
    private void Awake()
    {
        Instance = this;
    }

    public override void Start()
    { 
        sort = transform.Find("Sort").GetComponent<Button>();
        sort.onClick.AddListener(() =>
        {
            base.SortSlot();
        }); 
        base.Start();
    }
    /// <summary>
    /// 保存玩家信息
    /// </summary>
    public void SaveAllPlayerInfo()
    {
        ItemsData itemsData=new ItemsData();
        itemsData.list=new List<ItemData>();
        for (int i = 0; i < slotList.Length; i++)
        {
            Transform slot=slotList[i].transform;
            if (slot.childCount>0)
            {
               
                ItemData itemData=new ItemData();
                itemData.amount = slot.GetChild(0).GetComponent<ItemUI>().Amount;
                itemData.id = slot.GetChild(0).GetComponent<ItemUI>().Item.ID;
                itemsData.list.Add(itemData);
            }
        }
        DataMrg.Instance.SavePlayerItem(itemsData);
    }

    public void LoadAllPlayerBagInfo()
    {
        string path = Application.streamingAssetsPath + "/PlayerItemData.json";
        ItemsData itemsData = DataMrg.Instance.ParsePlayerItemBag();
        print(itemsData.list.Count);
        for (int i = 0; i < itemsData.list.Count; i++)
        {
            Item item = InventoryManager.Instance.GetItemById(itemsData.list[i].id);
            for (int j = 0; j < itemsData.list[i].amount; j++)
            {
                StoreItem(item);
            }
           
        }
    }
    
}
