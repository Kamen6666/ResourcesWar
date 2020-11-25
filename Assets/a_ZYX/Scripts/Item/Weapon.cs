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
        None,
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

    public enum WeaponType
    {
        None,
        MainHand,
        OffHand
    }

  
    public int Physical_Damage { get; set; }
    public int Magical_Damage { get; set; }
    public int attackRange = 1;

    public int AttackRange
    {
        get { return attackRange;}
        set { attackRange = value; }
    }
    
    public WeaponType weaponType { get; set; }
    public ProfessionalType professionalType { get; set; }
    public Weapon(int id, string name, ItemType itemType, Quality quality, string description, int buyPrice, 
        int sellPrice, string sprite,int physicalDamage,int magicalDamage,WeaponType weaponType,ProfessionalType professionalType,
        int attackRange=1) : 
        base(id, name, itemType, quality, description, buyPrice, sellPrice, sprite)
    {

        this.Physical_Damage = physicalDamage;
        this.Magical_Damage = magicalDamage;
        this.weaponType = weaponType;
        this.professionalType = professionalType;
        this.AttackRange = attackRange;
    }

    public override string GetToolTipText()
    {
        string text= base.GetToolTipText();
        string newText = text + string.Format("适配职业：{0}\n" +
                                              "武器类型：{1}\n",professionalType,weaponType);
        return newText;
    }
}
