using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : Item
{

    public int Physical_Defence { get; set; }
    public int Magical_Defence { get; set; }
    
    public EquimentType equimentType { get; set; }
    public enum EquimentType
    {
        None,
        Chest
    }
    
    public Equipment(int id, string name, ItemType itemType, Quality quality, string description, int buyPrice, 
        int sellPrice, string sprite,int physicalDefence,int magicalDefence,EquimentType equipment) : 
        base(id, name, itemType, quality, description, buyPrice, sellPrice, sprite)
    {
        this.Physical_Defence = physicalDefence;
        this.Magical_Defence = magicalDefence;
        this.equimentType = equimentType;
    }
    
}
