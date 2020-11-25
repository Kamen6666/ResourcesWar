using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Item
{
    public int HP { get; set; }
    public int MP { get; set; }

    public ConsumableType consumableType { get; set; }
    public enum ConsumableType
    {
        None,
        HuiFu
    }
    public Consumable(int id, string name, ItemType itemType, Quality quality, string description, int buyPrice, int sellPrice, string sprite,
        int hp,int mp,ConsumableType consumableType) : 
        base(id, name, itemType, quality, description, buyPrice, sellPrice, sprite)
    {
        this.consumableType = consumableType;
        this.HP = hp;
        this.MP = mp;
    }
}
