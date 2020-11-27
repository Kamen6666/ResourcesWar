using System.Collections;
using System.Collections.Generic;
using UIFrame;
using UnityEngine;
using UnityEngine.UI;
using Debug = System.Diagnostics.Debug;

public class PlayerInfoPanel : Inventory
{
   public static PlayerInfoPanel Instance;
   private void Awake()
   {
      playerItem = DataMrg.Instance.ParsePlayerItemJson();
      Instance = this;
   }
   public GameObject playerList;
   private ChangePlayer[] changePlayers;
   public ChangePlayer changePlayer;
   public bool isLoad = false;
   
   public Text name;
   public Text sq;
   public Text level;
   public Text exp;
   
   
   public PlayerSlot[] playerSlots;
   private SavePlayerItem playerItem;
   private PlayerSlot mainHandSlot;
   private PlayerSlot offHanSlot;
   private PlayerSlot equiment;
   

   public override void Start()
   {
      
      base.Start();
    
      LoadPlayerRAMById(0);
      
      mainHandSlot = transform.Find("Item/MainHand").GetComponent<PlayerSlot>();
      offHanSlot = transform.Find("Item/OffHand").GetComponent<PlayerSlot>();
      equiment = transform.Find("Item/Equiment").GetComponent<PlayerSlot>();

   }

   public void SetChanegPlayer(ChangePlayer changePlayer)
   {
      this.changePlayer = changePlayer;
   }
   /// <summary>
   /// 更新玩家数据界面
   /// </summary>
   public void UpdatePlayerInfoPanel(ChangePlayer changePlayer)
   {
      
   }

   /// <summary>
   /// 保存玩家信息
   /// </summary>
   public void SaveAllPlayerInfo()
   {
      changePlayers = playerList.GetComponentsInChildren<ChangePlayer>();
      SavePlayerItem savePlayerItem=new SavePlayerItem();
      savePlayerItem.list=new List<PlayerItemRAM>();
      for (int i = 0; i < changePlayers.Length; i++)
      {
         savePlayerItem.list.Add(changePlayers[i].playerList.playerItemRam);
      }
      DataMrg.Instance.Save(savePlayerItem);
   }
   
   
   public void RefeshPlayerItem(int id)
   {
      changePlayers = playerList.GetComponentsInChildren<ChangePlayer>();
      for (int i = 0; i < changePlayers.Length; i++)
      {
         if (changePlayers[i].playerList.playerItemRam.playerid==id)
         {
        
            for (int j = 0; j < playerSlots.Length; j++)
            {
               if (playerSlots[j].transform.childCount>0)
               {
  //                print(playerSlots[j].name);
//                  print( changePlayers[i].playerItemRam.playerRamItemData.itemid[j]);
                  changePlayers[i].playerList.playerItemRam.playerRamItemData.itemid[j] =
                     playerSlots[j].transform.GetChild(0).GetComponent<ItemUI>().Item.ID;
               }
               else
               {
                  changePlayers[i].playerList.playerItemRam.playerRamItemData.itemid[j] = 0;
               }
            }
         }
      }
    
   }

   public bool isClick = false;
   public CreatePlayerList LoadPlayerDataById(int id,CreatePlayerList playerList)
   {
      playerList.playerItemRam.playerid=playerItem.list[id].playerid;
      playerList.playerItemRam.playerRamItemData.name = playerItem.list[id].playerRamItemData.name;
      playerList.playerItemRam.playerRamItemData.sq = playerItem.list[id].playerRamItemData.sq;
      playerList.playerItemRam.playerRamItemData.level = (playerItem.list[id].playerRamItemData.level);
      playerList.playerItemRam.playerRamItemData.exp = (playerItem.list[id].playerRamItemData.exp);
      for (int j = 0; j < 8; j++)
      {
         playerList.playerItemRam.playerRamItemData.itemid[j] = playerItem.list[id].playerRamItemData.itemid[j];
      }

      return playerList;
   }
   public void LoadPlayerRAMById(int id)
   {
      name.text = playerItem.list[id].playerRamItemData.name;
      sq.text = playerItem.list[id].playerRamItemData.sq.ToString();
      level.text = (playerItem.list[id].playerRamItemData.level).ToString();
      exp.text = (playerItem.list[id].playerRamItemData.exp).ToString();
      for (int j = 0; j < 8; j++)
      {
         if (playerSlots[j].transform.childCount>0)
         {
            DestroyImmediate(playerSlots[j].transform.GetChild(0).gameObject);
         }
         Item item=InventoryManager.Instance.GetItemById(changePlayer.playerList.playerItemRam.playerRamItemData.itemid[j]);
         if (item!=null)
         {
            playerSlots[j].StoreSlotItem(item);
         }
      }
   }

   public void OnSkillClick()
   {
      UIManager.GetInstance().PushModule("SkillTree_Panel");
   }
}

