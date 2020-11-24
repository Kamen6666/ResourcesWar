using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

struct  Test
{
   public float a;
}
public class ItemUI : MonoBehaviour
{
   
   public Item Item { get; private set; }
   public int Amount { get;private set; }

   private Image itemImage;
   private Text amountText;
   private Vector3 amimationScale =new Vector3(1.2f,1.2f,1.2f);

   private float targetScale = 1f;

   private float smoothing = 3;

   void Update()
   {
      if (transform.localScale.x!=targetScale)
      {
         float scale = Mathf.Lerp(transform.localScale.x, targetScale,smoothing*Time.deltaTime);
         transform.localScale=new Vector3(scale,scale,scale);
         if (Mathf.Abs(transform.localScale.x-targetScale)>0.03f)
         {
            transform.localScale=new Vector3(targetScale,targetScale,targetScale);
         }
      }
   }
   private Image ItemImage
   {
      get
      {
         if (itemImage==null)
         {
            itemImage = GetComponent<Image>();
         }
         return itemImage;
      }
   }

   public Text AmountText
   {
      get
      {
         if (amountText==null)
         {
            amountText = transform.GetChild(0).GetComponent<Text>();
         }

         return amountText;
      }
   }
   public  void  SetItem(Item item,int amount=1)
   {
      transform.localScale = amimationScale;
      this.Item = item;
      this.Amount = amount;
      //Update UI
      ItemImage.sprite=Resources.Load<Sprite>(item.Sprite);
      AmountText.text = Amount.ToString();
   }
   
   public void AddAmount(int amount=1)
   {
      transform.localScale = amimationScale;
      this.Amount += 1;
      //Update UI
      AmountText.text = Amount.ToString();
   }

   public void SetAmount(int amount)
   {
      transform.localScale = amimationScale;
      this.Amount = amount;
 
         amountText.text = Amount.ToString();
   }

   public void Show()
   {
      gameObject.SetActive(true);
   }

   public void ExChange(ItemUI itemUi)
   {
      Item itemtmp = itemUi.Item;
      int amountmp = itemUi.Amount;
      itemUi.SetItem(this.Item,this.Amount);
      this.SetItem(itemtmp,amountmp);
   }
   public void ReduceAmount(int amount = 1)
   {
      transform.localScale = amimationScale;
      this.Amount -= amount;
     
         amountText.text = Amount.ToString();
         AmountText.text = "";
   }
   public void Hide()
   {
      gameObject.SetActive(false);
   }

   public void SetLocalPos(Vector3 position)
   {
      transform.localPosition = position;
   }
}
