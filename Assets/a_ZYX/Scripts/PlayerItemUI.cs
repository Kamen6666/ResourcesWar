using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItemUI : ItemUI
{

    public Item Item { get; private set; }
    private Image itemImage;

    private Image ItemImage
    {
        get
        {
            if (itemImage == null)
            {
                itemImage = GetComponent<Image>();
            }

            return itemImage;
        }
    }

    public void SetPlayerItem(Item item, int amount = 1)
    {
        this.Item = item;
        //Update UI
        ItemImage.sprite = Resources.Load<Sprite>(item.Sprite);
    }
}
