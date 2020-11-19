using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
   public int ID { get; set; }
   public string Name { get; set; }
   public ItemType itemType { get; set; }
   public Quality quality { get; set; }
   public string Description { get; set; }
   public int BuyPrice { get; set; }
   public int SellPrice { get; set; }
   public string Sprite { get; set; }

   public Item(int id,string name,ItemType itemType,Quality quality,string description,int buyPrice,int sellPrice,string sprite)
   {
      this.ID = id;
      this.Name = name;
      this.itemType = itemType;
      this.quality = quality;
      this.Description = description;
      this.BuyPrice = buyPrice;
      this.SellPrice = sellPrice;
      this.Sprite = sprite;
   }

   public enum ItemType
   {
      Consumable,
      Equioment,
      Weapon,
      Materail
   }
   /// <summary>
   /// 品质
   /// </summary>
   public enum Quality
   {
      Common,
      Uncomman,
      /// <summary>
      /// 史诗
      /// </summary>
      Epic,
      /// <summary>
      /// 传说
      /// </summary>
      Legendary
   }
}
