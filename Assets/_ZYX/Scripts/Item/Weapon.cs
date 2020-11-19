using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    public enum ProfessionalType
    {
        Basics,
    }
    public int Physical_Damage { get; set; }
    public int Magical_Damage { get; set; }
    
    public Weapon(int id, string name, ItemType itemType, Quality quality, string description, int buyPrice, 
        int sellPrice, string sprite) : 
        base(id, name, itemType, quality, description, buyPrice, sellPrice, sprite)
    {
        
        
        
    }
}
