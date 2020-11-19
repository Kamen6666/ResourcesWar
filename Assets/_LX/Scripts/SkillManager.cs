using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    public SkillData activeSkill;
    public Image skillImage;
    public Text skillName, skillLvText, skillDesText;
    [SerializeField]int skillPoint;
    public Text pointText;
    public SkillsButton[] skillsButtons;
    #region 单例
    //静态索引
    public static SkillManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    #endregion
    private void Start()
    {
        UpdatePointUI();
    }
    public void UpgradeButton()
    {
        if (skillPoint>0 && activeSkill.preSkills.Length == 0)
        {
            skillsButtons[activeSkill.SkillID].GetComponent<Image>().color = Color.white;
            GameObject Point = skillsButtons[activeSkill.SkillID].transform.Find("Point").gameObject;
            Point.SetActive(true);
            Point.transform.GetChild(0).GetComponent<Text>().text = (++activeSkill.skillLevel).ToString();
            DisplaySkillInfo();
            skillPoint--;
            UpdatePointUI();
            activeSkill.isUnlock = true;
        }
    }
    public void DisplaySkillInfo()
    {
        skillImage.sprite = activeSkill.skillSprite;
        skillName.text = activeSkill.skillName;
        skillLvText.text = "Skill Level : Lv " + activeSkill.skillLevel.ToString();
        skillDesText.text = activeSkill.skillDes;
    }
    private void UpdatePointUI()
    {
        pointText.text = $"Point: {skillPoint}/20";
    }
}
