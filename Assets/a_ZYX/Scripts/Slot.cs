using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;
using Debug = System.Diagnostics.Debug;

public class Slot : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler
{

    public GameObject itemPrefab;
    public GameObject itemObj;
    public void StoreSlotItem(Item item)
    {
        if (transform.childCount==0)
        {
            GameObject itemGameObject = Instantiate(itemPrefab);
            itemObj = itemGameObject;
            itemGameObject.transform.SetParent(transform);
            itemGameObject.transform.localPosition=Vector3.zero;
            //itemGameObject.transform.localScale = Vector3.one;
            itemGameObject.GetComponent<ItemUI>().SetItem(item);
        }
        else
        {
            transform.GetChild(0).GetComponent<ItemUI>().AddAmount();
        }
    }
   

    public void SetItemUI(GameObject itemUI)
    { 
        GameObject itemGameObject = Instantiate(itemPrefab);
        itemGameObject.transform.SetParent(transform);
        itemGameObject.transform.localPosition = Vector3.zero;
        //Debug.Log(itemUI.transform.GetChild(0).GetComponent<ItemUI>().Item+"|"+itemUI.transform.GetChild(0).GetComponent<ItemUI>().Amount);
        itemGameObject.GetComponent<ItemUI>().SetItem(itemUI.transform.GetChild(0).GetComponent<ItemUI>().Item,itemUI.transform.GetChild(0).GetComponent<ItemUI>().Amount);
    }

    /// <summary>
    /// 得到当前物品槽的ID
    /// </summary>
    /// <returns></returns>
    public int GetItemID()
    {
        return transform.GetChild(0).GetComponent<ItemUI>().Item.ID;
    }
    
    public void Clear()
    {
        Destroy(transform.Find("Item(Clone)").gameObject);
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        if (transform.childCount>0)
        {
            string toolTipTxt = transform.GetChild(0).GetComponent<ItemUI>().Item.GetToolTipText();
            InventoryManager.Instance.ShowToolTip(toolTipTxt);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        InventoryManager.Instance.HideTooolTip();
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
//        print("Dowm");
        if (transform.childCount>0)
        {
            ItemUI currentItem = transform.GetChild(0).GetComponent<ItemUI>();
//            print(InventoryManager.Instance.PickedItem.Item.ID); 
           // print(currentItem.Item.ID + "|" + InventoryManager.Instance.PickedItem.Item.ID);
            if (InventoryManager.Instance.IsPickedItem==false)
            {
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    int amountPiced = (currentItem.Amount + 1) / 2;
                    InventoryManager.Instance.PickupItem(currentItem.Item,amountPiced);
                    int amountRemained = currentItem.Amount - amountPiced;
                    if ((amountRemained)<=0)
                    {
                        Destroy(currentItem.gameObject);
                    }
                    else
                    {
                        currentItem.SetAmount(amountRemained);
                    }
                }
                else
                {
                    InventoryManager.Instance.PicedUpItem(currentItem.Item, currentItem.Amount);
                    Destroy(currentItem.gameObject);
                }
            }
            else
            {
                if (currentItem.Item.ID==InventoryManager.Instance.PickedItem.Item.ID)
                {
                    print("currentItem.Item.ID==InventoryManager.Instance.PickedItem.Item.ID");
                    if (Input.GetKey(KeyCode.LeftControl))
                    {
                        currentItem.AddAmount();
                        InventoryManager.Instance.RemoveOneItem();
                    }
                    else
                    {
                        currentItem.SetAmount(currentItem.Amount+InventoryManager.Instance.PickedItem.Amount);
                        InventoryManager.Instance.RemoveAlllItem();
                    }
                }
                else
                {
                    Item item = currentItem.Item;
                    int amount = currentItem.Amount;
                    currentItem.SetItem(InventoryManager.Instance.PickedItem.Item,InventoryManager.Instance.PickedItem.Amount);
                    InventoryManager.Instance.PickedItem.SetItem(item,amount);
                }
            }
        }
        else
        {
            if (InventoryManager.Instance.IsPickedItem=true)
            {
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    StoreSlotItem(InventoryManager.Instance.PickedItem.Item);
                    InventoryManager.Instance.RemoveOneItem();
                }
                else
                {
                    for (int i = 0; i < InventoryManager.Instance.PickedItem.Amount; i++)
                    {
                        this.StoreSlotItem(InventoryManager.Instance.PickedItem.Item );
                    }
                    InventoryManager.Instance.RemoveAlllItem();
                }
            }
            else
            {
                return;
            }
        }
    }
}