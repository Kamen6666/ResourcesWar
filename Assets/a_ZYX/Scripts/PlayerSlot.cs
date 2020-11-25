using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Debug = System.Diagnostics.Debug;

public class PlayerSlot : Slot
{
    public Weapon.WeaponType weaponType;
    public Equipment.EquimentType equimentType;
    public Consumable.ConsumableType consumableType;
    private bool IsRightItem(Item item)
    {
        //
        if ((item is Equipment && ((Equipment) item).equimentType == this.equimentType) ||
            (item is Weapon && ((Weapon)item).weaponType == this.weaponType)||
            item is Consumable&&((Consumable)item).consumableType==this.consumableType)
        {
            print("True  coming~!!!!");
            return true;
        }

        return false;
    }
    
    

    public override void OnPointerDown(PointerEventData eventData)
    {
        KnapsackPanel.Instance.Show();
        
        if (InventoryManager.Instance.IsPickedItem)
        {
            ItemUI pickedItem = InventoryManager.Instance.PickedItem;
            if (transform.childCount>0)
            {
                ItemUI currentItemUI = transform.GetChild(0).GetComponent<ItemUI>();
                if (IsRightItem(currentItemUI.Item))
                {
                }
            }
            //无装备
            else
            {
                if (IsRightItem(pickedItem.Item))
                {
                    
                    this.StoreSlotItem(InventoryManager.Instance.PickedItem.Item);
                    InventoryManager.Instance.RemoveOneItem();
                }
            }
        }
        else
        {
            if (transform.childCount>0)
            {
                Item item=transform.GetChild(0).GetComponent<ItemUI>().Item;
                KnapsackPanel.Instance.StoreItem(item);
                Destroy(transform.GetChild(0).gameObject);
            }
        }
    }
}
