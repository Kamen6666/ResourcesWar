using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
   public void Show()
   {
      Weapon weapon = new Weapon(1, "32", Item.ItemType.Consumable, Item.Quality.Common, "ewe", 23, 123
         , "dsd", 23, 32, Weapon.WeaponType.MainHand, Weapon.ProfessionalType.Basics);
   }
}
