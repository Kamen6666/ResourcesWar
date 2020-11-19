using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    /// <summary>
    /// 适配职业
    /// </summary>
    public enum ProfessionalType
    {
        /// <summary>
        /// 基础
        /// </summary>
        Basics,
        /// <summary>
        /// 战士
        /// </summary>
        Soldier,
        /// <summary>
        /// 魔法师
        /// </summary>
        Enchanter,
        /// <summary>
        /// 猎人
        /// </summary>
        Hunter,
        /// <summary>
        /// 盗贼
        /// </summary>
        Robbers
        
        
    }
    public int Physical_Damage { get; set; }
    public int Magical_Damage { get; set; }
    public ProfessionalType professionalType { get; set; }
    public Weapon(int id, string name, ItemType itemType, Quality quality, string description, int buyPrice, 
        int sellPrice, string sprite,int physicalDamage,int magicalDamage,ProfessionalType professionalType) : 
        base(id, name, itemType, quality, description, buyPrice, sellPrice, sprite)
    {

        this.Physical_Damage = physicalDamage;
        this.Magical_Damage = magicalDamage;
        this.professionalType = professionalType;

    }
}
