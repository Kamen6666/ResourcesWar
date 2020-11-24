using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
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
      Equipment,
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

   public virtual string GetToolTipText()
   {
      string color = "";
      switch (quality)
      {
         case Quality.Common:
            color = "white";
            break;
         case Quality.Uncomman:
            color = "line";
            break;
         case Quality.Epic:
            color = "magenta";
            break;
         case Quality.Legendary:
            color = "orange";
            break;
      }
      string text = string.Format("<color={0}><size=35>{1}</size></color>\n" +
                                  "<color=blue><size=30>购买价格:{4}\n" +
                                  "出售价格:{2}</size></color>\n" +
                                  "<color=yellow><size=25>{3}</size></color>\n", color, Name, SellPrice, Description,BuyPrice);

      return text;

   }
}
