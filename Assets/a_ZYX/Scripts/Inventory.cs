using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
      public Slot[] slotList;

    public bool isShow = false;

    private float timeCount;

    private Canvas canvas;

    private CanvasGroup canvasGroup;
    public virtual void Start()
    {
        ///slotobjList = transform.GetChild(0).GetComponentsInChildren<Transform>();
        slotList = GetComponentsInChildren<Slot>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    /// <summary>
    /// 是否能存储
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool StoreItem(int id)
    {
        Item item = InventoryManager.Instance.GetItemById(id);
        return StoreItem(item);
    }

    public bool StoreItem(Item item)
    {
     
        //如果item为空
        if (item==null)
        {
            Debug.Log("存储的物品id不存在");
            return false;
        }
        else
        {
//            Debug.Log("添加了新物品：  "+item.Name);
            //item不为空
            //找到一个相同的
            Slot slot = FindSameIDSolt(item);
            if (slot!=null)
            {
                slot.StoreSlotItem(item);
            }
            else
            {
                //如果没找到相同的物品
                //找到一个空的物品槽
                Slot emptySlot = FindEmptySlot();
                if (emptySlot!=null)
                {
                    emptySlot.StoreSlotItem(item);
                }
                else
                {
                    //如果没找到空的物品槽  
                    Debug.Log("没有存储空的物品槽");
                    return false;
                }
            
            }
            
        }
        return true;
       
    }
    /// <summary>
/// 找到空的物品槽
/// </summary>
/// <returns></returns>
    public Slot FindEmptySlot()
    {
        foreach (var slot in slotList)
        {
            if (slot.transform.childCount==0)
            {
                return slot;
            }
        }

        return null;
    }

    public Slot FindSameIDSolt(Item item)
    {
        foreach (var slot in slotList)
        {
            if (slot.transform.childCount>=1&&slot.GetItemID()==item.ID)
            {
                return slot;
            }
        }
        
        return null;
    }
    public void SortSlot()
    {
        ClearItem();
        List<GameObject> sort = Sort();
        for (int i = 0; i < sort.Count; i++)
        {
            slotList[i].SetItemUI(sort[i]);
        }
    }
    public List<GameObject> Sort()
    {
        List<GameObject> items = FindHasItem();
        GameObject tmp = null;
        for (int i = 0; i < items.Count; i++)
        {
            for (int j = 0; j < items.Count; j++)
            {
                if (items[i].transform.GetChild(0).GetComponent<ItemUI>().Item.ID<items[j].transform.GetChild(0).GetComponent<ItemUI>().Item.ID)
                {
                    tmp = items[i];
                    items[i] = items[j];
                    items[j] = tmp;
                }
            }
        }
        return items;

    }
    
    /// <summary>
    /// solt下有物品的
    /// </summary>
    /// <returns></returns>
    public List<GameObject> FindHasItem()
    {
        List<GameObject> hasItem= new List<GameObject>();
        for (int i = 0; i < slotList.Length; i++)
        {
            if (slotList[i].transform.childCount >= 1)
            {
                hasItem.Add(slotList[i].gameObject);
            }
        }

        return hasItem;
    }

    #region 排序2

    public void SortSlot2()
    {
        List<Transform> translit = Sort2();
        for (int i = 0; i < translit.Count; i++)
        {
        
        }
    }
    public List<Transform> Sort2()
    {
        List<Transform> items = FindHasItem2();
        Transform tmp = null;
        for (int i = 0; i < items.Count; i++)
        {
            for (int j = 0; j < items.Count; j++)
            {
                if (items[i].transform.GetChild(0).GetComponent<ItemUI>().Item.ID<items[j].transform.GetChild(0).GetComponent<ItemUI>().Item.ID)
                {
                    tmp = items[i];
                    items[i] = items[j];
                    items[j] = tmp;
                }
            }
        }
        return items;

    }
    public List<Transform> FindHasItem2()
    {
        List<Transform> hasItem= new List<Transform>();
        for (int i = 0; i < slotList.Length; i++)
        {
            if (slotList[i].transform.childCount >= 1)
            {
                hasItem.Add(slotList[i].transform);
            }
        }

        return hasItem;
    }

    #endregion

    /// <summary>
    /// 清除所有物件
    /// </summary>
    public void ClearItem()
    {
        for (int i = 0; i < slotList.Length; i++)
        {
            if (slotList[i].transform.childCount>=1)
            {
                slotList[i].Clear();
            }
        }
    }
    public void Show()
    {
       
        if (!isShow)
        {
            canvasGroup.alpha=1;
        }
        isShow = true;
    }

    public void Hide()
    {
        isShow = false;
        canvasGroup.alpha = 0;
    }
}
