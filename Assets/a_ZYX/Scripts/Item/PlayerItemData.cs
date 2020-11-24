using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerItemData
{
   public string name;
   public string sq;
   public int level;
   public int exp;
   public List<int> eqCom;

   public PlayerItemData(string name, string sq, int level, int exp)
   {
      //角色姓名
      this.name = name;
      this.sq = sq;
      this.level = level;
      this.exp = exp;
      this.eqCom = new List<int>();
      for (int i = 0; i < 8; i++)
      {
         eqCom.Add(0);
      }
   }
}
[System.Serializable]
public class PlayerItemDataList
{
   public int id;
   public PlayerItemData list;
   public PlayerItemDataList(int id, PlayerItemData list)
   {
      this.list = list;
      this.id = id;
   }
}
[System.Serializable]
public class PlayerList
{
   public List<PlayerItemDataList> list;

   public PlayerList()
   {
      list=new List<PlayerItemDataList>();
   }
}



