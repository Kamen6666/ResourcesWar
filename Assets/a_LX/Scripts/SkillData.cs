using UnityEngine;

[CreateAssetMenu(menuName ="New Skill",fileName ="Skill")]
public class SkillData : ScriptableObject
{
    public int SkillID;
    public Sprite skillSprite;
    public string skillName;
    public int skillLevel;
    [TextArea(1,8)]
    public string skillDes;

    public bool isUnlock;
    public SkillData[] preSkills;

    public int maxSkillPoint;
    public bool isPassive;
}
