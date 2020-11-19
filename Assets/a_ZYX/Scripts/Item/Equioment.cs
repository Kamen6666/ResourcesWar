using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equioment : Item
{
    public int Physical_Damage { get; set; }
    public int Magical_Damage { get; set; }
    public int Physical_Defence { get; set; }
    public int Magical_Defence { get; set; }
    
    
    public Equioment(int id, string name, ItemType itemType, Quality quality, string description, int buyPrice, 
        int sellPrice, string sprite,int physicalDamage,int magicalDamage,int physicalDefence,int magicalDefence) : 
        base(id, name, itemType, quality, description, buyPrice, sellPrice, sprite)
    {
        this.Physical_Damage = physicalDamage;
        this.Magical_Damage = magicalDamage;
        this.Physical_Damage = physicalDefence;
        this.Magical_Defence = magicalDefence;
    }
}
